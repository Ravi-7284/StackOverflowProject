using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET: Employees
        [Authorize]
        public IEnumerable <Employee> Get()
        {
            using (EmployeeDBEntities Entities = new EmployeeDBEntities())
            {
                return Entities.Employees.ToList();
            }
        }
    }
}