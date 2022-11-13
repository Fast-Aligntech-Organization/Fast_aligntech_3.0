using System;
using System.Collections.Generic;
using System.Text;
using Fast.Core.Enumerations;
using Fast.Core.Interfaces;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Net;

namespace Fast.Core.Validations
{
    public class BaseValidationsGeneric<TEntity> :BaseValidation, IValidator<TEntity>
    {
       
        [JsonIgnore]
        public Func<TEntity, bool> Validation {
           get
            {
               return  CSharpScript.EvaluateAsync<Func<TEntity, bool>>(ValidationString, ScriptOptions.Default.AddReferences(typeof(TEntity).Assembly).WithImports(new []{
                   "System",
                   "System.Collections.Generic",
                   "System.Text",
               })).Result;
            } 
            }

      
    }
}
