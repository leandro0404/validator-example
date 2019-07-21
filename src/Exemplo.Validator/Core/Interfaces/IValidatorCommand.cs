using Exemplo.Validator.Core;
using System.Threading.Tasks;

namespace Exemplo.Validator.Interfaces
{
    public interface IValidatorCommand<T>
    {
        Task ValidateRules(T newItem, T oldItem, params string[] fieldsPayLoad);
    }
}
