using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<T> SearchAsync(T entity);
        Task<T> GetByIdAsync(int? id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
    }
}
