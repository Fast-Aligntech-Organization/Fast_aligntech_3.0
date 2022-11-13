using System;
using System.Collections.Generic;
using System.Text;
using Fast.Core.Enumerations;

namespace Fast.Core.Validations
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

