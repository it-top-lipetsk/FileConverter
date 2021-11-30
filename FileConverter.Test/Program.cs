using System;
using FileConverter.Lib;
using University.DataModel;

namespace FileConverter.Test
{
    static class Program
    {
        static void Main()
        {
            var student = new Student
            {
                FirstName = "Andrey",
                LastName = "Starinin",
                DateOfBirth = new DateTime(year:1986, month:2, day:18),
                Faculty = "SoftDev"
            };

            var json = new JsonFile();
            json.Export("student.json", student);

            var csv = new CsvFile();
            csv.Delimiter = '|';
            csv.Export("student.csv", student);
            
            json.Import("student.json", out var new_student);
            Console.WriteLine($"{new_student.LastName} {new_student.FirstName}");
            
            csv.Import("student.csv", out var new_student_2);
            Console.WriteLine($"{new_student_2.LastName} {new_student_2.FirstName}");
        }
    }
}