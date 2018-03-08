using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMVCCore.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeMVCCore.Config;
using EmployeeMVCCore.ImplRepository;
using EmployeeMVCCore.Interfaces;

namespace EmployeeMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _dbcontext;

        public HomeController(IEmployeeRepository context)
        {

            this._dbcontext = context;
        }

        public IActionResult Index()
        {
            return View(_dbcontext.GetallEmployee());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);
            _dbcontext.Create(emp);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            Employee emp = _dbcontext.FindById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);
            _dbcontext.Edit(emp);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            _dbcontext.Delete(id);
            return RedirectToAction("Index");
        }


    }
}