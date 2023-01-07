using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Info_System.Entities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Departament> Departaments { get; set; }
        public Lecture ()
         {
         }

        public Lecture(string Name, List<Departament> departaments)
        {
            this.Id = Id;
            this.Name = Name;
            this.Departaments = new List<Departament>();

        }


    }
}
