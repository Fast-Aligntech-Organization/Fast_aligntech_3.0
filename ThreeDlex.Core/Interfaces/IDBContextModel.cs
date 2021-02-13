using Microsoft.EntityFrameworkCore;
using ThreeDlex.Core.Entities;

namespace ThreeDlex.Core.Interfaces
{
    public interface IDBContextModel
    {
        DbSet<Address> Address { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Catalog> Catalogs { get; set; }
        DbSet<CatalogsProducts> CatalogsProducts { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<LogsTools> LogsTools { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Tool> Tools { get; set; }
        DbSet<BotCustomer> BotCustomers { get; set; }



    }
}
