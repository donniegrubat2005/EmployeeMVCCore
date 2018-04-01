using EmployeeMVCCore.Config;
using EmployeeMVCCore.Interfaces;
using EmployeeMVCCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMVCCore.ImplRepository
{
    public class EmployeeRepository : IEmployeeRepository
        {
        private readonly AppdbContext _context;

        public EmployeeRepository(AppdbContext context)
        {
            _context = context;
        }

        public void Create(Employee emp)
        {

           
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Employee emp = _context.Employees.Find(id);

            _context.Employees.Remove(emp);
            _context.SaveChanges();
        }

         public void Update(Employee emp)
        {
            _context.Employees.Update(emp);
            _context.SaveChanges();
        }

        public Employee FindById(Guid id)
        {
            var find = _context.Employees.Where(x => x.Id == id).SingleOrDefault();
            return find;
        }

        public IEnumerable<Employee> GetallEmployee()
        {
            return _context.Employees;
        }

      }


}
