﻿using EmployeeCRUDusingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace EmployeeCRUDusingADO.Controllers
{
    public class StudentController : Controller
    {
        StudentCRUD crud;
        private readonly IConfiguration configuration;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new StudentCRUD(this.configuration);
        }

     
    
        // GET: StudentController
        public ActionResult Index()
        {
            var list = crud.GetAllStudent();

            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var stud = crud.GetStudentById(id);
            return View(stud);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stud)
        {
            try
            {
                int result = crud.AddStudent(stud);
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var stud = crud.GetStudentById(id);
            return View(stud);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student stud)
        {
            try
            {
                int result = crud.UpdateStudent(stud);
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var stud = crud.GetStudentById(id);
            return View(stud);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

            [ActionName("Delete")]
            public ActionResult DeleteConfirm(int id)
            {
                try
                {
                    int result = crud.DeleteStudent(id);
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
