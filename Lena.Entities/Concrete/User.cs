﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lena.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Lena.Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
    }
}
