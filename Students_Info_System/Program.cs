using Students_Info_System.Entities;
using Students_Info_System;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Students Info System");

var dbContext = new DepartamentContext();


void CreateNewDepartament()
{
    Console.WriteLine("1.(1,2,3) Create a New department:");
    Console.WriteLine("1.1. Please enter departament name:");
    string dpName = Console.ReadLine();
    Console.WriteLine("1.2. Please enter departament address (City):");
    string dpCity = Console.ReadLine();
    Console.WriteLine("1.3. Please enter departament address (Street name and number):");
    string dpAddress = Console.ReadLine();

    var departament = new Departament { Name = dpName, City = dpCity, Address = dpAddress };
    departament.Lectures = new List<Lecture>();
    departament.Students = new List<Student>();

    Console.WriteLine("1. Create a New Lecture:");
    Console.WriteLine("1.1. Please enter lecture name:");
    string lectureName = Console.ReadLine();
    departament.Lectures.Add(new Lecture { Name = lectureName });

    Console.WriteLine("1.(1,2,3) Create a New Student:");
    Console.WriteLine("1.1. Please enter student name:");
    string StName = Console.ReadLine();
    Console.WriteLine("1.2. Please enter student surname:");
    string StSurname = Console.ReadLine();
    Console.WriteLine("1.3. Please enter student date of birth):");
    string Stdate = Console.ReadLine();
    departament.Students.Add(new Student() { Name = StName, Surname = StSurname, DateOfBirth = new DateTime(2004, 01, 03) });
    
    dbContext.Departaments.Add(departament);
    dbContext.SaveChanges();

}
void CreateNewStudentToExistingDepartament()
{
    Console.WriteLine("List of Departaments:");
    var consoleresult = dbContext.Departaments;
    Console.WriteLine("| Departament ID | Departament Name | Departament City | Departament Address");
    foreach (var item in consoleresult)
    {
        Console.Write(item.Id + " | ");
        Console.Write(item.Name + " | ");
        Console.Write(item.City + " |  ");
        Console.Write(item.Address + " |  ");
        Console.WriteLine();
    }

    Console.WriteLine("2. and 4.  Please choose Departament ID:");
    int dpId = int.Parse(Console.ReadLine());
  
    Console.WriteLine("2.(1,2,3) Create a New Student to existing Departament:");
    Console.WriteLine("2.1. Please enter student name:");
    string StName = Console.ReadLine();
    Console.WriteLine("2.2. Please enter student surname:");
    string StSurname = Console.ReadLine();
    Console.WriteLine("2.3. Please enter student date of birth):");
    string Stdate = Console.ReadLine();

    dbContext.AddRange
        (
          new Student() { Name = StName, Surname = StSurname, DateOfBirth = new DateTime(1999, 02, 16), DepartamentId = dpId }
        );
    dbContext.SaveChanges();
}

void CreateNewLecturesToNewDepartament()
{
    Console.WriteLine("3.(1,2,3) Create a New department:");
    Console.WriteLine("3.1. Please enter departament name:");
    string dpName = Console.ReadLine();
    Console.WriteLine("3.2. Please enter departament address (City):");
    string dpCity = Console.ReadLine();
    Console.WriteLine("3.3. Please enter departament address (Street name and number):");
    string dpAddress = Console.ReadLine();

    var departament = new Departament { Name = dpName, City = dpCity, Address = dpAddress };

    Console.WriteLine("3.1. Please enter Lecture name:");
    string lectureName = Console.ReadLine();

    Console.WriteLine("3. Creating new Lectures...");
    dbContext.AddRange
                (
                    new Lecture { Name = lectureName, Departaments = new List<Departament> { departament } }
                );
    dbContext.SaveChanges();
}

void CreateNewLecturesToExistingDepartament()
{ 
    Console.WriteLine("3.1.1 List of Departaments:");
    var consoleresult = dbContext.Departaments;
    Console.WriteLine("| Departament ID | Departament Name | Departament City | Departament Address");
    foreach (var item in consoleresult)
    {
        Console.Write(item.Id + " | ");   
        Console.Write(item.Name + " | ");
        Console.Write(item.City + " |  ");
        Console.Write(item.Address + " |  ");
        Console.WriteLine();
    }

    Console.WriteLine("3.1.1 Please choose Departament ID:");
    int dpId = int.Parse(Console.ReadLine());

    var resultDpId = dbContext.Departaments.Include(x => x.Lectures).Where(d => d.Id == dpId).FirstOrDefault();
    Console.WriteLine("3.1.1 Please Enter New Lecture Name");
    string lectureName = Console.ReadLine();
    dbContext.AddRange
               (
                    new Lecture { Name = lectureName, Departaments = new List<Departament> { resultDpId } }               
               );
    dbContext.SaveChanges();
}

