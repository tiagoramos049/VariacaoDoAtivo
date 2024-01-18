using VariacaoDoAtivo.Models;

namespace VariacaoDoAtivo.Interfaces
{
    public interface IVariacao
    {
        public void Insert(Meta meta);
        public IEnumerable<Meta> GetAll();
    }
}
