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

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var emp_to_update = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (emp_to_update != null)
            {
                emp_to_update.FirstName = employee.FirstName;   
                emp_to_update.LastName = employee.LastName;
                emp_to_update.PhotoPath = employee.PhotoPath;   
                emp_to_update.DateOfBirth= employee.DateOfBirth;
               
                emp_to_update.Sex=employee.Sex;
                emp_to_update.Email = employee.Email;
                
                if(employee.DepartmentId!=0)
                    emp_to_update.DepartmentId = employee.DepartmentId;
                
                if(employee.Department!=null)
                    emp_to_update.Department.DepartmentId = employee.Department.DepartmentId;

                await context.SaveChangesAsync();

                return await GetEmployee(emp_to_update.EmployeeId);
            }
            return null;
        }
    }
}
