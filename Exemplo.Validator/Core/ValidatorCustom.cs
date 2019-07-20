using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Exemplo.Validator.Interfaces;
using KellermanSoftware.CompareNetObjects;

namespace Exemplo.Validator.Core
{
    public abstract class ValidatorCustom<T>
    {
        private List<ValidationItem> _erros = new List<ValidationItem>();

        public void Execute(T newItem, T oldItem, string[] fieldsPayLoad, IEnumerable<IValidatorFieldCustom<T>> validators)
        {
            var changeFields = ListChangedFields(newItem, oldItem, fieldsPayLoad, validators);
            Erros(changeFields, newItem, validators);
        }

        public IEnumerable<Difference> ListChangedFields(T newItem, T oldItem, string[] fieldsPayLoad, IEnumerable<IValidatorFieldCustom<T>> validators)
        {
            var configComparador = new ComparisonConfig() { MaxDifferences = int.MaxValue };
            var compare = new CompareLogic(configComparador);
            var dif = compare.Compare(oldItem, newItem);
            return dif.Differences.Where(i =>
                fieldsPayLoad.Contains(i.PropertyName, StringComparer.OrdinalIgnoreCase)).ToList();
        }

        public void Erros(IEnumerable<Difference> changeFields, T newItem, IEnumerable<IValidatorFieldCustom<T>> _validators)
        {
            foreach (var field in changeFields)
            {
                var rule = _validators.FirstOrDefault(x => x.Name.Equals(field.PropertyName, StringComparison.InvariantCultureIgnoreCase));
                var result = rule?.Valid(newItem, field);
                if (result != null)
                {
                    _erros.Add(result);
                    Console.WriteLine(result.Message);
                }
            }
            if (_erros.Count > 0)
                throw new ValidationException(_erros.ToString());
        }
    }
}
