using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace python_run
{
    class Program
    {
        static int Main(string[] args)
        {
            StrategyType t = StrategyType.Matrix;

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

            IEnumerable<string> variants = null;
            string dest = null;
            IVariants core = null;
            switch(t)
            {
                case StrategyType.Permutation:
                core = new PVariants();
                break;
                case StrategyType.Matrix:
                core = new MVariants();
                break;
                case StrategyType.FiftyFifty:
                core = new FVariants();
                break;
            }

            if(core == null)
            {
                Console.WriteLine("No data for startegy {0}", t);
                return 1;
            }

            variants = core.Generate();
            dest = core.GetDestination();
            
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
                            File.Move(r, Path.Combine(dest, Path.GetFileName(r)));
                        }
                    }
                }
                //break;
            }

            return 0;
        }
    }
}
