using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationExam.ServiceReference1;

namespace WebApplicationExam.Controllers
{
    public class EmployeeController : Controller
    {
        private Service1Client service;

        public EmployeeController()
        {
            service = new Service1Client();
        }

        // GET: Employee
        public ActionResult Index(string searchString)
        {
            List<Employee> list;
            if (!String.IsNullOrEmpty(searchString))
            {
                list = service.SearchByDepartment(searchString).ToList();
            }
            else
            {
                list = service.FindAllEmployee().ToList();
            }

            return View(list);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Salary,Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                service.AddEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}