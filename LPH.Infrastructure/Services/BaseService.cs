using LPH.Core.Enumerations;
using LPH.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
//using LPH.Core.Validations;

namespace LPH.Infrastructure.Services
{
    public class BaseService<TEntity> : IService<TEntity>
    {
        public IEnumerable<IValidator<TEntity>> Approbed { get; set; }
        public IEnumerable<IValidator<TEntity>> Disapprobed { get; set; }
        public IEnumerable<IValidator<TEntity>> Validators { get => _validators; }

        IEnumerable<IValidator<TEntity>> _validators;

        public BaseService()
        {

            _validators = GetValidators();

            Approbed = new List<IValidator<TEntity>>();
            Disapprobed = new List<IValidator<TEntity>>();
        }

        public BaseService(IList<IValidator<TEntity>> validators)
        {
            _validators = validators;

            Approbed = new List<IValidator<TEntity>>();
            Disapprobed = new List<IValidator<TEntity>>();

        }



        public virtual bool ExecuteAllValidator(TEntity entity, Operation operation, bool needValidation = true)
        {
            this.ClearResults();
            var validatorForThis = _validators.Where(v => v.Operation == operation || v.Operation == Operation.All);
            bool approved = true;


            foreach (var item in validatorForThis)
            {
                item.IsValid = item.Validation.Invoke(entity);

                if (item.IsValid)
                {
                    (Approbed as List<IValidator<TEntity>>).Add(item);
                }
                else
                {
                    (Disapprobed as List<IValidator<TEntity>>).Add(item);
                    approved = false;

                }
            }

            if (!needValidation)
            {
                ClearResults();
            }

            return approved;

        }

        public virtual void ClearResults()
        {
            Disapprobed.ToList().Clear();
            Approbed.ToList().Clear();
            foreach (var item in _validators)
            {
                item.IsValid = false;
            }

        }

        public virtual bool ExecuteCustomValidator(TEntity entity, IValidator<TEntity> validator, bool needValidation = true)
        {

            bool result = validator.Validation.Invoke(entity);
            if (result)
            {
                Approbed.ToList().Add(validator);
            }
            else
            {
                Disapprobed.ToList().Add(validator);
            }

            if (!needValidation)
            {
                ClearResults();
            }

            return result;

        }

        internal virtual IEnumerable<IValidator<TEntity>> GetValidators()
        {

            List<IValidator<TEntity>> valis = new List<IValidator<TEntity>>();

            var types = GetNamespacesInAssembly("LPH.Core.Validations");

            foreach (var item in types)
            {
                if (item.GetInterfaces().Contains(typeof(IValidator<TEntity>)))
                {
                    IValidator<TEntity> instance = (IValidator<TEntity>)Activator.CreateInstance(item);
                    valis.Add(instance);

                }
            }

            return valis;

        }

        private static IEnumerable<Type> GetNamespacesInAssembly(string namespaces)
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("LPH"));
            List<Type> types = new List<Type>();
            foreach (var item in assemblies)
            {
                foreach (var t in item.GetTypes())
                {
                    if (!string.IsNullOrEmpty(t.Namespace))
                    {
                        if (t.Namespace.Contains(namespaces))
                        {
                            types.Add(t);
                        }
                    }

                }
            }

            return types;




        }

    }
}
