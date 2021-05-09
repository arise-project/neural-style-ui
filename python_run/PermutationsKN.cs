using System.Collections.Generic;
using System.Linq;

namespace python_run
{
    public class PermutationsKN
    {
        public IEnumerable<NSParams> Generate(string [] files, NSParams copy)
        {
            var variants = GFG.permutations(files, files.Length, 2);
            foreach(var variant in variants)
            {
                var c = copy.Clone();
                c.ContentImage = variant[0];
                c.StyleImage = variant[1];
                yield return c;
            }
        }
    }
}