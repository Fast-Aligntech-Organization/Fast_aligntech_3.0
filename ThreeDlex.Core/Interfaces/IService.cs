using ThreeDlex.Core.Enumerations;
using System.Collections.Generic;

namespace ThreeDlex.Core.Interfaces
{
    public interface IService<TEntity>
    {

        IEnumerable<IValidator<TEntity>> Approbed { get; set; }

        IEnumerable<IValidator<TEntity>> Disapprobed { get; set; }

        IEnumerable<IValidator<TEntity>> Validators { get; }

        bool ExecuteAllValidator(TEntity entity, Operation operation, bool needValidation = true);

        void ClearResults();

        bool ExecuteCustomValidator(TEntity entity, IValidator<TEntity> validator, bool needValidation = true);


    }
}
