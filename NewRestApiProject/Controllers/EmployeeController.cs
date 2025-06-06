using Microsoft.AspNetCore.Mvc;
using NewRestApiProject.Models;
using NewRestApiProject.Models.Repos;
using NewRestApiProject.Models.Repos.Interfaces;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewRestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowAll")]
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
                return Ok(new { response = "Success", result = await repository.GetEmployees() });
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
                    return Ok(new {response="Success",result=emp});
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new {response="Failure",  result = $"Record Not Found with employee id {id}" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "Failure", result = $"Error to delete in db {ex.Message}" });
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
                return CreatedAtAction(nameof(Get), new { id = created_emp.EmployeeId }, new {response="Success",result=created_emp});

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {response="Failure", result = $"Error to delete in db {ex.Message}" });
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, Employee employee)
        {
            try
            {
                if (employee.EmployeeId != id)
                    return BadRequest("Employee Id mismatch");// new { response = "employee not passed" });
                var emptoUpdate = await repository.GetEmployee(id);
                if (emptoUpdate == null)
                {
                    return NotFound($"Employee with Id={id} not found");
                }
                return await repository.UpdateEmployee(employee);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating emp rec in database");
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                
              
               var emp_to_del = await repository.DeleteEmployee(id);
               if (emp_to_del == null)
                {
                    return NotFound(new {response="Failure", result= $"Employee with Id={id} not found" });
                }
                return Ok(new {response="Success", result=emp_to_del});

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {response="Failure", msg=$"Error to delete in db {ex.Message}"});
            }
        }
    }
}
