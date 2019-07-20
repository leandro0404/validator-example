using Exemplo.Validator.Interfaces;
using Exemplo.Validator.Services;
using KellermanSoftware.CompareNetObjects;

namespace Exemplo.Validator.ValidatorProcesso.Fields
{
    public class ValidatorItemVara : IValidatorFieldCustom<Processo>
    {
        public string Name => nameof(Processo.VaraId);

        private readonly IVaraService _varaService;

        public ValidatorItemVara(IVaraService varaService)
        {
            _varaService = varaService;
        }
        public ValidationItem Valid(Processo item, Difference diference)
        {
            var vara = _varaService.GetById(item.VaraId.Value);

            if (vara == default)
                return new ValidationItem(Name, string.Format("Vara não existe {0}", item.VaraId.Value));

            else
                return null;
        }
    }
}
