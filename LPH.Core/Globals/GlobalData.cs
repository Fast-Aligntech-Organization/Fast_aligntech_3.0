using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPH.Core.Entities;
using LPH.Core.Interfaces;

namespace LPH.Core.Globals
{
    public  class GlobalData:IGlobal
    {
        public string CurrentToken { get; set; }

        public  UserLogin CurrentLogin { get; set; }

        public  User CurrentUser { get; set; }

        public string CurrentUserImagePath { get; set; }

        public string ApiUri { get; set; } = @"https://LPH.azurewebsites.net";

    }
}
