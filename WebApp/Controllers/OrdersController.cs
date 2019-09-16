using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class OrdersController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Orders
        public ActionResult Index()
        {

            var emps = unitOfWork.EmployeeRepository.GetAll().Select(emp => emp.FirstName + " " + emp.LastName).ToList();


            return View(emps);
        }
    }
}