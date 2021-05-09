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

        public override string ToString()
        {
            var gpu = string.Join(",", Gpu);
            return $"-num_iterations {NumIterations} -style_image \"{StyleImage}\" -content_image \"{ContentImage}\" -output_image \"{OutputImage}\" -image_size {ImageSize} -gpu {gpu} -backend {Backend} -save_iter 0";
        }

        public NSParams Clone()
        {
            return new NSParams {
                Backend = Backend,
                Gpu = Gpu,
                ImageSize = ImageSize,
                NumIterations = NumIterations,
                OutputImage = OutputImage
            };
        }
    }
}