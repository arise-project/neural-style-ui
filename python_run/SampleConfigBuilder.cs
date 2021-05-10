using System.IO;
using System.Text.Json;

namespace python_run
{
    public class SampleConfigBuilder
    {
        public void Save()
        {
            var config = new PermutationStrategy
            {
                Runner = new StartParams {
                    Runner = "python3",
                    Script = "neural_style.py"
                },
                ScriptArguments = new NSParams{
                    OutputImage = "test.png",
                    ImageSize = 800,
                    Gpu = new int [] { 0 },
                    Backend = "cudnn",
                    NumIterations = 800
                },
                Storage = new PStorageParams {
                    Source = "/home/eugene/Pictures/2/",
                    NormalizedSource = "/home/eugene/Pictures/norm/",
                    Destination = "/home/eugene/Pictures/grid/"
                }
            };
           var jsonStr = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
           File.WriteAllText("sample_config.json", jsonStr);
        }
    }
}