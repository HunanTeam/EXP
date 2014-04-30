using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpApp.Core
{
    public class BusinessException : AppException
    {


        public BusinessException(string msg)
            : base(msg)
        {

        }

        public BusinessException(string msg, Exception e)
            : base(msg, e)
        {

        }
    }
}
