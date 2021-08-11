using System.Collections.Generic;
namespace python_run
{
    //https://www.a4-size.com/a4-size-in-pixels/
    public class A
    {
        public int Width {get;set;}
        public int Height {get;set;}
        public int Dpi {get;set;}

        public static Dictionary<string, A> _72DPI = new Dictionary<string, A>{
            { "A0",  new A { Width = 2384, Height = 3370, Dpi = 72 }},
            { "A1",  new A { Width = 1684, Height = 2384, Dpi = 72 }},
            { "A2",  new A { Width = 1191, Height = 1684, Dpi = 72 }},
            { "A3",  new A { Width = 842, Height = 1191, Dpi = 72 }},
            { "A4",  new A { Width = 595, Height = 842, Dpi = 72 }},
            { "A5",  new A { Width = 420, Height = 595, Dpi = 72 }},
            { "A6",  new A { Width = 298, Height = 420, Dpi = 72 }},
            { "A7",  new A { Width = 210, Height = 298, Dpi = 72 }},
            { "A8",  new A { Width = 147, Height = 210, Dpi = 72 }},
            { "A9",  new A { Width = 105, Height = 147, Dpi = 72 }},
            { "A10", new A { Width = 74, Height = 105, Dpi = 72 }},
        };

        public static Dictionary<string, A> _96DPI = new Dictionary<string, A>{
            { "A0",  new A { Width = 3179, Height = 4494, Dpi = 96 }},
            { "A1",  new A { Width = 2245, Height = 3179, Dpi = 96 }},
            { "A2",  new A { Width = 1587, Height = 2245, Dpi = 96 }},
            { "A3",  new A { Width = 1123, Height = 1587, Dpi = 96 }},
            { "A4",  new A { Width = 794, Height = 1123, Dpi = 96 }},
            { "A5",  new A { Width = 559, Height = 794, Dpi = 96 }},
            { "A6",  new A { Width = 397, Height = 559, Dpi = 96 }},
            { "A7",  new A { Width = 280, Height = 397, Dpi = 96 }},
            { "A8",  new A { Width = 197, Height = 280, Dpi = 96 }},
            { "A9",  new A { Width = 140, Height = 197, Dpi = 96 }},
            { "A10", new A { Width = 98, Height = 140, Dpi = 96 }},
        };

        public static Dictionary<string, A> _150DPI = new Dictionary<string, A>{
            { "A0",  new A { Width = 4967, Height = 7022, Dpi = 96 }},
            { "A1",  new A { Width = 3508, Height = 4967, Dpi = 96 }},
            { "A2",  new A { Width = 2480, Height = 3508, Dpi = 96 }},
            { "A3",  new A { Width = 1754, Height = 2480, Dpi = 96 }},
            { "A4",  new A { Width = 1240, Height = 1754, Dpi = 96 }},
            { "A5",  new A { Width = 874, Height = 1240, Dpi = 96 }},
            { "A6",  new A { Width = 620, Height = 874, Dpi = 96 }},
            { "A7",  new A { Width = 437, Height = 620, Dpi = 96 }},
            { "A8",  new A { Width = 307, Height = 437, Dpi = 96 }},
            { "A9",  new A { Width = 219, Height = 307, Dpi = 96 }},
            { "A10", new A { Width = 154, Height = 219, Dpi = 96 }},
        };

        public static Dictionary<string, A> _300DPI = new Dictionary<string, A>{
            { "A0",  new A { Width = 9933, Height = 14043, Dpi = 96 }},
            { "A1",  new A { Width = 7016, Height = 9933, Dpi = 96 }},
            { "A2",  new A { Width = 4961, Height = 7016, Dpi = 96 }},
            { "A3",  new A { Width = 3508, Height = 4961, Dpi = 96 }},
            { "A4",  new A { Width = 2480, Height = 3508, Dpi = 96 }},
            { "A5",  new A { Width = 1748, Height = 2480, Dpi = 96 }},
            { "A6",  new A { Width = 1240, Height = 1748, Dpi = 96 }},
            { "A7",  new A { Width = 874, Height = 1240, Dpi = 96 }},
            { "A8",  new A { Width = 614, Height = 874, Dpi = 96 }},
            { "A9",  new A { Width = 437, Height = 614, Dpi = 96 }},
            { "A10", new A { Width = 307, Height = 437, Dpi = 96 }},
        };

        public static A Get(string name, int dpi)
        {
            var etalon = _72DPI[name];
            return etalon;
        }
    }
}
