﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudscribe.Core.Models
{
    public interface IDataPlatformInfo
    {
        string DBPlatform { get; }
    }
}
