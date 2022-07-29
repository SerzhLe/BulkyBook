using System.Linq.Expressions;

namespace BulkyBookDataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingleOrDefault(Expression<Func<T, bool>> condition);

        void Create(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entity);
    }
}
