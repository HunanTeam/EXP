﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpApp.Core.Infrastructure
{
    public interface IStartupTask
    {
        void Execute();

        int Order { get; }
    }
}