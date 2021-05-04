//python3 
//neural_style.py 

namespace python_run
{
    public class NSParams
    {
        public string StyleImage {get; set;} 
        public string ContentImage { get; set;} 
        public string OutputImage { get; set; } 
        public int [] Gpu { get; set; } 
        public string Backend { get; set; } 
        public int NumIterations { get; set; } 
        public int ImageSize { get; set; }
    }
}