using ApplicationLayer.DTOs;
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
        #region EmployeeFunctions

        IEnumerable<EmployeeDTO> GetAllEmployees();

        EmployeeDTO1 GetEmployeeById(int id);

        Employee GetEmployeeRecord(int id);

        bool AddEmployee(Employee employee);

        bool DeleteEmployee(int id);

        bool DeleteEmployees(List<int> ids);
        List<EmployeeDTO> FindEmployees(Expression<Func<Employee, bool>> predicate);

        List<Employee> FindEmployees(Expression<Func<Employee, bool>> predicate, Expression<Func<Employee, Employee>> selector);
        #endregion

    }

    public class Facade : IFacade
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public bool AddEmployee(Employee employee)
        {
            var employeeManager = new EmployeeManager(unitOfWork);

            var add= employeeManager.AddEmployee(employee);
            unitOfWork.Save();
            return add;
        }

        public bool DeleteEmployee(int id)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            var del = employeeManager.DeleteEmployee(id);
            unitOfWork.Save();
            return del;
        }

        public bool DeleteEmployees(List<int> ids)
        {
            Expression<Func<Employee, bool>> predicate = emp => ids.Any(id => id == emp.EmployeeID);
            var employeeManager = new EmployeeManager(unitOfWork);
            var del =  employeeManager.DeleteEmployees(predicate);
            unitOfWork.Save();
            return del;
        }

        public List<EmployeeDTO> FindEmployees(Expression<Func<Employee, bool>> predicate)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            var emps = employeeManager.Find(predicate).ToList();
            unitOfWork.Save();
            return emps;
        }


        public List<Employee> FindEmployees(Expression<Func<Employee, bool>> predicate, Expression<Func<Employee, Employee>> selector)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            var emps= employeeManager.Find(predicate, selector).ToList<Employee>();
            unitOfWork.Save();
            return emps;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            var emps= employeeManager.GetAllEmployees();
            unitOfWork.Save();
            return emps;
        }

        public Employee GetEmployeeRecord(int id)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            return employeeManager.GetEmployeeRecord(id);

        }

        public EmployeeDTO1 GetEmployeeById(int id)
        {
            var employeeManager = new EmployeeManager(unitOfWork);
            var emp= employeeManager.GetEmployeeById(id);
            unitOfWork.Save();
            return emp;
        }
    }
}
