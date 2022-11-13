using Fast.Core.Entities;
using Fast.Core.Interfaces;

namespace Fast.Core.Globals
{
    public class GlobalData : IGlobal
    {
        public string CurrentToken { get; set; }

        public UserLogin CurrentLogin { get; set; }

        public Usuario CurrentUser { get; set; }

        public string CurrentUserImagePath { get; set; }

        public string ApiUri { get; set; } = @"https://Fast.azurewebsites.net";

    }
}
