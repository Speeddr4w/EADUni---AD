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
    public class TbCurriculoesController : Controller
    {
        private readonly AD___2FAContext _context;

        public TbCurriculoesController(AD___2FAContext context)
        {
            _context = context;
        }

        // GET: TbCurriculoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCurriculo.ToListAsync());
        }

        // GET: TbCurriculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCurriculo = await _context.TbCurriculo
                .FirstOrDefaultAsync(m => m.IdCurriculo == id);
            if (tbCurriculo == null)
            {
                return NotFound();
            }

            return View(tbCurriculo);
        }

        // GET: TbCurriculoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbCurriculoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCurriculo,Graduacao,AnosExperiencia,CursosRealizados")] TbCurriculo tbCurriculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCurriculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCurriculo);
        }

        // GET: TbCurriculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCurriculo = await _context.TbCurriculo.FindAsync(id);
            if (tbCurriculo == null)
            {
                return NotFound();
            }
            return View(tbCurriculo);
        }

        // POST: TbCurriculoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCurriculo,Graduacao,AnosExperiencia,CursosRealizados")] TbCurriculo tbCurriculo)
        {
            if (id != tbCurriculo.IdCurriculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCurriculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCurriculoExists(tbCurriculo.IdCurriculo))
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
            return View(tbCurriculo);
        }

        // GET: TbCurriculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCurriculo = await _context.TbCurriculo
                .FirstOrDefaultAsync(m => m.IdCurriculo == id);
            if (tbCurriculo == null)
            {
                return NotFound();
            }

            return View(tbCurriculo);
        }

        // POST: TbCurriculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCurriculo = await _context.TbCurriculo.FindAsync(id);
            _context.TbCurriculo.Remove(tbCurriculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCurriculoExists(int id)
        {
            return _context.TbCurriculo.Any(e => e.IdCurriculo == id);
        }
    }
}
