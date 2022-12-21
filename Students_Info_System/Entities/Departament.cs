﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Info_System.Entities
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<Student> Students { get; set; }
        public List<Lecture> Lectures { get; set; }

        public Departament ()
        {
        }

        public Departament(string name, string city, string address)
        {
            this.Id = Id;
            this.Name = name;
            this.City = city;
            this.Address = address; 
            Students = new List<Student> ();
            Lectures = new List<Lecture> ();
        }

    }
}
