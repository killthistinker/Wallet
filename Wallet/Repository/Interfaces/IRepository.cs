using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wallet.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public void Create(T item);
        public void Update(T item);
        public void Remove(T item);
        public Task SaveAsync();
    }
}