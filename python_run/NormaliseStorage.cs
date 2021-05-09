using System.IO;

namespace python_run
{
    public class NormaliseStorage
    {
        public int Execute(string source, string normalisedSource)
        {
            var files = Directory.GetFiles(source, "*.jpg", SearchOption.AllDirectories);
            int index = 1;
            foreach(var file in files)
            {
                File.Copy(file, Path.Combine(normalisedSource, index++ + ".jpg"));
            }

            return index - 1;
        }
    }
}