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
    public class ListyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Listy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Listy.ToListAsync());
        }

        // GET: Listy/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listyEntity = await _context.Listy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listyEntity == null)
            {
                return NotFound();
            }

            return View(listyEntity);
        }

        // GET: Listy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] ListyEntity listyEntity)
        {
            if (ModelState.IsValid)
            {
                listyEntity.Id = Guid.NewGuid();
                _context.Add(listyEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listyEntity);
        }

        // GET: Listy/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listyEntity = await _context.Listy.FindAsync(id);
            if (listyEntity == null)
            {
                return NotFound();
            }
            return View(listyEntity);
        }

        // POST: Listy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nazwa")] ListyEntity listyEntity)
        {
            if (id != listyEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listyEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListyEntityExists(listyEntity.Id))
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
            return View(listyEntity);
        }

        // GET: Listy/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listyEntity = await _context.Listy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listyEntity == null)
            {
                return NotFound();
            }

            return View(listyEntity);
        }

        // POST: Listy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var listyEntity = await _context.Listy.FindAsync(id);
            if (listyEntity != null)
            {
                _context.Listy.Remove(listyEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListyEntityExists(Guid id)
        {
            return _context.Listy.Any(e => e.Id == id);
        }
    }
}
