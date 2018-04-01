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
using EmployeeMVCCore.ViewModel;

namespace EmployeeMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _dbcontext;

        public HomeController(IEmployeeRepository context)
        {

            _dbcontext = context;
        }

        public IActionResult Index(string id)
        {

            //return View(_dbcontext.GetallEmployee());
            var empModels =
                (from emp in _dbcontext.GetallEmployee()
                     //where emp.Id == new Guid(id)
                 //where emp.FirstName.StartsWith("Donnie") || emp.FirstName == null
                 select emp
                //).AsQueryable();
                ).ToList();


            var empList = empModels
                .Select(res => new EmployeeIndexModel
                {
                    Id = res.Id
                    ,
                    FirstName = res.FirstName
                    ,
                    LastName = res.LastName
                    ,
                    Address = res.Address
                    
                }
                );

            //var empModel = new EmployeeIndexModel()
            //{
            //    Employee = empList
            //};

            return View(empList);

        }

        //public IActionResult GetActionResult()
        //{
        //    //return View(_dbcontext.GetallEmployee());
        //    var empModels =
        //        (from emp in _dbcontext.GetallEmployee()
        //             //where emp.Id == new Guid(id)
        //             where emp.FirstName.StartsWith("Donnie") || emp.FirstName == null
        //         select emp
        //        //).AsQueryable();
        //        ).ToList();


        //    var empList = empModels
        //        .Select(res => new EmployeeIndexModel
        //        {
        //            Id = res.Id
        //            ,
        //            FirstName = res.FirstName
        //            ,
        //            LastName = res.LastName
        //            ,
        //            Address = res.Address

        //        }
        //        );

        //    //var empModel = new EmployeeIndexModel()
        //    //{
        //    //    Employee = empList
        //    //};

        //    return View(empList);

        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateModel empModel)
        {
            //if (!ModelState.IsValid) return View(emp);
            //_dbcontext.Create(emp);
            //return RedirectToAction("Index");
            var emp = new Employee()
            {
                FirstName = empModel.FirstName
                ,
                LastName = empModel.LastName
                ,
                Address = empModel.Address
            };
            _dbcontext.Create(emp);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(Guid id)
        {
            //Employee emp = _dbcontext.FindById(id);
            //return View(emp);
            var emp = _dbcontext.FindById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeCreateModel empModel)
        {
            //if (!ModelState.IsValid) return View(emp);
            //_dbcontext.Edit(emp);
            //return RedirectToAction("Index");
            var emp = new Employee()
            {
                Id = empModel.Id
                ,
                FirstName = empModel.FirstName
                ,
                LastName = empModel.LastName
                ,
                Address = empModel.Address

            };
            _dbcontext.Update(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            //_dbcontext.Delete(id);
            //return RedirectToAction("Index");
            var emp = _dbcontext.FindById(id);
            _dbcontext.Delete(id);

            return RedirectToAction("Index");
        }
    }
}