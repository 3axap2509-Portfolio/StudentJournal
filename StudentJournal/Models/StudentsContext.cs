namespace StudentJournal
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentJournal.Models;

    public class StudentsContext : DbContext
    {
        public StudentsContext()
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}