using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null);

    }
}
