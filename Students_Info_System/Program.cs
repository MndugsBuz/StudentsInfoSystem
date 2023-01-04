using Students_Info_System.Entities;
using Students_Info_System;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using System.ComponentModel.DataAnnotations;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var dbContext = new DepartamentContext();

/*
var departament1 = new Departament { Name = "Informatikos fakultetas", City = "Kaunas", Address = "Studentų g. 50-412" };

departament1.Lectures = new List<Lecture>();
departament1.Students = new List<Student>(); 

departament1.Lectures.Add(new Lecture { Name = "Dirbtinis intelektas2" });
departament1.Students.Add(new Student() { Name = "AVaiva", Surname = "APrause", DateOfBirth = new DateTime(2003, 01, 03) });
dbContext.Departaments.Add(departament1);
dbContext.SaveChanges();

*/

void ConsoleDepartamentLectures()
{
    Console.WriteLine("Lectures of department please choose (2,3,4,8,9):");
    int dp = int.Parse(Console.ReadLine());
    var consoleresult = dbContext.Departaments.Include(x => x.Lectures).Where(d => d.Id == dp).FirstOrDefault();
    var dplectures = consoleresult.Lectures;

    foreach (var item in dplectures)
    {
        Console.WriteLine(item.Name);
    }
    Console.WriteLine("*************");
}

void ConsoleLecturesByStudent()
{
    Console.WriteLine("List of students:");
    var consoleresult = dbContext.Students;
    Console.WriteLine("| Student ID | Student Name | Student Surname |");
    foreach ( var item in consoleresult)
    {
        Console.Write(item.Id + " | ");
        Console.Write(item.Name + " | ");
        Console.Write(item.Surname + " |  ");
        Console.WriteLine();
    }

    Console.WriteLine("Lectures of student please choose Student ID:");
    int st = int.Parse(Console.ReadLine());
    var studentDep = dbContext.Students.Where(x => x.Id == st).Select(x => x.DepartamentId).FirstOrDefault();
    var result = dbContext.Departaments.Include(d => d.Lectures).Include(d => d.Students).Where(x => x.Id == studentDep).FirstOrDefault();

    var lectures = result.Lectures;

    foreach ( var item in lectures)
    {
        Console.WriteLine(item.Name);
    }
    Console.WriteLine("*******");

}

//ConsoleDepartamentLectures();
ConsoleLecturesByStudent();






