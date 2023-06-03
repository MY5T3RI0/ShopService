using ShopDAL.Models.Base;
using System.Linq.Expressions;

namespace ShopAPI.Services
{
    public interface IRepoService<T> where T : EntityBase
    {
        void Dispose();
        Task<int> AddAsync(T entity);
        Task<int> AddAsync(IList<T> entities);
        Task<int> UpdateAsync(T entity);
        Task<int> UpdateAsync(IList<T> entities);
        Task<int> DeleteAsync(int id, byte[] timestamp);
        Task<int> DeleteAsync(T entity);
        Task<T> GetOneAsync(int? id);
        Task<List<T>> GetSomeAsync(Expression<Func<T, bool>> where);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync<TSortField>(Expression<Func<T, TSortField>> orderBy,
        bool ascending);
        Task<List<T>> ExecuteQueryAsync(string sql);
        Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects);
        Task<List<T>> GetRelatedDataAsync();
        Task<T> GetRelatedDataAsync(int id);
        Task<List<T>> SearchAsync(string property, string searchString);
    }
}
