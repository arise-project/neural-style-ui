using System;
using System.IO;
using System.Text.Json;

namespace python_run
{
    class Program
    {
        static int Main(string[] args)
        {
            System.Environment.SetEnvironmentVariable("NEURAL_STYLE_HOME", "/home/eugene/Projects/neural-style-pt/");
            var workDir = System.Environment.GetEnvironmentVariable("NEURAL_STYLE_HOME");
            if (string.IsNullOrWhiteSpace(workDir))
            {
                Console.WriteLine("Env NEURAL_STYLE_HOME is undefined");
                return -1;
            }

            if (!Directory.Exists(workDir))
            {
                Console.WriteLine("Env NEURAL_STYLE_HOME location not found");
                return -1;
            }

            var config = JsonSerializer.Deserialize<PermutationStrategy>(File.ReadAllText("all_config.json"));

            if (!string.IsNullOrEmpty(config.Storage.Source))
            {
                var count = new NormaliseStorage().Execute(config.Storage.Source, config.Storage.NormalizedSource);
                Console.WriteLine("Prepared {0} files", count);
                return 0;
            }

            var variants = new ParamsBuilder().Build(config);

            foreach (var variant in variants)
            {
                Console.WriteLine(variant.ToString());
                var res = new NeyralStyleRunnerPython().Execute(variant.ToString());
                if (res.Length == 2)
                {
                    if (!string.IsNullOrEmpty(res[1]))
                    {
                        Console.WriteLine("Error {0}", res[1]);
                    }
                    else
                    {
                        var result = Directory.GetFiles(workDir, "*.png", SearchOption.TopDirectoryOnly);
                        foreach (var r in result)
                        {
                            File.Move(r, Path.Combine(config.Storage.Destination, Path.GetFileName(r)));
                        }
                    }
                }
                break;
            }

            return 0;
        }
    }
}
