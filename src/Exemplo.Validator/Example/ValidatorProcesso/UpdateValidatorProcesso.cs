using Exemplo.Validator.Core;
using Exemplo.Validator.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exemplo.Validator
{
    public class UpdateValidatorProcesso : ValidatorCustom<Processo>, IValidatorCustom<Processo>
    {
        private readonly IEnumerable<IValidatorFieldCustom<Processo>> _validators;

        public UpdateValidatorProcesso(IEnumerable<IValidatorFieldCustom<Processo>> validators)
        {
            _validators = validators;
        }
        public async Task ValidateRules(Processo newItem, Processo oldItem, params string[] fieldsPayLoad)
        {
            Execute(newItem, oldItem, fieldsPayLoad, _validators);
        }
    }
}
