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

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
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
