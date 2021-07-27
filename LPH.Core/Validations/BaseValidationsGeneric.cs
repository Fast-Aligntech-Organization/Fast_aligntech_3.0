using System;
using System.Collections.Generic;
using System.Text;
using LPH.Core.Enumerations;
using LPH.Core.Interfaces;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Net;

namespace LPH.Core.Validations
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
