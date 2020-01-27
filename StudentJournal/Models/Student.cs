using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace StudentJournal.Models
{
    public enum  Gender
    {
        Male = 0,
        Female = 1
    }
    [Serializable]
    public class Student
    {
        private uint age;

        [XmlAttribute("Id")]
        [Key]
        public int Id { get; set; }
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("Last")]
        public string LastName { get; set; }
        [XmlElement("Age")]
        public int Age
        {
            get
            {
                return (int)age;
            }
            set
            {
                if(value > 100)
                {
                    age = 100;
                    MessageBox.Show("Возраст студента был автоматически сокращён до 100 лет, т.к. изначально превышал данное значение");
                }
                else if(value < 16)
                {
                    age = 16;
                    MessageBox.Show("Возраст студента был автоматически увеличен до 16 лет, т.к. изначально был меньше, чем данное значение");
                }
                else
                    age = (uint)value;
            }
        }
        [XmlElement("Gender")]
        public int Gender { get; set; }

        public Student() { }
        public Student(int id, string fn, string ln, int age, Gender g)
        {
            this.Id = id;
            this.FirstName = fn;
            this.LastName = ln;
            this.Age = Math.Abs(age);
            this.Gender = (ushort)g;
        }
    }
}