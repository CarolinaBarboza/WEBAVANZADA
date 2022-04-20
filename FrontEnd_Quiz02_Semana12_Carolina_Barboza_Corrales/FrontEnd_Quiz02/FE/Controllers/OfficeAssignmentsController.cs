using FE.Models;
using FE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class OfficeAssignmentsController : Controller
    {
        private readonly IOfficeAssignmentsServices officeAssignmentsServices;

        public OfficeAssignmentsController(IOfficeAssignmentsServices officeAssignmentsServices)
        {
            this.officeAssignmentsServices = officeAssignmentsServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: OfficeAssignment
        public async Task<IActionResult> Index()
        {
            return View(officeAssignmentsServices.GetAll());
        }

        // GET: OfficeAssignment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = officeAssignmentsServices.GetOneById((int)id);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            return View(officeAssignment);
        }

        // GET: OfficeAssignment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficeAssignment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,Location")] OfficeAssignment officeAssignment)
        {
            if (ModelState.IsValid)
            {
                officeAssignmentsServices.Insert(officeAssignment);
                return RedirectToAction(nameof(Index));
            }
            return View(officeAssignment);
        }

        // GET: OfficeAssignment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = officeAssignmentsServices.GetOneById((int)id);
            if (officeAssignment == null)
            {
                return NotFound();
            }
            //ViewData["InstructorId"] = new SelectList(_context.Person, "Id", "Discriminator", officeAssignment.InstructorId);
            return View(officeAssignment);
        }

        // POST: OfficeAssignment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,Location")] OfficeAssignment officeAssignment)
        {
            if (id != officeAssignment.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    officeAssignmentsServices.Update(officeAssignment);
                }
                catch (Exception ee)
                {
                    if (!OfficeAssignmentExists(officeAssignment.InstructorId))
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
            //ViewData["InstructorId"] = new SelectList(_context.Person, "Id", "Discriminator", officeAssignment.InstructorId);
            return View(officeAssignment);
        }

        // GET: OfficeAssignment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = officeAssignmentsServices.GetOneById((int)id);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            return View(officeAssignment);
        }

        // POST: OfficeAssignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeAssignment = officeAssignmentsServices.GetOneById(id);
            officeAssignmentsServices.Delete(officeAssignment);
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeAssignmentExists(int id)
        {
            return (officeAssignmentsServices.GetOneById(id) != null);
        }
    }
}
