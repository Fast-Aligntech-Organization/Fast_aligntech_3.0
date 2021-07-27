using System;
using System.Collections.Generic;
using System.Text;
using LPH.Core.Enumerations;

namespace LPH.Core.Validations
{
   public class NotNullValidation<TEntity>:BaseValidationsGeneric<TEntity>
    {

        public NotNullValidation()
        {
            Operation = Operation.All;
            Description = $"La identidad es Null";
            ValidationString = "(o) => o != null";
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }

    }
}