void TransferStudentToAnotherDepartament ()
{

    Console.WriteLine("5. List of Departaments:");
    var consoleresult = dbContext.Departaments;
    Console.WriteLine("| No | Departament ID | Departament Name | Departament City | Departament Address");
    foreach (var item in consoleresult)
    {
        Console.Write(item.Id + " | ");
        Console.Write(item.Name + " | ");
        Console.Write(item.City + " |  ");
        Console.Write(item.Address + " |  ");
        Console.WriteLine();
    }

    Console.WriteLine("5. Students of department please choose Departament ID (2,3,4,8,9...):");
    int dpId = int.Parse(Console.ReadLine());

    // var studentsName = dbContext.Students.Where(n => n.DepartamentId == dpId).Select(na => na.Name);
    // var studentsSurname = dbContext.Students.Where(x => x.DepartamentId == dpId).Select(sa => sa.Surname);

    // var studentDep = dbContext.Students.Where(x => x.Id == dpId).Select(x => x.DepartamentId).FirstOrDefault();
    //var result = dbContext.Departaments.Include(d => d.Students).Where(x => x.Id == studentDep).FirstOrDefault();

    var result = dbContext.Departaments.Include(d => d.Students).Where(x => x.Id == dpId).FirstOrDefault();
    
    var students = result.Students;
    Console.WriteLine("| Student ID | Student Name | Student Surname | Student Data of Birth |");

    foreach (var item in students)
    {
        Console.Write(item.Id + " ");
        Console.Write(item.Name + " ");
        Console.Write(item.Surname+ " ");
        Console.WriteLine(item.DateOfBirth + " ");
        Console.WriteLine();
    }
    Console.WriteLine("********");

    Console.WriteLine("5. Move Student To another Departament please choose Student ID:");
    int stId = int.Parse(Console.ReadLine());
}

void ConsoleStudentsOfDepartament()
{ 
    Console.WriteLine("6. List of Departaments:");
    var consoleresult = dbContext.Departaments;
    Console.WriteLine("| No | Departament ID | Departament Name | Departament City | Departament Address");
   
    foreach (var item in consoleresult)
    {
        Console.Write(item.Id + " | ");
        Console.Write(item.Name + " | ");
        Console.Write(item.City + " |  ");
        Console.Write(item.Address + " |  ");
        Console.WriteLine();
    }

    Console.WriteLine("6. Students of department please choose (2,3,4,8,9...):");
    int dpId = int.Parse(Console.ReadLine());

    var result = dbContext.Departaments.Include(d => d.Students).Where(x => x.Id == dpId).FirstOrDefault();
    var students = result.Students;

    Console.WriteLine("| Student ID | Student Name | Student Surname | Student Data of Birth |");

    foreach (var item in students)
    {
        Console.Write(item.Name + " ");
        Console.Write(item.Surname + " ");
        Console.WriteLine(item.DateOfBirth + " ");
        Console.WriteLine();
    }
    Console.WriteLine("********");
}



void ConsoleLecturesOfDepartament()
{
    Console.WriteLine("7. Lectures of department please choose (2,3,4,8,9):");
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
    foreach (var item in consoleresult)
    {
        Console.Write(item.Id + " | ");
        Console.Write(item.Name + " | ");
        Console.Write(item.Surname + " |  ");
        Console.WriteLine();
    }

    Console.WriteLine("8. Lectures of student please choose Student ID:");
    int stId = int.Parse(Console.ReadLine());
    var studentDep = dbContext.Students.Where(x => x.Id == stId).Select(x => x.DepartamentId).FirstOrDefault();
    var result = dbContext.Departaments.Include(d => d.Lectures).Include(d => d.Students).Where(x => x.Id == studentDep).FirstOrDefault();

    var lectures = result.Lectures;

    foreach (var item in lectures)
    {
        Console.WriteLine(item.Name);
    }
    Console.WriteLine("*******");

}


//CreateNewStudentToExistingDepartament();
//CreateNewLecturesToExistingDepartament();
TransferStudentToAnotherDepartament();
//CreateNewLecturesToNewDepartament();
//CreateNewDepartament();
//ConsoleLecturesOfDepartament();
//ConsoleLecturesByStudent();
// ConsoleStudentsOfDepartament();






