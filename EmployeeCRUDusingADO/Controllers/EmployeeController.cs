
using Microsoft.AspNetCore.Mvc;
using EmployeeCRUDusingADO.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace EmployeeCRUDusingADO.Controllers
{
    public class EmployeeController : Controller
    { 
        EmployeeCRUDcs crud;
        private readonly IConfiguration configuration;

        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new EmployeeCRUDcs(this.configuration);
        }
       

    
        // GET: EmployeeController Emplist
        public ActionResult Index()
        {
            var list = crud.GetAllStudent();
            
            return View(list);
        }

        // GET: EmployeeController/Details/5-->sigle emp
        public ActionResult Details(int id)
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmployeeController/Create-->
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = crud.AddEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5-->modify emp
        public ActionResult Edit(int id)
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = crud.UpdateEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
         
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = crud.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteEmployee(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
