using System.Web;
using rep_pattern_demo.Models;
namespace RepositoryWithMvc.Repository
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int studentId);
        int AddEmployee(Employee employeeEntity);
        int UpdateEmployee(Employee employeeEntity);
        void DeleteEmployee(int employeeId);
    }
}