using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using rep_pattern_demo.Models;
using RepositoryWithMvc.Repository; // Replace with your actual namespace

namespace RepositoryWithMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(Models.EmployeeContext context)
        {
            _employeeRepository = new EmployeeRepository(context);
        }
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            
        }
        
    }
}
 
