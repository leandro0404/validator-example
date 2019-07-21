using KellermanSoftware.CompareNetObjects;

namespace Exemplo.Validator.Interfaces
{
    public interface IValidatorFieldCommand<T>
    {
        string Name
        {
            get;
        }
        ValidationItem Valid(T item, Difference diference);
    }
}
