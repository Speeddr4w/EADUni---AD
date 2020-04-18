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
    public class TbPagamentoesController : Controller
    {
        private readonly AD___2FAContext _context;

        public TbPagamentoesController(AD___2FAContext context)
        {
            _context = context;
        }

        // GET: TbPagamentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbPagamento.ToListAsync());
        }

        // GET: TbPagamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPagamento = await _context.TbPagamento
                .FirstOrDefaultAsync(m => m.IdPagamento == id);
            if (tbPagamento == null)
            {
                return NotFound();
            }

            return View(tbPagamento);
        }

        // GET: TbPagamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbPagamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPagamento,FormaPagamento,Parcelas")] TbPagamento tbPagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbPagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbPagamento);
        }

        // GET: TbPagamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPagamento = await _context.TbPagamento.FindAsync(id);
            if (tbPagamento == null)
            {
                return NotFound();
            }
            return View(tbPagamento);
        }

        // POST: TbPagamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPagamento,FormaPagamento,Parcelas")] TbPagamento tbPagamento)
        {
            if (id != tbPagamento.IdPagamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPagamentoExists(tbPagamento.IdPagamento))
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
            return View(tbPagamento);
        }

        // GET: TbPagamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPagamento = await _context.TbPagamento
                .FirstOrDefaultAsync(m => m.IdPagamento == id);
            if (tbPagamento == null)
            {
                return NotFound();
            }

            return View(tbPagamento);
        }

        // POST: TbPagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbPagamento = await _context.TbPagamento.FindAsync(id);
            _context.TbPagamento.Remove(tbPagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPagamentoExists(int id)
        {
            return _context.TbPagamento.Any(e => e.IdPagamento == id);
        }
    }
}
