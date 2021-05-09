using System;
using System.IO;
using System.Text.Json;

namespace python_run
{
    class Program
    {
        static int Main(string[] args)
        {
            if (string.IsNullOrWhiteSpace(System.Environment.GetEnvironmentVariable("NEURAL_STYLE_HOME")))
            {
                System.Environment.SetEnvironmentVariable("NEURAL_STYLE_HOME", "/home/eugene/Projects/neural-style-pt/");
                // Console.WriteLine("Env NEURAL_STYLE_HOME is undefined");
                // return -1;
            }

            if (!Directory.Exists(System.Environment.GetEnvironmentVariable("NEURAL_STYLE_HOME")))
            {
                Console.WriteLine("Env NEURAL_STYLE_HOME location not found");
                return -1;
            }

            var config = JsonSerializer.Deserialize<PermutationStrategy>(File.ReadAllText("all_config.json"));

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
                }
                break;
            }

            return 0;
        }
    }
}
