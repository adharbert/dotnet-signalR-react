using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeManagement.Data;

namespace TimeManagement.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeProvider _employeeProvider;
        private readonly IEmployeeProcessor _employeeProcessor;

        public EmployeeController(IEmployeeProvider employeeProvider, IEmployeeProcessor employeeProcessor)
        {
            _employeeProvider = employeeProvider;
            _employeeProcessor = employeeProcessor;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeProvider.Get();
        }

        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return _employeeProvider.Get().Where(e => e.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            _employeeProcessor.Create(employee);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee employee)
        {
            employee.Id = id;
            _employeeProcessor.Update(employee);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeProcessor.Delete(id);
        }



    }
}