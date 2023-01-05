using Azure;
using Microsoft.EntityFrameworkCore;
using Students_Info_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Info_System
{
    public class DepartamentContext : DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=LAPTOP-AIJO16D6\\SQLEXPRESS;Initial Catalog=Students_Info_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
