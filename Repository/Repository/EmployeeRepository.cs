using MVCConcepts_Learning.Models;
using Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee(){Id=1,EmployeeName="veerababu"},
                new Employee(){Id=2,EmployeeName="veeru"}
            };
        }
        public List<Employee> GetEmployeeById(int EmpId)
        {
            return _employees.Where(s => s.Id == EmpId).ToList();
        }
    }
}
