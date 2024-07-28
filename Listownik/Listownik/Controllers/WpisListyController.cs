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
    public class WpisListyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WpisListyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WpisListy
        public async Task<IActionResult> Index()
        {
            return View(await _context.WpisyListy.ToListAsync());
        }

        // GET: WpisListy/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wpisListyEntity = await _context.WpisyListy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wpisListyEntity == null)
            {
                return NotFound();
            }

            return View(wpisListyEntity);
        }

        // GET: WpisListy/Create
        public IActionResult Create()
        {
            ViewData["ListaId"] = new SelectList(_context.Listy, "Id", "Nazwa");
            return View();
        }

        // POST: WpisListy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Ilosc,Ikona,ListaID")] WpisListyEntity wpisListyEntity)
        {
            if (ModelState.IsValid)
            {
                wpisListyEntity.Id = Guid.NewGuid();
                _context.Add(wpisListyEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListaId"] = new SelectList(_context.Listy, "Id", "Nazwa", wpisListyEntity.ListaId);
            return View(wpisListyEntity);
        }

        // GET: WpisListy/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wpisListyEntity = await _context.WpisyListy.FindAsync(id);
            if (wpisListyEntity == null)
            {
                return NotFound();
            }
            ViewData["ListaId"] = new SelectList(_context.Listy, "Id", "Nazwa", wpisListyEntity.ListaId);
            return View(wpisListyEntity);
        }

        // POST: WpisListy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nazwa,Opis,Ilosc,Ikona,ListaID")] WpisListyEntity wpisListyEntity)
        {
            if (id != wpisListyEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wpisListyEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WpisListyEntityExists(wpisListyEntity.Id))
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
            ViewData["ListaId"] = new SelectList(_context.Listy, "Id", "Nazwa", wpisListyEntity.ListaId);
            return View(wpisListyEntity);
        }

        // GET: WpisListy/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wpisListyEntity = await _context.WpisyListy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wpisListyEntity == null)
            {
                return NotFound();
            }

            return View(wpisListyEntity);
        }

        // POST: WpisListy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var wpisListyEntity = await _context.WpisyListy.FindAsync(id);
            if (wpisListyEntity != null)
            {
                _context.WpisyListy.Remove(wpisListyEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WpisListyEntityExists(Guid id)
        {
            return _context.WpisyListy.Any(e => e.Id == id);
        }
    }
}
