using _2WebApiData.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi2.Data.DbContexts;

namespace _2WebApiData.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        private readonly DbSet<T> _entitiySet;


        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }


        public async Task<T> CreateAsync(T entity)
        {
            var temp = (await _entitiySet.AddAsync(entity)).Entity;
            return temp;
        }

        public T Update(T entity)
            => _entitiySet.Update(entity).Entity;

        public async Task<int> SaveAsync()
           => await _dbContext.SaveChangesAsync();




        public void Add(T entity)
           => _dbContext.Add(entity);


        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _dbContext.AddAsync(entity, cancellationToken);


        public void AddRange(IEnumerable<T> entities)
            => _dbContext.AddRange(entities);


        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await _dbContext.AddRangeAsync(entities, cancellationToken);


        public T Get(Expression<Func<T, bool>> expression)
            => _entitiySet.FirstOrDefault(expression);


        public IEnumerable<T> GetAll()
            => _entitiySet.AsEnumerable();


        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
            => _entitiySet.Where(expression).AsEnumerable();


        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitiySet.ToListAsync(cancellationToken);


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.Where(expression).ToListAsync(cancellationToken);


        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken);



        public void Remove(T entity)
            => _dbContext.Remove(entity);


        public void RemoveRange(IEnumerable<T> entities)
            => _dbContext.RemoveRange(entities);

        IEnumerable<T> IRepository<T>.GetAll(Expression<Func<T>> expression)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
