using System.Collections.Generic;
using System.IO;

namespace python_run
{
    public class Matrix
    {
        public IEnumerable<NSParams> Generate(IEnumerable<string> dim1, IEnumerable<string> dim2, NSParams copy)
        {
            foreach(string d1 in dim1)
            {
                foreach(string d2 in dim2)
                {
                    var c = copy.Clone();
                    c.ContentImage = d1;
                    c.StyleImage = d2;
                    var img = Path.GetFileNameWithoutExtension(d1) + "_" + Path.GetFileNameWithoutExtension(d2) + ".jpg";
                    c.OutputImage = img;
                    yield return c;
                }
            }
        }
    }
}