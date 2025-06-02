using NewRestApiProject.Enum;
using NewRestApiProject.Models.Repos;
using NewRestApiProject.Models.Repos.Interfaces;
using NewRestApiProject.DataContext;
using Microsoft.EntityFrameworkCore;
namespace NewRestApiProject.Models.Repos
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee.Department != null)
            {
                context.Entry(employee.Department).State = EntityState.Unchanged;
            }
            var result=await context.Employees.AddAsync(employee);
           
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var emp_to_del=await context.Employees.FirstOrDefaultAsync(e=>e.EmployeeId==employeeId);
            if(emp_to_del != null) 
            {
                context.Employees.Remove(emp_to_del);   
                await context.SaveChangesAsync();
                return emp_to_del;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            //LINQ

           Employee? emp = await context.Employees.Include(d=>d.Department).FirstOrDefaultAsync(e=>e.EmployeeId==employeeId);

           return emp;
        }

        public Task<Employee> GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employees.Include(d=>d.Department).ToListAsync();  
        }

        public Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
