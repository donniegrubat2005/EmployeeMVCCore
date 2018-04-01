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
        void Update(Employee emp);
        void Delete(Guid id);
        Employee FindById(Guid id);

    }
}
