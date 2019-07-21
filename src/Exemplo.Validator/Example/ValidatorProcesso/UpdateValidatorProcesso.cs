using Exemplo.Validator.Core;
using Exemplo.Validator.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exemplo.Validator
{
    public class UpdateValidatorProcesso : ValidatorCommand<Processo>, IValidatorCommand<Processo>
    {
        private readonly IEnumerable<IValidatorFieldCommand<Processo>> _validators;

        public UpdateValidatorProcesso(IEnumerable<IValidatorFieldCommand<Processo>> validators)
        {
            _validators = validators;
        }
        public async Task ValidateRules(Processo newItem, Processo oldItem, params string[] fieldsPayLoad)
        {
            Execute(newItem, oldItem, fieldsPayLoad, _validators);
        }
    }
}
