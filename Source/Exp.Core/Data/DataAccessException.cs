using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Core.Data
{
    public class DataAccessException : AppException
    {


        public DataAccessException(string msg)
            : base(msg)
        {

        }

        public DataAccessException(string msg, Exception e)
            : base(msg, e)
        {

        }
    }
}
