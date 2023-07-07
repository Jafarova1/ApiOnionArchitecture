using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Company;
using Service.DTOs.Employee;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(EmployeeCreateDto model)
        {
            await _employeeRepo.CreateAsync(_mapper.Map<Employee>(model));
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return _mapper.Map<List<EmployeeDto>>(await _employeeRepo.GetAllAsync());
        }

        public async Task GetByIdAsync(EmployeeGetByIdDto model, int id)
        {

            Employee employee = await _employeeRepo.GetByIdAsync(id);

            _mapper.Map(model, employee);

            await _employeeRepo.GetByIdAsync(id);
        }

        public async Task  UpdateAsync(int? id, EmployeeUpdateDto model)
        {
            Employee employee = await _employeeRepo.GetByIdAsync(id);

            _mapper.Map(model, employee);

            await _employeeRepo.UpdateAsync(employee);
        }
        public async Task DeleteAsync(int? id, EmployeeDeleteDto model)
        {
            return _mapper.Map<EmployeeDeleteDto>(await _employeeRepo.DeleteAsync());
        }
    }
}
