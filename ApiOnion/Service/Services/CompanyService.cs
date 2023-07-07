using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Company;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service.Services
{
    public class CompanyService:ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepo, IMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CompanyCreateDto model)
        {
            await _companyRepo.CreateAsync(_mapper.Map<Company>(model));
        }

        public async Task DeleteAsync(int? id, CompanyDeleteDto model)
        {
            return _mapper.Map<CompanyDeleteDto>(await _companyRepo.DeleteAsync());
        }

        public async Task<List<CompanyDto>> GetAllAsync()
        {
            return _mapper.Map<List<CompanyDto>>(await _companyRepo.GetAllAsync());
        }

        public async Task GetByIdAsync(CompanyGetByIdDto model,int id)
        {
            Company company = await _companyRepo.GetByIdAsync(id);

            _mapper.Map(model, company);

            await _companyRepo.GetByIdAsync(id);
        }
        //public async Task Search(CompanySearchDto model)
        //{
        //    return _mapper.Map<CompanySearchDto>(await _companyRepo.SearchAsync(model));

    
        //}

        public async Task UpdateAsync(int? id, CompanyUpdateDto model)
        {
            Company company = await _companyRepo.GetByIdAsync(id);

            _mapper.Map(model, company);

            await _companyRepo.UpdateAsync(company);
            
        }
    }
}
