using Microsoft.EntityFrameworkCore;
using NewRestApiProject.Enum;
using NewRestApiProject.Models;

namespace NewRestApiProject.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//data seeding 
            Department d1 = new Department()
            {
                DepartmentId = 10,
                DepartmentName =
            ".Net"
            };
            Department d2 = new Department() 
                {
                DepartmentId = 20, 
                DepartmentName= "HR" };

            modelBuilder.Entity<Department>().HasData(d1);
            modelBuilder.Entity<Department>().HasData(d2);

            Employee e1 = new Employee()
            {
                EmployeeId = 1001,
                FirstName = "Rai",
                LastName = "Singh",
                Email = "rai.verma@sircltech.com",
                DateOfBirth = new DateTime(1985, 09, 02),
                Sex = Gender.Male,
                PhotoPath = "/images/rai.jpg",
                DepartmentId = 10
            };
            Employee e2 = new Employee()
            {
                EmployeeId = 1002,
                FirstName = "Naresh",
                LastName = "Verma",
                Email = "naresh@sircltech.com",
                DateOfBirth = new DateTime(1986, 07, 07),
                Sex = Gender.Male,
                PhotoPath = "/images/naresh.jpg",
                DepartmentId = 20

            };
            Employee e3 = new Employee()
            {
                EmployeeId = 1003,
                FirstName = "Vinod",
                LastName = "Kumar",
                Email = "rvinod@sircltech.com",
                DateOfBirth = new DateTime(1982, 05, 07),
                Sex = Gender.Male,
                PhotoPath = "/images/vinod.jpg",
                DepartmentId = 10
            };
            Employee e4 = new Employee()
            {
                EmployeeId = 1004,
                FirstName = "Rishi",
                LastName = "Kumar",
                Email = "rishi@sircltech.com",
                DateOfBirth = new DateTime(1988, 01, 01),
                Sex = Gender.Male,
                PhotoPath = "/images/rishi.jpg",
                DepartmentId = 10
            };
            modelBuilder.Entity<Employee>().HasData(e1);
            modelBuilder.Entity<Employee>().HasData(e2);
            modelBuilder.Entity<Employee>().HasData(e3);
            modelBuilder.Entity<Employee>().HasData(e4);
        }
    }
}
