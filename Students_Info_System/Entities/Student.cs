using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Info_System.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Departament")]
        public int DepartamentId { get; set; }

        public Departament Departament { get; set; }

        public Student()
        {
        }
        public Student (string name, string surname, DateTime dateOfBirth)
        {
                this.Name = name;
                this.Surname = surname;
                this.DateOfBirth = dateOfBirth;
                
        }
        }
}
