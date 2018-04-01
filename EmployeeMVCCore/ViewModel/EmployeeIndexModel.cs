using EmployeeMVCCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMVCCore.ViewModel
{
    public class EmployeeIndexModel

    {
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        [Required]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]

        public string LastName { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        public IEnumerable<Employee> Employee { get; set; }
       
    }


}

