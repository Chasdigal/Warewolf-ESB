﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev2.Studio.Core.Account
{
    public interface IUserAccountProvider
    {
        string UserName { get; }
        string Password { get; }
    }
}
