using System.IO;
using System.Text.Json;
using University.DataModel;

namespace FileConverter.Lib
{
    public class JsonFile : FileConverter
    {
        public override void Import(in string path, out Student student)
        {
            student = new Student();

            using var file = new StreamReader(path);
            var temp = file.ReadToEnd();
            student = (Student)JsonSerializer.Deserialize(temp, typeof(Student));
        }

        public override void Export(in string path, in Student student)
        {
            using var file = new StreamWriter(path, append: false);
            var json = JsonSerializer.Serialize(student, typeof(Student));
            file.WriteLine(json);
        }
    }
}