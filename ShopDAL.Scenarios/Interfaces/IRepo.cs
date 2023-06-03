using System.Linq.Expressions;

namespace ShopDAL.Repos.Interfaces
{
    public interface IRepo<T>
    {
        void Dispose();
        int Add(T entity);
        Task<int> AddAsync(T entity);
        int Add(IList<T> entities);
        Task<int> AddAsync(IList<T> entities);
        int Update(T entity);
        Task<int> UpdateAsync(T entity);
        int Update(IList<T> entities);
        Task<int> UpdateAsync(IList<T> entities);
        int Delete(int id, byte[] timestamp);
        Task<int> DeleteAsync(int id, byte[] timestamp);
        int Delete(T entity);
        Task<int> DeleteAsync(T entity);
        T GetOne(int? id);
        Task<T> GetOneAsync(int? id);
        List<T> GetSome(Expression<Func<T, bool>> where);
        Task<List<T>> GetSomeAsync(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> where);
        Task<T> FindAsync(Expression<Func<T, bool>> where);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy,
        bool ascending);
        Task<List<T>> GetAllAsync<TSortField>(Expression<Func<T, TSortField>> orderBy,
        bool ascending);
        List<T> ExecuteQuery(string sql);
        Task<List<T>> ExecuteQueryAsync(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
        Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects);
        List<T> GetRelatedData();
        Task<List<T>> GetRelatedDataAsync();
        T GetRelatedData(int id);
        Task<T> GetRelatedDataAsync(int id);
        List<T> Search(string property, string searchString);
        Task<List<T>> SearchAsync(string property, string searchString);
    }
}
