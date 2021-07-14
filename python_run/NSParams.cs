//python3 
//neural_style.py 
using System;

namespace python_run
{
    public class NSParams
    {
        public string StyleImage {get; set;} 
        public string ContentImage { get; set;} 
        public string OutputImage { get; set; } 
        public string Optimizer { get; set; } 
        public int [] Gpu { get; set; } 
        public int [] MultideviceStrategy { get;set; }
        public string Backend { get; set; } 
        public int NumIterations { get; set; } 
        public int ImageSize { get; set; }
        public float? StyleScale { get; set; }
        public float? StyleWeight { get; set; }
        public float? TvWeight { get; set; }
        public float? ContentWeight { get; set; }
        
        public bool? NormalizeGradients { get;set; }
        public bool? OriginalColors { get;set; }
        public bool? CudnnAutotune { get;set; }


        public override string ToString()
        {
            var gpu = string.Join(",", Gpu);
            var args = $"-num_iterations {NumIterations} -style_image \"{StyleImage}\" -content_image \"{ContentImage}\" -output_image \"{OutputImage}\" -image_size {ImageSize} -gpu {gpu} -backend {Backend} -save_iter 0";
            Console.WriteLine(MultideviceStrategy != null);
            
            if(MultideviceStrategy?.Length > 0)
            {
                args += $" -multidevice_strategy {string.Join(",", MultideviceStrategy)}";
            }

            if(StyleScale.HasValue)
            {
                args += $" -style_scale {StyleScale}";
            }

            if(StyleWeight.HasValue)
            {
                args += $" -style_weight {StyleWeight}";
            }

            if(TvWeight.HasValue)
            {
                args += $" -tv_weight {TvWeight}";
            }

            if(ContentWeight.HasValue)
            {
                args += $" -content_weight {ContentWeight}";
            }

            if(NormalizeGradients == true)
            {
                args += $" -normalize_gradients";
            }

            if(OriginalColors == true)
            {
                args += $" -original_colors";
            }

            if(CudnnAutotune == true)
            {
                args += $" -cudnn_autotune";
            }

            if(!string.IsNullOrEmpty(Optimizer))
            {
                args += $" -optimizer {Optimizer}";
            }

            return args;
        }

        public NSParams Clone()
        {
            return new NSParams {
                Backend = Backend,
                Gpu = Gpu,
                ImageSize = ImageSize,
                NumIterations = NumIterations,
                OutputImage = OutputImage,
                MultideviceStrategy = MultideviceStrategy,
                StyleScale = StyleScale,
                StyleWeight = StyleWeight,
                TvWeight = TvWeight,
                NormalizeGradients = NormalizeGradients,
                OriginalColors = OriginalColors,
                CudnnAutotune = CudnnAutotune,
                ContentWeight = ContentWeight,
                Optimizer = Optimizer
            };
        }
    }
}