using Fast.Core.Enumerations;
using System.Collections.Generic;

namespace Fast.Core.Interfaces
{
    public interface IValidatorService<TEntity>
    {

        IEnumerable<IValidator<TEntity>> Approbed { get; set; }

        IEnumerable<IValidator<TEntity>> Disapprobed { get; set; }

        IEnumerable<IValidator<TEntity>> Validators { get; }

        bool Execute(TEntity entity, Operation operation, bool needValidation = true);

        void ClearResults();

        bool Execute(TEntity entity, IValidator<TEntity> validator, bool needValidation = true);


    }
}
