using Microsoft.EntityFrameworkCore;
using LPH.Core.Entities;

namespace LPH.Core.Interfaces
{
    public interface IDBContextModel
    {
        
        DbSet<User> Users { get; set; }
        DbSet<MuralOrder> MuralsOrder { get; set; }
        



    }
}
