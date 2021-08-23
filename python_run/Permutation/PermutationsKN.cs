using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace python_run
{
    public class PermutationsKN
    {
        public IEnumerable<NSParams> Generate(string [] files, NSParams copy)
        {
            HashSet<string> check = new HashSet<string>();
            var variants = GFG.permutations(files, files.Length, 2);
            foreach(var variant in variants)
            {
                var c = copy.Clone();
                var img = Path.GetFileNameWithoutExtension(variant[0]) + "_" + Path.GetFileNameWithoutExtension(variant[1]) + ".jpg";
                if(variant[0] != variant[1] && !check.Contains(img))
                {
                    c.ContentImage = variant[0];
                    c.StyleImage = variant[1];
                    c.OutputImage = img;
                    check.Add(img);
                    yield return c;
                }
            }
        }
    }
} 