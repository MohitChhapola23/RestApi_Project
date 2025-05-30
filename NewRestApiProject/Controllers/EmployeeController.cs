using Microsoft.AspNetCore.Mvc;
using NewRestApiProject.Models;
using NewRestApiProject.Models.Repos.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewRestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await repository.GetEmployees());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Error to retrive data from db" });
            }
           
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               Employee emp= await repository.GetEmployee(id);
                if (emp != null)
                {
                    return Ok(emp);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { error = "Record Not Found" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Error to retrive data from db" });
            }
           
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();

                var created_emp= await repository.AddEmployee(employee); 
                return CreatedAtAction(nameof(Get), new {id=created_emp.EmployeeId},created_emp);

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating employee in database");
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
