using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WCFvsWebAPI.Domain.Entities;
using WCFvsWebAPI.Domain.Interfaces.Service;

namespace WCFvsWebAPI.Service.WebAPI.Controllers
{
    [RoutePrefix("employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <remarks>Get all employees registered on application</remarks>
        /// <response code="200">Ok</response>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Employee>))]
        public OkNegotiatedContentResult<IEnumerable<Employee>> Get()
        {
            return Ok(_employeeService.GetAll());
        }
        /// <summary>
        /// Get employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <remarks>Get employee by id registered on application</remarks>
        /// <response code="200">Ok</response>
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Employee))]
        public OkNegotiatedContentResult<Employee> Get(int id)
        {
            return Ok(_employeeService.GetById(id));
        }

        /// <summary>
        /// Register a new employee on application
        /// </summary>
        /// <param name="employee">New employee to register</param>
        /// <remarks>Adds new employee to application</remarks>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Ok(_employeeService.Add(employee));
            }

            return BadRequest();
        }

        /// <summary>
        /// Edit application employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="employee">Employee to edit</param>
        /// <remarks>Update employee</remarks>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        [Route("{id:int:min(1)}")]
        [HttpPut]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeId = id;
                return Ok(_employeeService.Update(employee));
            }

            return BadRequest();
        }
    }
}
