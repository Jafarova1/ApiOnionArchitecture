using Service.DTOs.Company;
using Service.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task CreateAsync(EmployeeCreateDto model);
        Task<List<EmployeeDto>> GetAllAsync();
        Task UpdateAsync(int? id, EmployeeUpdateDto model);
        Task DeleteAsync(int? id, EmployeeDeleteDto model);
        Task GetByIdAsync(EmployeeGetByIdDto model, int id);
    
    }
}
