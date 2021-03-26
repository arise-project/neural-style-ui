using System;
using System.Diagnostics;

namespace conda_run
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = @"C:\w\neural-style-pt";
var process = new Process
{
    StartInfo = new ProcessStartInfo
    {
        FileName = "cmd.exe",
        RedirectStandardInput = true,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        WorkingDirectory = workingDirectory
    }
};
process.Start();
// Pass multiple commands to cmd.exe
using (var sw = process.StandardInput)
{
    if (sw.BaseStream.CanWrite)
    {
        // Vital to activate Anaconda
        sw.WriteLine(@"C:\ProgramData\Anaconda3\Scripts\activate.bat");
        // Activate your environment
        sw.WriteLine("activate");
        // Any other commands you want to run
        sw.WriteLine(@"'c:\Program Data\Anaconda3'");
        // run your script. You can also pass in arguments
        sw.WriteLine(@" python neural_style.py -style_image C:\p\1.jpg -content_image C:\p\10.jpg -image_size 2000 -num_iterations 200 -optimizer adam -backend cudnn");
    }
}

// read multiple output lines
while (!process.StandardOutput.EndOfStream)
{
    var line = process.StandardOutput.ReadLine();
    Console.WriteLine(line);
}
        }

        // Set working directory and create process

    }
}
