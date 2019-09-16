using ApplicationLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace WebApp.Tests.Facade_Employee
{
    [TestClass]
    public class EmployeesTest
    {
        private IFacade facade = new Facade();

        [TestMethod]
        public void EmployeesSetNotNull()
        {
            //act
            var employees = facade.GetAllEmployees().ToList();
            //assert
            Assert.IsNotNull(employees);
        }

        [TestMethod]
        public void GetEmployeeById()
        {
            //arrange
            int id = 1;
            //act
            var employee = facade.GetEmployeeById(id).FirstName;
            //assert
            Console.WriteLine(employee);
            Assert.AreEqual("Nancy", employee.ToString());
        }

        [TestMethod]
        public void AddNewEmployee()
        {
            //arange
            
            var employee = new Employee()
            {
                EmployeeID = 10,
                FirstName = "Hany",
                LastName = "Abdelmalek",
                Address = "17445 Rue Julie",
                BirthDate = new DateTime(1974, 04, 28),
                HireDate = new DateTime(2002, 09, 01),
                City = "Pierrefonds",
                Country = "Canada",
                Title = "Team leader",
                TitleOfCourtesy = "Mr",
                ReportsTo=2
            };

            //act
            var added = facade.AddEmployee(employee);

            //assert
            //int newEmployeesNumber = facade.GetAllEmployees().ToList().Count();
            //Assert.AreEqual(newEmployeesNumber, CurrentEmployeesNumber + 1);
            Assert.AreEqual(true, added);
        }


        [TestMethod]
        public void RemoveEmployee()
        {
            int id = 10;
            facade.DeleteEmployee(id);
            var emp = facade.GetEmployeeById(id);

            Assert.IsNull(emp);
        }
    }
}