using System.IO;
using System.Text.Json;

namespace python_run
{
    public class SampleConfigBuilder
    {
        public void SaveP()
        {
            var config = new FiftyFiftyStrategy
            {
                Runner = new StartParams {
                    Runner = "python3",
                    Script = "neural_style.py"
                },
                ScriptArguments = new NSParams{
                    OutputImage = "test.jpg",
                    ImageSize = 800,
                    Gpu = new int [] { 0,1 },
                    MultideviceStrategy = new int [] { 6 },
                    Backend = "cudnn",
                    NumIterations = 800
                },
                Storage = new FStorageParams {
                    ContentSource = "/home/eugene/Pictures/2/",
                    StyleSource = "/home/eugene/Pictures/2/",
                    NormalizedSource = "/home/eugene/Pictures/norm/",
                    Destination = "/home/eugene/Pictures/grid/"
                }
            };
           var jsonStr = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
           File.WriteAllText("f_sample_config.json", jsonStr);
        }
        

        public void SaveM()
        {
            var config = new MatrixStrategy
            {
                Runner = new StartParams {
                    Runner = "python3",
                    Script = "neural_style.py"
                },
                ScriptArguments = new NSParams{
                    OutputImage = "test.jpg",
                    ImageSize = 800,
                    Gpu = new int [] { 0 },
                    Backend = "cudnn",
                    NumIterations = 800
                },
                Storage = new MStorageParams {
                    ContentSource = "/home/eugene/Pictures/p1/c/",
                    StyleSource = "/home/eugene/Pictures/p1/s/",
                    NormalizedSource = "/home/eugene/Pictures/norm/",
                    Destination = "/home/eugene/Pictures/grid/"
                }
            };
           var jsonStr = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
           File.WriteAllText("m_sample_config.json", jsonStr);
        }
    }
}