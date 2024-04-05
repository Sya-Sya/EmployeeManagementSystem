using EmployeeMS.Model;
using System;
using System.Collections.Generic;

namespace EmployeeMS.Interface
{
    public class PositionInt : IPosition
    {
        private readonly EMSContext _context;

        public PositionInt(EMSContext context)
        {
            _context = context;
        }

        public void AddPosition(EmployeeModel.Position position)
        {
            _context.Positions.Add(position);
        }

        public EmployeeModel.Position FindPositionById(int id)
        {
            return _context.Positions.Find(id);
        }

        public IQueryable<PositionInt> GetPositions()
        {
            return _context.Positions.Cast<PositionInt>();
        }

        public void RemovePosition(EmployeeModel.Position position)
        {
            _context.Positions.Remove(position);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
