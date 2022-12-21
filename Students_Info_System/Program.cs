using Students_Info_System.Entities;
using Students_Info_System;
using System.Net;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//

using var dbContext = new DepartamentContext();
/*

var departament1 = new Departament { Name = "Informatikos fakultetas", City = "Kaunas", Address = "Studentų g. 50-412" };
var departament2 = new Departament { Name = "Matematikos ir gamtos mokslų fakultetas", City = "Kaunas", Address = "Studentų g. 50-218" };

dbContext.AddRange
    (
    new Lecture { Name = "Dirbtinis intelektas", Departaments = new List<Departament> { departament1 }},
    new Lecture { Name = "Informacinės sistemos", Departaments = new List<Departament> { departament1 }},
    new Lecture { Name = "Informatika", Departaments = new List<Departament> { departament1 }},
    new Lecture { Name = "Informatikos inžinerija", Departaments = new List<Departament> { departament1 }},
    new Lecture { Name = "Multimedijos technologijos", Departaments = new List<Departament> { departament1 }},
    new Lecture { Name = "Programų sistemos", Departaments = new List<Departament> { departament1 }},

    new Lecture { Name = "Diskrečioji matematika", Departaments = new List<Departament> { departament2 } },
    new Lecture { Name = "Įvadas į matricų teoriją ir geometriją", Departaments = new List<Departament> { departament2 } },
    new Lecture { Name = "Matematikos ir informatikos studijų įvadas", Departaments = new List<Departament> { departament2 } },
    new Lecture { Name = "Matematinė analizė", Departaments = new List<Departament> { departament2 } },
    new Lecture { Name = "Objektinio programavimo alternatyvos", Departaments = new List<Departament> { departament2 } },
    new Lecture { Name = "Objektinio programavimo pagrindai", Departaments = new List<Departament> { departament2 } },
    new Lecture { Name = "Objektinis programavimas", Departaments = new List<Departament> { departament2 } }
    );

*/

//var departament = new Departament { Name = "Informatikos fakultetas", City = "Kaunas", Address = "Studentų g. 50-412" };

dbContext.Students.Add(new Student { Name = "Tadas", Surname = "Lietuvaitis", DateOfBirth = new DateTime(1999 - 12 - 21) });
dbContext.Students.Add(new Student { Name = "Matas", Surname = "Petraitis", DateOfBirth = new DateTime(2000 - 01 - 22) });
dbContext.Students.Add(new Student { Name = "Vidas", Surname = "Jonaitis", DateOfBirth = new DateTime(2001 - 02 - 23) });
dbContext.Students.Add(new Student { Name = "Gedas", Surname = "Pavardenis", DateOfBirth = new DateTime(1998 - 03 - 24) });
dbContext.Students.Add(new Student { Name = "Tomas", Surname = "Kalnietis", DateOfBirth = new DateTime(1997 - 04 - 25) });
dbContext.Students.Add(new Student { Name = "Tajus", Surname = "Berankis", DateOfBirth = new DateTime(1996 - 05 - 26) });
dbContext.Students.Add(new Student { Name = "Rojus", Surname = "Sudeikis", DateOfBirth = new DateTime(1997 - 06 - 27) });
dbContext.Students.Add(new Student { Name = "Nojus", Surname = "Zymantas", DateOfBirth = new DateTime(1998 - 07 - 28) });
dbContext.Students.Add(new Student { Name = "Titas", Surname = "Smith", DateOfBirth = new DateTime(1999 - 08 - 29) });
dbContext.Students.Add(new Student { Name = "Jorė", Surname = "Lietuvaite", DateOfBirth = new DateTime(2000 - 09 - 30) });
dbContext.Students.Add(new Student { Name = "Jurga", Surname = "Jonaityte", DateOfBirth = new DateTime(2001 - 10 - 29) });
dbContext.Students.Add(new Student { Name = "Vaida", Surname = "Petraityte", DateOfBirth = new DateTime(2001 - 11 - 30) });
dbContext.Students.Add(new Student { Name = "Daiva", Surname = "Murze", DateOfBirth = new DateTime(2002 - 12 - 31) });

dbContext.SaveChanges();





/*
DepartamentContext context = new DepartamentContext();
Departament departement = new Departament();
Lecture lecture = new Lecture();
Student student = new Student();
Departament firstDepartament = new Departament("Fundamentaliųjų mokslų", "Kaunas", "Studentų g. 50");
context.Departaments.Add(firstDepartament);
context.SaveChanges(); */

/*
DepartamentContext context = new DepartamentContext();
DateTime studentDateOfBirth = new DateTime(1999, 12, 20);
var student = new Student("Vardas", "Pavarde", studentDateOfBirth);
context.Students.Add(student);
context.SaveChanges();*/