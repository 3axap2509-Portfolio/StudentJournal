using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using StudentJournal.Commands;
using StudentJournal.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StudentJournal.ViewModels
{
    public class ViewModelWithEF : StudentRepository
    {
        public ViewModelWithEF() : base() { }

        public override ICommand SaveChanges
        {
            get
            {
                return new Command((obj) =>
                {
                    try
                    {
                        using (StudentsContext db = new StudentsContext())
                        {
                            foreach(Student s in StudentsToAddOrEdit)
                            { 
                                Student existingStudent = db.Students.Find(s.Id);
                                if (existingStudent != null)
                                {
                                    existingStudent.FirstName = s.FirstName;
                                    existingStudent.LastName = s.LastName;
                                    existingStudent.Age = s.Age;
                                    existingStudent.Gender = s.Gender;
                                }
                                else
                                    db.Students.Add(s);
                            }

                            foreach (int s in StudentsToRemove)
                            {
                                db.Students.Remove(db.Students.Find(s));
                            }
                            db.SaveChanges();
                            IsNeedToSaveChanges = false;
                            MessageBox.Show("Изменения сохранены в базе данных!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ошибка при сохранении информации в БД");
                    }
                }, (obj) =>
                {
                    return IsNeedToSaveChanges;
                });
            }
        }

        public override void LoadStudentsCollection()
        {
            Students = new ObservableCollection<Student>();

            try
            {
                using (StudentsContext db = new StudentsContext())
                {
                    if (db.Students.Count() > 0)
                        Students = new ObservableCollection<Student>(db.Students);
                    else
                        MessageBox.Show("База данных пуста!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n'" + ex.InnerException == null ? "" : ex.InnerException.Message, "Ошибка");
            }
        }
    }
}