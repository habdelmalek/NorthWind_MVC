using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp.Tests.Facade_Employee
{
    [TestClass]
    public class Employees
    {
        [TestMethod]
        public void TestMethod1()
        {
            IFacade facade = new Facade();
            var employees = facade.GetAllEmployees();
            Assert.IsNotNull(employees);

        }
    }
}
