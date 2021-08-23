using System.Collections.Generic;

namespace python_run
{
    public interface IVariants
    {
        public IEnumerable<string> Generate ();

        public string GetDestination();
    }
}