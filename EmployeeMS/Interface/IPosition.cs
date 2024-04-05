using System.Threading.Tasks;
using static EmployeeMS.Model.EmployeeModel;

namespace EmployeeMS.Interface
{
    public interface IPosition
    {
        void AddPosition(Position employee);
        Position FindPositionById(int id);
        IQueryable<PositionInt> GetPositions();
        void RemovePosition(Position employee);
        void SaveChanges();
    }
}