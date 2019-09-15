using ApplicationLayer.EntityManager;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public interface IFacade
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);

        bool AddEmployee(Employee employee);

        bool DeleteEmployee(int id);

        bool DeleteEmployees(List<int> ids);

        List<Employee> FindEmployees(Expression<Func<Employee, bool>> predicate, Expression<Func<Employee, Employee>> selector);
    }

    public class Facade : IFacade
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public bool AddEmployee(Employee employee)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            return employeeManager.AddEmployee(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            return employeeManager.DeleteEmployee(id);
        }

        public bool DeleteEmployees(List<int> ids)
        {
            Expression<Func<Employee, bool>> predicate = emp => ids.Any(id => id == emp.EmployeeID);
            var employeeManager = new EmployeeManager(unitOfWork);
            return employeeManager.DeleteEmployees(predicate);
        }

        public List<Employee> FindEmployees(Expression<Func<Employee, bool>> predicate, Expression<Func<Employee, Employee>> selector)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            return employeeManager.Find(predicate, selector).ToList<Employee>();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            return employeeManager.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            return employeeManager.GetEmployeeById(id);
        }
    }
}
