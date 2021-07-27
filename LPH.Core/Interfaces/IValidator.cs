using LPH.Core.Enumerations;
using System;
using Newtonsoft.Json;
using System.Net;
namespace LPH.Core.Interfaces
{
    public interface IValidator<TEntity>
    {
        Operation Operation { get; set; }

        [JsonIgnore]
        Func<TEntity, bool> Validation { get; }

        string ValidationString { get; set; }

        string Description { get; set; }

        bool IsValid { get; set; }

        HttpStatusCode StatusCode { get; set; }

    }
}
