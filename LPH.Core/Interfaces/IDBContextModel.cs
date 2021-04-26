using Microsoft.EntityFrameworkCore;
using LPH.Core.Entities;

namespace LPH.Core.Interfaces
{
    public interface IDBContextModel
    {
        
        DbSet<Usuario> Users { get; set; }
        DbSet<Orden> MuralsOrder { get; set; }
        



    }
}
