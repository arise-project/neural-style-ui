using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace python_run
{
    public class PVariants
    {
        public IEnumerable<string> Generate()
        {
            var config = JsonSerializer.Deserialize<PermutationStrategy>(File.ReadAllText("p_all_config.json"));

            if (!string.IsNullOrEmpty(config.Storage.Source))
            {
                var count = new NormaliseStorage().Execute(config.Storage.Source, config.Storage.NormalizedSource);
                Console.WriteLine("Prepared {0} files", count);
                Environment.Exit(0);
            }

            return new ParamsBuilder().Build(config);
        }
    }
}