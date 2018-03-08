using EmployeeMVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVCCore.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetallEmployee();
        void Create(Employee emp);
        void Edit(Employee emp);
        void Delete(int id);
        Employee FindById(int id);

    }
}
