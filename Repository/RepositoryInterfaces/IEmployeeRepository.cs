using MVCConcepts_Learning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.RepositoryInterfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeById(int EmpId);
    }
}
