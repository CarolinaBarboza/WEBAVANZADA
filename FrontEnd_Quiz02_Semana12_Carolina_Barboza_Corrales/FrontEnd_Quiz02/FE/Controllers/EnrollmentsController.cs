using FE.Models;
using FE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IPeopleServices peopleServices;
        private readonly IEnrollmentsServices enrollmentsServices;

        public EnrollmentsController(IEnrollmentsServices enrollmentsServices, IPeopleServices peopleServices)
        {
            this.enrollmentsServices = enrollmentsServices;
            this.peopleServices = peopleServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            //var contosoUniversity2Context = _context.Enrollment.Include(e => e.Course).Include(e => e.Student);
            return View(enrollmentsServices.GetAll());
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enrollment = enrollmentsServices.GetOneByIdAsync((int)id);
            var enrollment = enrollmentsServices.GetOneById((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollment/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseId,StudentId,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollmentsServices.Insert(enrollment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator");
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = enrollmentsServices.GetOneById((int)id); ;
            if (enrollment == null)
            {
                return NotFound();
            }
            //ViewData["CourseId"] = new SelectList(enrollmentsServices.GetAll(), "CourseId", "CourseId", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator");

            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,CourseId,StudentId,Grade")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    enrollmentsServices.Update(enrollment);
                }
                catch (Exception ee)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentId))
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
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator");
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = enrollmentsServices.GetOneByIdAsync((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = enrollmentsServices.GetOneById((int)id);
            enrollmentsServices.Update(enrollment);
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return (enrollmentsServices.GetOneById((int)id) !=  null);
        }
    }
}
