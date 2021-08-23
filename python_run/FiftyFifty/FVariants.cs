using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace python_run
{
    public class FVariants : IVariants
    {
        FiftyFiftyStrategy config;
        public FVariants()
        {
            config = JsonSerializer.Deserialize<FiftyFiftyStrategy>(File.ReadAllText("f_all_config.json"));
        }
        public IEnumerable<string> Generate()
        {
            bool stop = false;
            if (!string.IsNullOrEmpty(config.Storage.ContentSource))
            {
                var count = new NormaliseStorage().Execute(config.Storage.ContentSource, config.Storage.NormalizedSource + "/c/");
                Console.WriteLine("Prepared {0} content files", count);
                stop = true;
            }

            if (!string.IsNullOrEmpty(config.Storage.StyleSource))
            {
                var count = new NormaliseStorage().Execute(config.Storage.StyleSource, config.Storage.NormalizedSource + "/s/");
                Console.WriteLine("Prepared {0} style files", count);
                stop = true;
            }

            if(stop)
            {
                Environment.Exit(0);
            }

            return new ParamsBuilder().Build(config);
        }

        public string GetDestination()
        {
            return config.Storage.Destination;
        }
    }
}