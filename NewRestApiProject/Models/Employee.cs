﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using NewRestApiProject.Enum;

namespace NewRestApiProject.Models
{
   

        public class Employee
        {
            public int EmployeeId { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "FirstName must contains at least 2 charcters")]
            public string? FirstName { get; set; }
            [Required]
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Gender Sex { get; set; }
            public int DepartmentId { get; set; }
            public string? PhotoPath { get; set; }
            public Department? Department { get; set; }
        }
    }

