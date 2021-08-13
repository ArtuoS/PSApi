﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierAPI.Models.Interfaces
{
    public interface IUtilities
    {
        string GetDefaultUri();
        bool IsIdValid(int? id);
    }
}
