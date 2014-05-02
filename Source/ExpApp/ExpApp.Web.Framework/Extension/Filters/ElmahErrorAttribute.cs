﻿using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpApp.Web.Framework.Extension.Filters
{
    public class ElmahErrorAttribute : IExceptionFilter
	{
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
	}
}