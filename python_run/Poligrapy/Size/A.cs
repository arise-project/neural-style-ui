using System.Collections.Generic;
namespace python_run
{
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

        public static A Get(string name, int dpi)
        {
            var etalon = _72DPI[name];
            return etalon;
        }
    }
}
