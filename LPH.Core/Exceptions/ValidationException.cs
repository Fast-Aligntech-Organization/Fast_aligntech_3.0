using System;
using System.Collections.Generic;
using System.Text;
using LPH.Core.Interfaces;
using System.Net;
using LPH.Core.Validations;

namespace LPH.Core.Exceptions
{
    public class ValidationException:Exception
    {
        public ValidationException()
        {

        }

        public ValidationException(string message):base(message)
        {

        }

        public ValidationException(string message,Exception innerException) : base(message,innerException)
        {

        }

        public ValidationException(string message, IEnumerable<object> failValidator  ):base(message)
        {
            this.FailValidators = failValidator;
        }

        public ValidationException(IEnumerable<object> failValidator)
        {
            this.FailValidators = failValidator;
        }
        /// <summary>
        /// Todas las validaciones que al ejecutar no fueron aprovadas
        /// </summary>
        public IEnumerable<object> FailValidators { get; set; }

        
       





    }
}
