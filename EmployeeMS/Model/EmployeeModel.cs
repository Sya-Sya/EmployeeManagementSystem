using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Model
{
    public class EmployeeModel
    {
        public class Position
        {
            public int PositionID { get; set; }
            public string Title { get; set; }
            // Navigation property
            public virtual ICollection<Employee> Employees { get; set; }
        }

        public class Department
        {
            public int DepartmentID { get; set; }
            public string Name { get; set; }
            // Navigation property
            public virtual ICollection<Employee> Employees { get; set; }
        }

        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int PositionID { get; set; }
            public int DepartmentID { get; set; }
            public decimal Salary { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }

            public virtual Position Position { get; set; }
            public virtual Department Department { get; set; }
        }
    }
}