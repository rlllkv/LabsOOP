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
    public class ID_cardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ID_cardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ID_card
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ID_cards.Include(i => i.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ID_card/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iD_card = await _context.ID_cards
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iD_card == null)
            {
                return NotFound();
            }

            return View(iD_card);
        }

        // GET: ID_card/Create
        public IActionResult Create()
        {
            ViewData["StudentID"] = new SelectList(_context.Students, "Name", "Name");
            return View();
        }

        // POST: ID_card/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,StudentID")] ID_card iD_card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iD_card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", iD_card.StudentID);
            return View(iD_card);
        }

        // GET: ID_card/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iD_card = await _context.ID_cards.FindAsync(id);
            if (iD_card == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Name", iD_card.StudentID);
            return View(iD_card);
        }

        // POST: ID_card/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,StudentID")] ID_card iD_card)
        {
            if (id != iD_card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iD_card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ID_cardExists(iD_card.Id))
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
            ViewData["StudentID"] = new SelectList(_context.Students, "Id", "Id", iD_card.StudentID);
            return View(iD_card);
        }

        // GET: ID_card/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iD_card = await _context.ID_cards
                .Include(i => i.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iD_card == null)
            {
                return NotFound();
            }

            return View(iD_card);
        }

        // POST: ID_card/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iD_card = await _context.ID_cards.FindAsync(id);
            if (iD_card != null)
            {
                _context.ID_cards.Remove(iD_card);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ID_cardExists(int id)
        {
            return _context.ID_cards.Any(e => e.Id == id);
        }
    }
}
