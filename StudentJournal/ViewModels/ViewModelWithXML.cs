using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using StudentJournal.Commands;
using StudentJournal.Helpers;

namespace StudentJournal.ViewModels
{
    public class ViewModelWithXML : StudentRepository, INotifyPropertyChanged
    {
        public ViewModelWithXML() : base() { }

        public override ICommand SaveChanges
        {
            get
            {
                return new Command((obj) =>
                {
                    XmlWorker.Serialize(Students.ToList());
                    IsNeedToSaveChanges = false;
                    MessageBox.Show("Записи успешно сохранены в файл 'Students.xml'", "Сериализация завершена");
                }, (obj) =>
                {
                    return IsNeedToSaveChanges;
                });
            }
        }

        public override void LoadStudentsCollection()
        {
            Students = XmlWorker.Deserialize();
        }
    }
}