using Fast.Core.Entities;

namespace Fast.Core.Interfaces
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
