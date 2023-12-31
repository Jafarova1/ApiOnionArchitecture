﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Task<Employee> GetByNameAsync(string name);
    }
}
