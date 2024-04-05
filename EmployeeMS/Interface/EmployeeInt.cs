using EmployeeMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMS.Interface
{
    public class EmployeeInt : IEmployee
    {
        private readonly EMSContext _context;

        public EmployeeInt(EMSContext context)
        {
            _context = context;
        }

        public void AddEmployee(EmployeeModel.Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public EmployeeModel.Employee FindEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public IQueryable<EmployeeInt> GetEmployees()
        {
            return _context.Employees.Cast<EmployeeInt>();
        }

        public void RemoveEmployee(EmployeeModel.Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}