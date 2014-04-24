using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core
{
    public class ComponentException : AppException
    {
        private string p;
        private Exception e;

        public ComponentException(string p, Exception e)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.e = e;
        }

        public ComponentException(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
    }
}
