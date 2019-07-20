using System.Threading.Tasks;

namespace Exemplo.Validator.Interfaces
{
    public interface IValidatorCustom<T>
    {
        Task ValidateRules(T newItem, T oldItem, params string[] fieldsPayLoad);
    }
}
