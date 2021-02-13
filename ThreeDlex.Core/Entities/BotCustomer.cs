using System;
using System.Collections.Generic;
using System.Text;
using ThreeDlex.Core.Interfaces;

namespace ThreeDlex.Core.Entities
{

  public class BotCustomer:IEntity
    {



       

        public BotCustomer()
        {
            Orders = new HashSet<Order>();
        }
       
       
         
       

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? IdAddress { get; set; }
        public string Phone { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

            public string MessengerUserId        { get; set; }
            public string Gender                 { get; set; }
            public string ProfilePicUrl          { get; set; }
            public string TimeZone               { get; set; }
            public string Locale                 { get; set; }
            public string Source                 { get; set; }
            public string LastSeen               { get; set; }
            public string SignedUp               { get; set; }
            public string Sessions               { get; set; }
            public string LastVisitedBlockName   { get; set; }
            public string LastVisitedBlockId     { get; set; }
            public string LastClickedButtonName  { get; set; }
        

    }
}
