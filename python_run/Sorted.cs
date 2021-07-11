using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace python_run
{
    public class Sorted
    {
        public List<NSParams> Generate(string[] dim1, string[] dim2, string [] sorted, NSParams copy)
        {
            List<NSParams> result = new List<NSParams>();

            foreach(var s in sorted)
            {
                var select = Path.GetFileNameWithoutExtension(s).Split('_');
                var c = copy.Clone();
                c.ContentImage = dim1.First(d => Path.GetFileNameWithoutExtension(d) == select[0]);
                c.StyleImage = dim2.First(d => Path.GetFileNameWithoutExtension(d) == select[1]);
                var img = Path.GetFileNameWithoutExtension(s) + ".jpg";
                c.OutputImage = img;

                Console.WriteLine("{0} -- {1}", c.ContentImage, c.StyleImage);
                result.Add(c);
            }

            return result;
        }
    }
}