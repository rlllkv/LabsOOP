using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazaGRUD.Data;
using BazaGRUD.Models;

namespace BazaGRUD.Controllers
{
    public class StudentToGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentToGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentToGroups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentToGroups.Include(s => s.Group).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentToGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToGroup = await _context.StudentToGroups
                .Include(s => s.Group)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentToGroup == null)
            {
                return NotFound();
            }

            return View(studentToGroup);
        }

        // GET: StudentToGroups/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Id");
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: StudentToGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentID,GroupID")] StudentToGroup studentToGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentToGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Id", studentToGroup.GroupID);
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", studentToGroup.StudentID);
            return View(studentToGroup);
        }

        // GET: StudentToGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToGroup = await _context.StudentToGroups.FindAsync(id);
            if (studentToGroup == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Id", studentToGroup.GroupID);
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", studentToGroup.StudentID);
            return View(studentToGroup);
        }

        // POST: StudentToGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentID,GroupID")] StudentToGroup studentToGroup)
        {
            if (id != studentToGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentToGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentToGroupExists(studentToGroup.Id))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Id", studentToGroup.GroupID);
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", studentToGroup.StudentID);
            return View(studentToGroup);
        }

        // GET: StudentToGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToGroup = await _context.StudentToGroups
                .Include(s => s.Group)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentToGroup == null)
            {
                return NotFound();
            }

            return View(studentToGroup);
        }

        // POST: StudentToGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentToGroup = await _context.StudentToGroups.FindAsync(id);
            if (studentToGroup != null)
            {
                _context.StudentToGroups.Remove(studentToGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentToGroupExists(int id)
        {
            return _context.StudentToGroups.Any(e => e.Id == id);
        }
    }
}
