using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core.Models
{
    public class Logs : BaseEntity
    {
        public DateTime InitPickCase { get; set; }

        public DateTime EndPickCase { get; set; }

        public string UserId { get; set; }

        public virtual PrivateUser User { get; set; }

        public string CaseType { get; set; }

        public string NumberCase { get; set; }

        public bool? IsProceda { get; set; }

        public bool? IsRTM { get; set; }

        public bool? wasConsult { get; set; }



    }
}
