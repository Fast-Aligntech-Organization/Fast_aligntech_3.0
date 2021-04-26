using LPH.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LPH.Core.Interfaces
{
    public interface IGlobal
    {
        string CurrentToken { get; set; }

        UserLogin CurrentLogin { get; set; }

        Usuario CurrentUser { get; set; }

        string CurrentUserImagePath { get; set; }

        string ApiUri { get; set; } 

    }
}
