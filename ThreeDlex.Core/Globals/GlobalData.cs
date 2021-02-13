using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeDlex.Core.Entities;
using ThreeDlex.Core.Interfaces;

namespace ThreeDlex.Core.Globals
{
    public  class GlobalData:IGlobal
    {
        public string CurrentToken { get; set; }

        public  UserLogin CurrentLogin { get; set; }

        public  User CurrentUser { get; set; }

        public string CurrentUserImagePath { get; set; }

        public string ApiUri { get; set; } = @"https://ThreeDlex.azurewebsites.net";

    }
}
