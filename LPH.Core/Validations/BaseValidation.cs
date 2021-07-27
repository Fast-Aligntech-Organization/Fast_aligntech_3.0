using LPH.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LPH.Core.Validations
{
   public class BaseValidation
    {
        public Operation Operation { get; set; }

        public string Description { get; set; }
        public bool IsValid { get; set; }
        public string ValidationString { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
