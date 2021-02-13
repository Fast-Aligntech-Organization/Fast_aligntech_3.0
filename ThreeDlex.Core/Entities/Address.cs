using ThreeDlex.Core.Interfaces;
using System.Collections.Generic;

namespace ThreeDlex.Core.Entities
{
    public class Address : IEntity
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
            BotCustomers = new HashSet<BotCustomer>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string InteriorNumber { get; set; }
        public string ExteriorNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<BotCustomer> BotCustomers { get; set; }

    }
}
