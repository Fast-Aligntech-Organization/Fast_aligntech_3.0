using Fast.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fast.Core.Interfaces
{
    public interface IDBContextModel
    {

        DbSet<Usuario> Users { get; set; }
        DbSet<Orden> MuralsOrder { get; set; }




    }
}
