using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpApp.Core
{
    public class ComponentException : AppException
    {
        public ComponentException(string msg)
            : base(msg)
        {

        }

        public ComponentException(string msg, Exception e)
            : base(msg, e)
        {

        }
    }
}
