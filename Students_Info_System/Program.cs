using Students_Info_System.Entities;
using Students_Info_System;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//

/*DepartamentContext context = new DepartamentContext();

Departament firstDepartament = new Departament(1, "Informacikos fakultetas", "Kaunas", "Studentų g. 50");

context.Departaments.Add(firstDepartament);

context.SaveChanges();*/

DepartamentContext context = new DepartamentContext();
DateTime studentDateOfBirth = new DateTime(2015, 12, 31);
var student = new Student(1, "Vardas", "Pavarde", studentDateOfBirth);
context.Students.Add(student);
context.SaveChanges();