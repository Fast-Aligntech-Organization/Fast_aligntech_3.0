using LPH.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LPH.Core.Interfaces
{
    public interface IDBContextModel
    {

        DbSet<Usuario> Users { get; set; }
        DbSet<Orden> MuralsOrder { get; set; }




    }
}
