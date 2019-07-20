using KellermanSoftware.CompareNetObjects;

namespace Exemplo.Validator.Interfaces
{
    public interface IValidatorFieldCustom<T>
    {
        string Name
        {
            get;
        }
        ValidationItem Valid(T item, Difference diference);
    }
}
