using EmployeeMS.Model;
using System;

namespace EmployeeMS.Interface
{
    public class DepartmentInt : IDepartment
    {
        private readonly EMSContext _context;

        public DepartmentInt(EMSContext context)
        {
            _context = context;
        }

        public void AddDepartment(EmployeeModel.Department department)
        {
            _context.Departments.Add(department);
        }

        public EmployeeModel.Department FindDepartmentById(int id)
        {
            return _context.Departments.Find(id);
        }

        public IQueryable<DepartmentInt> GetDepartments()
        {
            return _context.Departments.Cast<DepartmentInt>();
        }

        public void RemoveDepartment(EmployeeModel.Department Department)
        {
            _context.Departments.Remove(Department);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
