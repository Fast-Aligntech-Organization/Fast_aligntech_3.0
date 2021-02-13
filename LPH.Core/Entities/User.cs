using System;
using System.Collections.Generic;
using System.Text;
using LPH.Core.Interfaces;
namespace LPH.Core.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public bool Suscribed { get; set; }

    }
}
