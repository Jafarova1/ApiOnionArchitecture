using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ICompanyRepository:IRepository<Company>
    {
        Task<Company> GetByNameAsync(string name);
    }
}
