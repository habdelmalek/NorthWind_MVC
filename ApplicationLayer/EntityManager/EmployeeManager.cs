using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApplicationLayer.EntityManager
{
    public class EmployeeManager
    {
        private UnitOfWork unitOfWork;

        public EmployeeManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork as UnitOfWork;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = unitOfWork.EmployeeRepository.GetAll();
            return employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = unitOfWork.EmployeeRepository.GetById(id);
            return employee;
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                unitOfWork.EmployeeRepository.Add(employee);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                unitOfWork.EmployeeRepository.Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployees(Expression<Func<Employee, bool>> predicate)
        {
            try
            {
                unitOfWork.EmployeeRepository.Remove(predicate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate, Expression<Func<Employee, Employee>> selector)
        {
            List<Employee> employees = new List<Employee>();
            return employees = unitOfWork.EmployeeRepository.Find(predicate, selector).ToList();
        }
    }
}