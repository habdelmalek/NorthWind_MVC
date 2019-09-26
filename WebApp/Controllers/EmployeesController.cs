using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationLayer;
using ApplicationLayer.DTOs;
using DataAccessLayer;

namespace WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        //private NWContext db = new NWContext();


        Facade facade = new Facade();


        // GET: Employees
        public ActionResult Index()
        {
            var emps = facade.GetAllEmployees();
            return View(emps.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = facade.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details2", employee);
            //return View(employee);
        }

        //// GET: Employees/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employees/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate")] EmployeeDTO employeeDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EmployeeDTOes.Add(employeeDTO);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(employeeDTO);
        //}

        //// GET: Employees/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EmployeeDTO employeeDTO = db.EmployeeDTOes.Find(id);
        //    if (employeeDTO == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employeeDTO);
        //}

        //// POST: Employees/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate")] EmployeeDTO employeeDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(employeeDTO).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(employeeDTO);
        //}

        //// GET: Employees/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EmployeeDTO employeeDTO = db.EmployeeDTOes.Find(id);
        //    if (employeeDTO == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employeeDTO);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    EmployeeDTO employeeDTO = db.EmployeeDTOes.Find(id);
        //    db.EmployeeDTOes.Remove(employeeDTO);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
