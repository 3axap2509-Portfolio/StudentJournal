using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StudentJournal.Commands;
using StudentJournal.Helpers;
using StudentJournal.Models;

namespace StudentJournal.ViewModels
{
    public abstract class StudentRepository: INotifyPropertyChanged
    {
        public StudentRepository()
        {
            editableStudent = new Student();
            EditOrAdd = false;

            AgeValues = new List<int>();
            for (ushort i = 16; i < 101; i++)
                AgeValues.Add(i);

            LoadStudentsCollection();
        }

        public ObservableCollection<Student> Students { get; set; }
        public List<Student> StudentsToAddOrEdit = new List<Student>();
        public List<int> StudentsToRemove = new List<int>();

        public List<int> AgeValues { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private Student editableStudent;
        public Student EditableStudent
        {
            get
            {
                return this.editableStudent;
            }
            set
            {
                editableStudent = value;
                OnPropertyChanged();
            }
        }

        private bool editOrAdd;
        public bool EditOrAdd
        {
            get
            {
                return editOrAdd;
            }
            set
            {
                editOrAdd = value;
                OnPropertyChanged();
            }
        }

        protected bool IsNeedToSaveChanges = false;

        public ICommand AddNewStudent
        {
            get
            {
                return new Command((obj) =>
                {
                    try
                    {
                        var parms = (object[])obj;
                        Regex s_name = new Regex("(^[A-Z]{1}[a-z]{1,24} [A-Z]{1}[a-z]{1,24}$)|(^[А-Я]{1}[а-я]{1,24} [А-Я]{1}[а-я]{1,24}$)");
                        if (s_name.IsMatch((string)parms[0] + ' ' + (string)parms[1]))
                        {
                            Student newStudent = new Student
                                (
                                    (Students.Count > 0 ? Students.Max(el => el.Id) + 1 : Students.Count + 1),
                                    (string)parms[0],
                                    (string)parms[1],
                                    (int)parms[2],
                                    (Gender)parms[3]
                                );
                            Students.Add(newStudent);
                            StudentsToAddOrEdit.Add(newStudent);
                            if (!IsNeedToSaveChanges) IsNeedToSaveChanges = true;
                        }
                        else
                            throw new Exception("Имя и фамилия должны начинаться с заглавных букв, не должны содержать никаких символов кроме латинских или русских букв и должны быть длиной от 2 до 25 символов.\nИсправьте их и повторите попытку");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка при добавлении студента");
                    }
                });
            }
        }

        public ICommand RemoveStudents
        {
            get
            {
                return new Command(obj =>
                {
                    IList items = (IList)obj;
                    List<Student> studentCollection = items.Cast<Student>().ToList();
                    System.Windows.Forms.DialogResult dialogResult =
                        System.Windows.Forms.MessageBox.Show
                        (
                            $"Вы уверены, что хотите удалить " +
                            (studentCollection.Count > 1 ?
                                "выбранные элементы?" : "выбранный элемент?"),
                            "Подтвердите удаление записей",
                            System.Windows.Forms.MessageBoxButtons.YesNo
                        );
                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!IsNeedToSaveChanges) IsNeedToSaveChanges = true;
                        foreach (Student s in studentCollection)
                        {
                            Students.Remove(s);
                            StudentsToRemove.Add(s.Id);
                        }
                    }
                });
            }
        }

        public ICommand EditStudent
        {
            get
            {
                return new Command((obj) =>
                {
                    try
                    {
                        var parms = (object[])obj;
                        Regex s_name = new Regex("(^[A-Z]{1}[a-z]{1,24} [A-Z]{1}[a-z]{1,24}$)|(^[А-Я]{1}[а-я]{1,24} [А-Я]{1}[а-я]{1,24}$)");
                        if (s_name.IsMatch((string)parms[0] + ' ' + (string)parms[1]))
                        {
                            EditOrAdd = false;
                            int id = editableStudent.Id;
                            int index = Students.IndexOf(Students.Single(el => el.Id == id));
                            Student newStudent = new Student
                                (
                                    id,
                                    (string)parms[0],
                                    (string)parms[1],
                                    (int)parms[2],
                                    (Gender)parms[3]
                                );
                            Students[index] = newStudent;
                            StudentsToAddOrEdit.Add(newStudent);
                            if (!IsNeedToSaveChanges) IsNeedToSaveChanges = true;
                        }
                        else
                            throw new Exception
                            (
                                "Имя и фамилия должны начинаться с заглавных букв, " +
                                "не должны содержать никаких символов кроме латинских " +
                                "или русских букв и должны быть длиной от 2 до 25 символов.\n" +
                                "Исправьте их и повторите попытку"
                            );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка при редактировании студента");
                    }
                });
            }
        }

        public ICommand StartEditStudent
        {
            get
            {
                return new Command((obj) =>
                {
                    EditableStudent = (Student)obj;
                    EditOrAdd = true;
                });
            }
        }

        public ICommand EditCanceled
        {
            get
            {
                return new Command((obj) => EditOrAdd = false);
            }
        }

        public abstract ICommand SaveChanges
        {
            get;
        }

        public abstract void LoadStudentsCollection();
    }
}
