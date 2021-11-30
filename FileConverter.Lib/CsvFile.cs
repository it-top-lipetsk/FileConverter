using System;
using System.IO;
using University.DataModel;

namespace FileConverter.Lib
{
    public class CsvFile : FileConverter
    {
        public char Delimiter { get; set; }
        
        public override void Import(in string path, out Student student)
        {
            student = new Student();

            using var file = new StreamReader(path);
            var str = file.ReadToEnd();

            var temp = str.Split(Delimiter);
            student.FirstName = temp[0];
            student.LastName = temp[1];
            student.DateOfBirth = Convert.ToDateTime(temp[2]);
            student.Faculty = temp[3];
        }

        public override void Export(in string path, in Student student)
        {
            var s = student;
            var str = $"{s.FirstName}{Delimiter}{s.LastName}{Delimiter}{s.DateOfBirth}{Delimiter}{s.Faculty}";
            
            using var file = new StreamWriter(path, append: false);
            file.WriteLine(str);
        }
    }
}