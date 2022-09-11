using InvoiceSystem.DOMAIN.Interfaces.CommonCRUD;
using InvoiceSystem.DOMAIN.Utilities.CommonCRUD;
using InvoiceSystem.INFRASTRUCTURE.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InvoiceSystem.INFRASTRUCTURE.Repositories
{
    public class NPRepository<T, ID> : INPRepository<T, ID> where T : class
    {
        private readonly IServiceProvider _serviceProvider;

        public NPRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public long Count()
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            return context?.Set<T>().LongCount() ?? 0;
        }

        public Task<long> CountAsync()
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) return Task.FromResult<long>(0);
            return context.Set<T>().LongCountAsync();
        }

        public int Delete(T entity)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            context?.Set<T>().Remove(entity);
            return context?.SaveChanges() ?? 0;
        }

        public int DeleteAll()
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            return context?.Set<T>().DeleteFromQuery() ?? 0;
        }

        public int DeleteAll(IEnumerable<T> entities)
        {
            int affectedRows = 0;
            foreach (T entity in entities)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                context?.Set<T>().Remove(entity);
                affectedRows += context?.SaveChanges() ?? 0;
            }
            return affectedRows;
        }

        public Task<int> DeleteAllAsync()
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) return Task.FromResult(0);
            return context.Set<T>().DeleteFromQueryAsync();
        }

        public async Task<int> DeleteAllAsync(IEnumerable<T> entities)
        {
            int affectedRows = 0;
            foreach (T entity in entities)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                context?.Set<T>().Remove(entity);
                if (context == null) return 0;
                affectedRows += await context.SaveChangesAsync();
            }
            return affectedRows;
        }

        public int DeleteAllById(IEnumerable<ID> ids)
        {
            int affectedRows = 0;
            foreach (ID id in ids)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                T? t = context?.Set<T>().Find(id);
                if (t != null) context?.Remove(t);
                affectedRows += context?.SaveChanges() ?? 0;
            }
            return affectedRows;
        }

        public async Task<int> DeleteAllByIdAsync(IEnumerable<ID> ids)
        {
            int affectedRows = 0;
            foreach (ID id in ids)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                if (context != null)
                {
                    T? t = await context.Set<T>().FindAsync(id);
                    if (t != null) context?.Remove(t);
                    affectedRows += await context!.SaveChangesAsync(); ;
                }
            }
            return affectedRows;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            context?.Set<T>().Remove(entity);
            if (context == null) return 0;
            return await context.SaveChangesAsync();
        }

        public int DeleteById(ID id)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            T? t = context?.Set<T>().Find(id);
            if (t != null) context?.Remove(t);
            return context?.SaveChanges() ?? 0;
        }

        public async Task<int> DeleteByIdAsync(ID id)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            int affectedRows = 0;
            if (context != null)
            {
                T? t = await context.Set<T>().FindAsync(id);
                if (t != null) context?.Remove(t);
                affectedRows += await context!.SaveChangesAsync();
            }
            return affectedRows;
        }

        public bool ExistsById(ID id)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            return context?.Set<T>().Find(id) != null;

        }

        public async Task<bool> ExistsByIdAsync(ID id)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) return false;
            T? t = await context.Set<T>().FindAsync(id);
            return t != null;
        }

        public IPage<T> FindAll(IPageable pageable)
        {
            // Get the offset and page size.
            int skip = Convert.ToInt32(pageable.GetOffset());
            int pageSize = pageable.GetPageSize();
            // Define the database context.
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
            List<T> data = new();
            // Get sort from pageable.
            if (pageable.GetSort().IsSorted())
            {
                Sort sort = pageable.GetSort();
                List<Order> orders = sort.GetOrders();
                DbSet<T> set = context.Set<T>();
                foreach (Order order in orders)
                {
                    if (order.IsAscending())
                    {
                        set.OrderBy(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                    else
                    {
                        set.OrderByDescending(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                }
                data.AddRange(set.Skip(skip).Take(pageSize).ToList());
            }
            else
            {
                data.AddRange(context.Set<T>().Skip(skip).Take(pageSize).ToList());
            }
            return new Page<T>(data, pageable, Count());
        }

        public IEnumerable<T> FindAll()
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            return context?.Set<T>().ToList() ?? new();
        }

        public async Task<IPage<T>> FindAllAsync(IPageable pageable)
        {
            // Get the offset and page size.
            int skip = Convert.ToInt32(pageable.GetOffset());
            int pageSize = pageable.GetPageSize();
            // Define the database context.
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
            List<T> data = new();
            // Get sort from pageable.
            if (pageable.GetSort().IsSorted())
            {
                Sort sort = pageable.GetSort();
                List<Order> orders = sort.GetOrders();
                DbSet<T> set = context.Set<T>();
                foreach (Order order in orders)
                {
                    if (order.IsAscending())
                    {
                        set.OrderBy(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                    else
                    {
                        set.OrderByDescending(t => t.GetType().GetProperty(order.GetProperty()));
                    }
                }
                data.AddRange(await set.Skip(skip).Take(pageSize).ToListAsync());
            }
            else
            {
                data.AddRange(await context.Set<T>().Skip(skip).Take(pageSize).ToListAsync());
            }
            return new Page<T>(data, pageable, await CountAsync());
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAllById(IEnumerable<ID> ids)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
            return context.Set<T>().AsEnumerable().Where(t =>
            {
                PropertyInfo property = t.GetType().GetProperties().First(prop =>
                {
                    return prop.PropertyType == ids.First()!.GetType() || prop.Name.Equals("Id");
                });
                return ids.Contains((ID?)property.GetValue(t, null));
            }).ToList();
        }

        //public Task<IEnumerable<T>> FindAllByIdAsync(IEnumerable<ID> ids)
        //{
        //    //using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
        //    //if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
        //    //return context.Set<T>().AsEnumerable().Where(t =>
        //    //{
        //    //    PropertyInfo property = t.GetType().GetProperties().First(prop =>
        //    //    {
        //    //        return prop.PropertyType == ids.First()!.GetType() || prop.Name.Equals("Id");
        //    //    });
        //    //    return ids.Contains((ID?)property.GetValue(t, null));
        //    //}).ToList();
        //    throw new NotImplementedException();
        //}

        public T? FindById(ID id)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            return context?.Set<T>().Find(id);
        }

        public ValueTask<T?> FindByIdAsync(ID id)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
            return context.Set<T>().FindAsync(id);
        }

        public T Save(T entity)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            T saved = context?.Set<T>().Add(entity).Entity ?? entity;
            context?.SaveChanges();
            return saved;
        }

        public IEnumerable<T> SaveAll(IEnumerable<T> entities)
        {
            List<T> saved = new();
            foreach (T entity in entities)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                T t = context?.Set<T>().Add(entity).Entity ?? entity;
                context?.SaveChanges();
                saved.Add(t);
            }
            return saved;
        }

        public async Task<IEnumerable<T>> SaveAllAsync(IEnumerable<T> entities)
        {
            List<T> saved = new();
            foreach (T entity in entities)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
                T t = (await context.Set<T>().AddAsync(entity)).Entity;
                _ = await context.SaveChangesAsync();
                saved.Add(t);
            }
            return saved;
        }

        public async ValueTask<T> SaveAsync(T entity)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
            T saved = (await context.Set<T>().AddAsync(entity)).Entity;
            await context.SaveChangesAsync();
            return saved;
        }

        public T Update(T entity)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            T updated = context?.Set<T>().Update(entity).Entity ?? entity;
            context?.SaveChanges();
            return updated;
        }

        public IEnumerable<T> UpdateAll(IEnumerable<T> entities)
        {
            List<T> updated = new();
            foreach (T entity in entities)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
                T t = context.Set<T>().Update(entity).Entity;
                context.SaveChanges();
                updated.Add(t);
            }
            return updated;
        }

        public async Task<IEnumerable<T>> UpdateAllAsync(IEnumerable<T> entities)
        {
            List<T> updated = new();
            foreach (T entity in entities)
            {
                using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
                if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
                T t = context.Set<T>().Update(entity).Entity;
                await context.SaveChangesAsync();
                updated.Add(t);
            }
            return updated;
        }

        public async ValueTask<T> UpdateAsync(T entity)
        {
            using PostgreSQLContext? context = _serviceProvider.GetService<PostgreSQLContext>();
            if (context == null) throw new ArgumentNullException(nameof(context), "The database context is null");
            T updated = context.Set<T>().Update(entity).Entity;
            await context.SaveChangesAsync();
            return updated;
        }
    }
}
