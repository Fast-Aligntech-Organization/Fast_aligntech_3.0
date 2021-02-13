using System;
using System.Collections.Generic;
using System.Text;
using LPH.Core.Interfaces;

namespace LPH.Core.Entities
{
   public class MuralOrder: IEntity
    {
        public int Id { get; set; }
        public float MuralHeigh { get; set; }
        public float MuralWidth { get; set; }
        public string MaterialsOfFence { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set;  }

    }
}
