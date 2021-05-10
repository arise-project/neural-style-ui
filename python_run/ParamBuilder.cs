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

        public IEnumerable<string> Build(MatrixStrategy strategy)
        {
            var c_files = Directory.GetFiles(strategy.Storage.NormalizedSource + "/c/", "*.jpg", SearchOption.AllDirectories);

            var s_files = Directory.GetFiles(strategy.Storage.NormalizedSource + "/s/", "*.jpg", SearchOption.AllDirectories);

            var pairs = new Matrix().Generate(c_files, s_files, strategy.ScriptArguments);

            foreach(var pair in pairs)
            {
                yield return pair.ToString();
            }
        }
    }
}