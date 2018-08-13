using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdataWebApp.Controllers
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
    }

    // see https://www.asp.net/web-api

    public class EmployeesController : ODataController
    {
        List<Employee> _employees = new List<Employee>
        {
            new Employee { ID = 1, Name = "Tom", PostCode = "4105" },
            new Employee { ID = 2, Name = "John", PostCode = "1234" },
            new Employee { ID = 3, Name = "Bert", PostCode = "4321" },
            new Employee { ID = 4, Name = "Andrew", PostCode = "9999" },
            new Employee { ID = 5, Name = "Quentin", PostCode = "7445" },
            new Employee { ID = 5, Name = "Crispin", PostCode = "0113" },
        };

        // Enable filtering in WebApiConfig !
        // GET /Employees?$filter=startswith(Name, 'Bert') eq true
        [EnableQuery]
        public IEnumerable<Employee> Get()
        {
            return _employees;
        }
    }
}