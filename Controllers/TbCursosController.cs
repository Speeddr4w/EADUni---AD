using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AD___2FA.Data;
using AD___2FA.Models;

namespace AD___2FA.Controllers
{
    public class TbCursosController : Controller
    {
        private readonly AD___2FAContext _context;

        public TbCursosController(AD___2FAContext context)
        {
            _context = context;
        }

        // GET: TbCursos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCursos.ToListAsync());
        }

        // GET: TbCursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCursos = await _context.TbCursos
                .FirstOrDefaultAsync(m => m.IdCursos == id);
            if (tbCursos == null)
            {
                return NotFound();
            }

            return View(tbCursos);
        }

        // GET: TbCursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbCursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCursos,Ementa,Nome,DuracaoHoras,Valor")] TbCursos tbCursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCursos);
        }

        // GET: TbCursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCursos = await _context.TbCursos.FindAsync(id);
            if (tbCursos == null)
            {
                return NotFound();
            }
            return View(tbCursos);
        }

        // POST: TbCursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCursos,Ementa,Nome,DuracaoHoras,Valor")] TbCursos tbCursos)
        {
            if (id != tbCursos.IdCursos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCursosExists(tbCursos.IdCursos))
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
            return View(tbCursos);
        }

        // GET: TbCursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCursos = await _context.TbCursos
                .FirstOrDefaultAsync(m => m.IdCursos == id);
            if (tbCursos == null)
            {
                return NotFound();
            }

            return View(tbCursos);
        }

        // POST: TbCursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCursos = await _context.TbCursos.FindAsync(id);
            _context.TbCursos.Remove(tbCursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCursosExists(int id)
        {
            return _context.TbCursos.Any(e => e.IdCursos == id);
        }
    }
}
