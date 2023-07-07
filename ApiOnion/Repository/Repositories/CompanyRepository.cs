using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CompanyRepository:Repository<Company>,ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<Company> GetByNameAsync(string name)
        {
            return await _context.Companies.FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower());
        }
    }
}
