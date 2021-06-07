using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace python_run
{
    public class FiftyFifty
    {
        public IEnumerable<NSParams> Generate(IEnumerable<string> dim1, IEnumerable<string> dim2, NSParams copy)
        {
            int count = dim1.Count() / dim2.Count();
            int index = 0;
            var enumerator = dim2.GetEnumerator();
            enumerator.MoveNext();
            var d2 = enumerator.Current;
            foreach(string d1 in dim1)
            {   
                    var c = copy.Clone();
                    c.ContentImage = d1;
                    c.StyleImage = d2;
                    var img = Path.GetFileNameWithoutExtension(d1) + "_" + Path.GetFileNameWithoutExtension(d2) + ".png";
                    c.OutputImage = img;
                    index++;
                    if(index >= count)
                    {
                        index = 0;
                        enumerator.MoveNext();
                        d2 = enumerator.Current;
                    }
                    yield return c;
            }
        }
    }
}