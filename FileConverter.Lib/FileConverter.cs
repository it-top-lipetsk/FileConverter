using University.DataModel;

namespace FileConverter.Lib
{
    public abstract class FileConverter
    {
        public abstract void Import(in string path, out Student student);
        public abstract void Export(in string path, in Student student);
    }
}