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
    public class TbClientesController : Controller
    {
        private readonly AD___2FAContext _context;

        public TbClientesController(AD___2FAContext context)
        {
            _context = context;
        }

        // GET: TbClientes
        public async Task<IActionResult> Index()
        {
            var aD___2FAContext = _context.TbCliente.Include(t => t.IdPagamentoNavigation);
            return View(await aD___2FAContext.ToListAsync());
        }

        // GET: TbClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbCliente
                .Include(t => t.IdPagamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // GET: TbClientes/Create
        public IActionResult Create()
        {
            ViewData["IdPagamento"] = new SelectList(_context.Set<TbPagamento>(), "IdPagamento", "FormaPagamento");
            return View();
        }

        // POST: TbClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,IdPagamento,VisitasSite,Nome,Cpf,Cep,Email,Telefone")] TbCliente tbCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPagamento"] = new SelectList(_context.Set<TbPagamento>(), "IdPagamento", "FormaPagamento", tbCliente.IdPagamento);
            return View(tbCliente);
        }

        // GET: TbClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbCliente.FindAsync(id);
            if (tbCliente == null)
            {
                return NotFound();
            }
            ViewData["IdPagamento"] = new SelectList(_context.Set<TbPagamento>(), "IdPagamento", "FormaPagamento", tbCliente.IdPagamento);
            return View(tbCliente);
        }

        // POST: TbClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,IdPagamento,VisitasSite,Nome,Cpf,Cep,Email,Telefone")] TbCliente tbCliente)
        {
            if (id != tbCliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbClienteExists(tbCliente.IdCliente))
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
            ViewData["IdPagamento"] = new SelectList(_context.Set<TbPagamento>(), "IdPagamento", "FormaPagamento", tbCliente.IdPagamento);
            return View(tbCliente);
        }

        // GET: TbClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbCliente
                .Include(t => t.IdPagamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // POST: TbClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCliente = await _context.TbCliente.FindAsync(id);
            _context.TbCliente.Remove(tbCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbClienteExists(int id)
        {
            return _context.TbCliente.Any(e => e.IdCliente == id);
        }
    }
}
