using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeMS.Model.EmployeeModel;

namespace EmployeeMS.Interface
{
    public interface IEmployee
    {
        void AddEmployee(Employee employee);
        Employee FindEmployeeById(int id);
        IQueryable<EmployeeInt> GetEmployees();
        void RemoveEmployee(Employee employee);
        void SaveChanges();
    }
}
