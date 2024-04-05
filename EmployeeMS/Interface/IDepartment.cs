using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeMS.Model.EmployeeModel;

namespace EmployeeMS.Interface
{
    public interface IDepartment
    {
        void AddDepartment(Department employee);
        Department FindDepartmentById(int id);
        IQueryable<DepartmentInt> GetDepartments();
        void RemoveDepartment(Department Department);
        void SaveChanges();
    }
}
