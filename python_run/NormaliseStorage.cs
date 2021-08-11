using System.IO;
using python_run.Poligragy;

namespace python_run
{
    public class NormaliseStorage
    {
        public int Execute(string source, string normalisedSource)
        {
            var files = Directory.GetFiles(source, "*.jpg", SearchOption.AllDirectories);
            int index = 1;
            var ic = new ImageCanva();
            foreach(var file in files)
            {
                var fileName = Path.Combine(normalisedSource, index++ + ".jpg");
                File.Copy(file, fileName);
                ic.Add(fileName);
            }

            return index - 1;
        }
    }
}