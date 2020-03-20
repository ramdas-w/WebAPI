using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        // GET: api/<controller>
        [HttpGet]
        public List<Employee> Get()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objemployee.GetAllEmployees().ToList();
            return lstEmployee;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee employee = objemployee.GetEmployeeData(id);
            return employee;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([Bind] Employee employee)
        {
            objemployee.AddEmployee(employee);
        }
        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, [Bind]Employee employee)
        {
            if (id != employee.ID)
            {
                objemployee.UpdateEmployee(employee);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objemployee.DeleteEmployee(id);
        }
    }
}
