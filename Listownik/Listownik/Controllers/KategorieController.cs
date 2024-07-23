using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Listownik.Entities;

namespace Listownik.Controllers
{
    public class KategorieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KategorieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kategorie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategorie.ToListAsync());
        }

        // GET: Kategorie/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorieEntity = await _context.Kategorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategorieEntity == null)
            {
                return NotFound();
            }

            return View(kategorieEntity);
        }

        // GET: Kategorie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] KategorieEntity kategorieEntity)
        {
            if (ModelState.IsValid)
            {
                kategorieEntity.Id = Guid.NewGuid();
                _context.Add(kategorieEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategorieEntity);
        }

        // GET: Kategorie/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorieEntity = await _context.Kategorie.FindAsync(id);
            if (kategorieEntity == null)
            {
                return NotFound();
            }
            return View(kategorieEntity);
        }

        // POST: Kategorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nazwa")] KategorieEntity kategorieEntity)
        {
            if (id != kategorieEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorieEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorieEntityExists(kategorieEntity.Id))
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
            return View(kategorieEntity);
        }

        // GET: Kategorie/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorieEntity = await _context.Kategorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategorieEntity == null)
            {
                return NotFound();
            }

            return View(kategorieEntity);
        }

        // POST: Kategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var kategorieEntity = await _context.Kategorie.FindAsync(id);
            if (kategorieEntity != null)
            {
                _context.Kategorie.Remove(kategorieEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorieEntityExists(Guid id)
        {
            return _context.Kategorie.Any(e => e.Id == id);
        }
    }
}
