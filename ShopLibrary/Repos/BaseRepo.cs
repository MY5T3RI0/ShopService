using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShopDAL.EF;
using ShopDAL.Models.Base;
using ShopDAL.Repos.Interfaces;
using System.Linq.Expressions;

namespace ShopDAL.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        private readonly DbSet<T> _table;
        private readonly ShopContext _db;
        protected ShopContext Context => _db;

        public BaseRepo() : this(new ShopContextFactory().CreateDbContext(null)) { }
        public BaseRepo(ShopContext context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
            _table = _db.Set<T>();
        }
        public void Dispose()
        {
            _db?.Dispose();
        }

        public int Add(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _table.Add(entity);
            return SaveChanges();
        }
        public async Task<int> AddAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _table.AddAsync(entity);
            return await SaveChangesAsync();
        }
        public int Add(IList<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _table.AddRange(entities);
            return SaveChanges();
        }
        public async Task<int> AddAsync(IList<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await _table.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }

        public int Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _table.Update(entity);
            return SaveChanges();
        }
        public async Task<int> UpdateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _table.Update(entity);
            return await SaveChangesAsync();
        }
        public int Update(IList<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _table.UpdateRange(entities);
            return SaveChanges();
        }
        public async Task<int> UpdateAsync(IList<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _table.UpdateRange(entities);
            return await SaveChangesAsync();
        }

        public int Delete(int id, byte[] timestamp)
        {
            _db.Entry(new T()
            { Id = id, Timestamp = timestamp }).State = EntityState.Deleted;
            return SaveChanges();
        }
        public async Task<int> DeleteAsync(int id, byte[] timestamp)
        {
            _db.Entry(new T()
            { Id = id, Timestamp = timestamp }).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }
        public int Delete(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public async Task<int> DeleteAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _db.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }
        public T GetOne(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _table.Find(id);
        }

        public async Task<T> GetOneAsync(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _table.FindAsync(id);
        }

        public virtual List<T> GetAll() => _table.ToList();
        public async Task<List<T>> GetAllAsync() => await _table.ToListAsync();

        public List<T> GetAll<TSortField>(Expression<Func<T, TSortField>>
        orderBy, bool ascending)
        {
            if (orderBy is null)
            {
                throw new ArgumentNullException(nameof(orderBy));
            }

            return (ascending ? _table.OrderBy(orderBy) :
        _table.OrderByDescending(orderBy)).ToList();
        }

        public async Task<List<T>> GetAllAsync<TSortField>(Expression<Func<T, TSortField>>
       orderBy, bool ascending)
        {
            if (orderBy is null)
            {
                throw new ArgumentNullException(nameof(orderBy));
            }

            return await (ascending ? _table.OrderBy(orderBy) :
       _table.OrderByDescending(orderBy)).ToListAsync();
        }

        public List<T> GetSome(Expression<Func<T, bool>> where)
        {
            if (where is null)
            {
                throw new ArgumentNullException(nameof(where));
            }

            return _table.Where(where).ToList();
        }

        public async Task<List<T>> GetSomeAsync(Expression<Func<T, bool>> where)
        {
            if (where is null)
            {
                throw new ArgumentNullException(nameof(where));
            }

            return await _table.Where(where).ToListAsync();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            if (where is null)
            {
                throw new ArgumentNullException(nameof(where));
            }

            return _table.Find(where);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> where)
        {
            if (where is null)
            {
                throw new ArgumentNullException(nameof(where));
            }

            return await _table.FindAsync(where);
        }

        internal int SaveChanges()
        {

            return _db.SaveChanges();
            // TODO: добавить обработку исключений
            #region ToDo
            //try
            //{
            //    return _db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    // Генерируется, когда возникла ошибка, связанная с параллелизмом.
            //    // Пока что просто сгенерировать исключение повторно,
            //    throw;
            //}
            //catch (RetryLimitExceededException ex)
            //{
            //    // Генерируется, когда достигнуто максимальное количество попыток.
            //    // Дополнительные детали можно найти во внутреннем исключении (исключениях) .
            //    // Пока что просто сгенерировать исключение повторно.
            //    throw;
            //}
            //catch (DbUpdateException ex)
            //{
            //    // Генерируется, когда обновление базы данных потерпело неудачу.
            //    // Дополнительные детали и затронутые объекты можно
            //    // найти во внутреннем исключении (исключениях).
            //    // Пока что просто сгенерировать исключение повторно,
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    // Возникло какое-то другое исключение, которое должно быть обработано,
            //    throw;
            //} 
            #endregion
        }

        internal async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
            // TODO: добавить обработку исключений
            #region ToDo
            //try
            //{
            //    return await _db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    // Генерируется, когда возникла ошибка, связанная с параллелизмом.
            //    // Пока что просто сгенерировать исключение повторно,
            //    throw;
            //}
            //catch (RetryLimitExceededException ex)
            //{
            //    // Генерируется, когда достигнуто максимальное количество попыток.
            //    // Дополнительные детали можно найти во внутреннем исключении (исключениях) .
            //    // Пока что просто сгенерировать исключение повторно.
            //    throw;
            //}
            //catch (DbUpdateException ex)
            //{
            //    // Генерируется, когда обновление базы данных потерпело неудачу.
            //    // Дополнительные детали и затронутые объекты можно
            //    // найти во внутреннем исключении (исключениях).
            //    // Пока что просто сгенерировать исключение повторно,
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    // Возникло какое-то другое исключение, которое должно быть обработано,
            //    throw;
            //}
            #endregion
        }

        public List<T> ExecuteQuery(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException($"\"{nameof(sql)}\" не может быть пустым или содержать только пробел.", nameof(sql));
            }

            _db.Database.ExecuteSqlRaw(sql);
            return _table.ToList();
        }
        public async Task<List<T>> ExecuteQueryAsync(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException($"\"{nameof(sql)}\" не может быть пустым или содержать только пробел.", nameof(sql));
            }

            await _db.Database.ExecuteSqlRawAsync(sql);
            return await _table.ToListAsync();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException($"\"{nameof(sql)}\" не может быть пустым или содержать только пробел.", nameof(sql));
            }

            _db.Database.ExecuteSqlRaw(sql, sqlParametersObjects);
            return _table.ToList();
        }
        public async Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                throw new ArgumentException($"\"{nameof(sql)}\" не может быть пустым или содержать только пробел.", nameof(sql));
            }

            await _db.Database.ExecuteSqlRawAsync(sql, sqlParametersObjects);
            return await _table.ToListAsync();
        }

        public virtual List<T> GetRelatedData() =>
            GetAll();

        public virtual async Task<List<T>> GetRelatedDataAsync() =>
            await GetAllAsync();

        public virtual T GetRelatedData(int id) =>
            Find(x => x.Id == id);

        public virtual async Task<T> GetRelatedDataAsync(int id) =>
            await FindAsync(x => x.Id == id);

        public List<T> Search(string property, string searchString) 
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                throw new ArgumentException($"\"{nameof(searchString)}\" не может быть пустым или содержать только пробел.", nameof(searchString));
            }

            var tableType = typeof(T);

            var tableName =  Context.GetTableName(tableType);

            return _table.FromSqlRaw($"SELECT * FROM {tableName} WHERE {property} LIKE '%{searchString}%'").ToList();
        }

        public async Task<List<T>> SearchAsync(string property, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                throw new ArgumentException($"\"{nameof(searchString)}\" не может быть пустым или содержать только пробел.", nameof(searchString));
            }

            var tableType = typeof(T);

            var tableName = Context.GetTableName(tableType);

            return await _table.FromSqlRaw($"SELECT * FROM {tableName} WHERE {property} LIKE '%{searchString}%'").ToListAsync();
        }
    }
}
