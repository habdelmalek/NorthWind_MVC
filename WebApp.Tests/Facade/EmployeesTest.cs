using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer;
using System.Linq;

namespace WebApp.Tests.Facade_Employee
{
    [TestClass]
    public class EmployeesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IFacade facade = new Facade();
            var employees = facade.GetAllEmployees().ToList();
            Assert.IsNotNull(employees);

        }
    }
}
