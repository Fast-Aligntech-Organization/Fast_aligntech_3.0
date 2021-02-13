using ThreeDlex.Core.Enumerations;
using System;
namespace ThreeDlex.Core.Interfaces
{
    public interface IValidator<TEntity>
    {
        Operation Operation { get; set; }

        Func<TEntity, bool> Validation { get; set; }

        string Description { get; set; }

        bool IsValid { get; set; }

    }
}
