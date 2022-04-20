 using Microsoft.AspNetCore.Mvc;
using System;
using FE.Models;
using FE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FE.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IOfficeAssignmentsServices officeAssignmentsServices;
        private readonly IDepartmentsServices departmentsServices;

        public DepartmentsController(IOfficeAssignmentsServices officeAssignmentsServices, IDepartmentsServices departmentsServices)
        {
            this.officeAssignmentsServices = officeAssignmentsServices;
            this.departmentsServices = departmentsServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: Department
        public async Task<IActionResult> Index()
        {
            //var contosoUniversity2Context = _context.Department.Include(d => d.Instructor);
            return View(departmentsServices.GetAll ());
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentsServices.GetOneByIdAsync((int)id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create LLENAR
        public IActionResult Create()
        {
            ViewData["InstructorId"] = new SelectList(officeAssignmentsServices.GetAll(), "Id", "Discriminator");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,Name,Budget,StartDate,InstructorId,RowVersion")] Department department)
        {
            if (ModelState.IsValid)
            {
                departmentsServices.Insert(department);
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(officeAssignmentsServices.GetAll(), "Id", "Discriminator");
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentsServices.GetOneById((int)id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(officeAssignmentsServices.GetAll(), "Id", "Discriminator", department.InstructorId);
            return View(department);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,Name,Budget,StartDate,InstructorId,RowVersion")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    departmentsServices.Update(department);
                }
                catch (Exception ee)
                {
                    if (!DepartmentExists(department.DepartmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(officeAssignmentsServices.GetAll(), "Id", "Discriminator", department.InstructorId);
            return View(department);
        }

        //ULTIMO METODO QUE SOLUCIONA ERRORES DEL METODO ARRIBA
        private bool DepartmentExists(int id)
        {
            return (departmentsServices.GetOneById((int)id) != null);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = departmentsServices.GetOneByIdAsync((int)id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = departmentsServices.GetOneById((int)id);
            departmentsServices.Delete(department); ;
            return RedirectToAction(nameof(Index));
        }
    }
}
