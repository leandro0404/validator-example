using System.Collections.Generic;
using System.Linq;

namespace Exemplo.Validator.Services
{
    public class VaraService : IVaraService
    {
        public Vara GetById(int Id)
        {
            return List().Where(x => x.Id == Id).FirstOrDefault();
        }

        IEnumerable<Vara> List()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new Vara { Id = i, Nome = string.Format("Vara - {0}", i) };
            }
        }
    }
}