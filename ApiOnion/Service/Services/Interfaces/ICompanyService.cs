using Service.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICompanyService
    {
        Task CreateAsync(CompanyCreateDto model);
        Task<List<CompanyDto>> GetAllAsync();
        Task UpdateAsync(int? id, CompanyUpdateDto model);
        Task DeleteAsync(int? id, CompanyDeleteDto model);
        Task GetByIdAsync(CompanyGetByIdDto model,int id);
        //Task Search(CompanySearchDto model);
    }
}
