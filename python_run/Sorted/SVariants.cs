using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace python_run
{
    public class SVariants : IVariants
    {
        SortedStrategy config;
        public SVariants()
        {
            config = JsonSerializer.Deserialize<SortedStrategy>(File.ReadAllText("s_all_config.json"));
        }
        public IEnumerable<string> Generate()
        {
            return new ParamsBuilder().Build(config);
        }

        public string GetDestination()
        {
            return config.Storage.Destination;
        }
    }
}