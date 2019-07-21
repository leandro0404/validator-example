using Exemplo.Validator.Interfaces;
using KellermanSoftware.CompareNetObjects;

namespace Exemplo.Validator.ValidatorProcesso.Fields
{
    public class ValidatorItemForo : IValidatorFieldCommand<Processo>
    {
        public string Name => nameof(Processo.ForoId);

        public ValidationItem Valid(Processo item, Difference diference)
        {
            if (item.ForoId == 1)
                return new ValidationItem(Name, "Erro ForoId");
            else
                return null;
        }
    }
}
