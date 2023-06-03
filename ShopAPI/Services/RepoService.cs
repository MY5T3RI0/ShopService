using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using ShopDAL.EF;
using System.Linq.Expressions;
using ShopDAL.Models.Base;
using ShopDAL.Repos.Interfaces;
using ShopDAL.Models;

namespace ShopAPI.Services
{
    public class RepoService<T> : IRepoService<T> where T : EntityBase
    {
        public IRepo<T> _repo{ get; set; }

        public RepoService(IRepo<T> repo) =>
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));

        public void Dispose() => _repo.Dispose();

        public async Task<int> AddAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _repo.AddAsync(entity);
        }

        public async Task<int> AddAsync(IList<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            return await _repo.AddAsync(entities);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _repo.UpdateAsync(entity);
        }

        public async Task<int> UpdateAsync(IList<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            return await _repo.UpdateAsync(entities);
        }

        public async Task<int> DeleteAsync(int id, byte[] timestamp)
        {
            return await _repo.DeleteAsync(id, timestamp);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _repo.DeleteAsync(entity);
        }

        public async Task<T> GetOneAsync(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _repo.GetOneAsync(id);
        }

        public async Task<List<T>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<List<T>> GetAllAsync<TSortField>(Expression<Func<T, TSortField>>
       orderBy, bool ascending)
        {
            if (orderBy is null)
            {
                throw new ArgumentNullException(nameof(orderBy));
            }

            return await _repo.GetAllAsync(orderBy, ascending);
        }

        public async Task<List<T>> GetSomeAsync(Expression<Func<T, bool>> where)
        {
            if (where is null)
            {
                throw new ArgumentNullException(nameof(where));
            }

            return await _repo.GetSomeAsync(where);
        }

        public async Task<List<T>> ExecuteQueryAsync(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException($"\"{nameof(sql)}\" не может быть пустым или содержать только пробел.", nameof(sql));
            }

            return await _repo.ExecuteQueryAsync(sql);
        }

        public async Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException($"\"{nameof(sql)}\" не может быть пустым или содержать только пробел.", nameof(sql));
            }

            return await _repo.ExecuteQueryAsync(sql, sqlParametersObjects);
        }

        public virtual Task<List<T>> GetRelatedDataAsync() => _repo.GetRelatedDataAsync();
        public virtual Task<T> GetRelatedDataAsync(int id) => _repo.GetRelatedDataAsync(id);

        public async Task<List<T>> SearchAsync(string property, string searchstring) =>
            await _repo.SearchAsync(property, searchstring);
    }
}
