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
    public class TbVendasController : Controller
    {
        private readonly AD___2FAContext _context;

        public TbVendasController(AD___2FAContext context)
        {
            _context = context;
        }

        // GET: TbVendas
        public async Task<IActionResult> Index()
        {
            var aD___2FAContext = _context.TbVendas.Include(t => t.IdClienteNavigation).Include(t => t.IdCursosNavigation);
            return View(await aD___2FAContext.ToListAsync());
        }

        // GET: TbVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVendas = await _context.TbVendas
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdCursosNavigation)
                .FirstOrDefaultAsync(m => m.IdVendas == id);
            if (tbVendas == null)
            {
                return NotFound();
            }

            return View(tbVendas);
        }

        // GET: TbVendas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.TbCliente, "IdCliente", "Email");
            ViewData["IdCursos"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa");
            return View();
        }

        // POST: TbVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVendas,IdCursos,IdCliente,DataCompra")] TbVendas tbVendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbVendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.TbCliente, "IdCliente", "Email", tbVendas.IdCliente);
            ViewData["IdCursos"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa", tbVendas.IdCursos);
            return View(tbVendas);
        }

        // GET: TbVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVendas = await _context.TbVendas.FindAsync(id);
            if (tbVendas == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.TbCliente, "IdCliente", "Email", tbVendas.IdCliente);
            ViewData["IdCursos"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa", tbVendas.IdCursos);
            return View(tbVendas);
        }

        // POST: TbVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVendas,IdCursos,IdCliente,DataCompra")] TbVendas tbVendas)
        {
            if (id != tbVendas.IdVendas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbVendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbVendasExists(tbVendas.IdVendas))
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
            ViewData["IdCliente"] = new SelectList(_context.TbCliente, "IdCliente", "Email", tbVendas.IdCliente);
            ViewData["IdCursos"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa", tbVendas.IdCursos);
            return View(tbVendas);
        }

        // GET: TbVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVendas = await _context.TbVendas
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdCursosNavigation)
                .FirstOrDefaultAsync(m => m.IdVendas == id);
            if (tbVendas == null)
            {
                return NotFound();
            }

            return View(tbVendas);
        }

        // POST: TbVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbVendas = await _context.TbVendas.FindAsync(id);
            _context.TbVendas.Remove(tbVendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbVendasExists(int id)
        {
            return _context.TbVendas.Any(e => e.IdVendas == id);
        }
    }
}
