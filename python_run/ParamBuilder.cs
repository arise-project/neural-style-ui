using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace python_run
{
    public class ParamsBuilder
    {
        public IEnumerable<string> Build(PermutationStrategy strategy)
        {
            var files = Directory.GetFiles(strategy.Storage.NormalizedSource, "*.jpg", SearchOption.AllDirectories);

            var pairs = new PermutationsKN().Generate(files.ToArray(), strategy.ScriptArguments);

            foreach(var pair in pairs)
            {
                yield return pair.ToString();
            }
        }
    }
}