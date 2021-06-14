using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace python_run
{
    public class FiftyFifty
    {
        public List<NSParams> Generate(string[] dim1, string[] dim2, NSParams copy)
        {
            int count = dim1.Count() / dim2.Count();
            Console.WriteLine("style examples={2}", dim1.Count(), dim2.Count(), count);
            int index = 0;
            List<NSParams> result = new List<NSParams>();
            int index2 = 0;
            var d2 = dim2[index2];
            
            foreach(string d1 in dim1)
            {   
                    var c = copy.Clone();
                    c.ContentImage = d1;
                    c.StyleImage = d2;
                    var img = Path.GetFileNameWithoutExtension(d1) + "_" + Path.GetFileNameWithoutExtension(d2) + ".png";
                    c.OutputImage = img;
                    index++;
                    Console.WriteLine("{0} -- {1}", d1, d2);
                    if(index >= count)
                    {
                        Console.WriteLine("{0}x{1}", index, index2);
                        index = 0;
                        
                        index2++;
                        if(dim2.Length == index2)
                        {
                            index2 = 0;
                        }
                        d2 = dim2[index2];
                        
                    }
                    result.Add(c);
            }

            return result;
        }
    }
}