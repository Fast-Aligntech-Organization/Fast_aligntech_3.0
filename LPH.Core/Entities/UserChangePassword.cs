using LPH.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LPH.Core.Entities
{
    public class UserChangePassword 
    {
       

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
