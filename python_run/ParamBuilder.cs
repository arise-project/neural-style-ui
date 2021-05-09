using System.Collections.Generic;
using System.IO;

namespace python_run
{
    public class ParamsBuilder
    {
        IEnumerable<string> Build(PermutationStrategy strategy)
        {
            var files = Directory.GetFiles(strategy.Storage.NormalizedSource, "*.jpg", SearchOption.AllDirectories);

            var pairs = new PermutationsKN().Generate(files, new NSParams(), 2);

            foreach(var pair in pairs)
            {
                yield return pair.ToString();
            }
        }
    }
}