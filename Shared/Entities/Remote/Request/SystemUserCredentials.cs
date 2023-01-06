﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerifiedSeller.Shared.Entities.Remote.Request
{
    public class SystemUserCredentials
    {
        public virtual int Id { get; set; }
        public virtual string UserEmail { get; set; }
        public virtual string Password { get; set; }
        public virtual string ConfirmPassword { get; set; }
    }
}
