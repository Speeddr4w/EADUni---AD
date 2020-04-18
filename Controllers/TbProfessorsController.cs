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
    public class TbProfessorsController : Controller
    {
        private readonly AD___2FAContext _context;

        public TbProfessorsController(AD___2FAContext context)
        {
            _context = context;
        }

        // GET: TbProfessors
        public async Task<IActionResult> Index()
        {
            var aD___2FAContext = _context.TbProfessor.Include(t => t.IdCurriculoNavigation);
            return View(await aD___2FAContext.ToListAsync());
        }

        // GET: TbProfessors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProfessor = await _context.TbProfessor
                .Include(t => t.IdCurriculoNavigation)
                .FirstOrDefaultAsync(m => m.IdProfessor == id);
            if (tbProfessor == null)
            {
                return NotFound();
            }

            return View(tbProfessor);
        }

        // GET: TbProfessors/Create
        public IActionResult Create()
        {
            ViewData["IdCurriculo"] = new SelectList(_context.TbCurriculo, "IdCurriculo", "CursosRealizados");
            return View();
        }

        // POST: TbProfessors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfessor,IdCurriculo,Nome,Cpf,Endereco,Email,Telefone")] TbProfessor tbProfessor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbProfessor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCurriculo"] = new SelectList(_context.TbCurriculo, "IdCurriculo", "CursosRealizados", tbProfessor.IdCurriculo);
            return View(tbProfessor);
        }

        // GET: TbProfessors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProfessor = await _context.TbProfessor.FindAsync(id);
            if (tbProfessor == null)
            {
                return NotFound();
            }
            ViewData["IdCurriculo"] = new SelectList(_context.TbCurriculo, "IdCurriculo", "CursosRealizados", tbProfessor.IdCurriculo);
            return View(tbProfessor);
        }

        // POST: TbProfessors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfessor,IdCurriculo,Nome,Cpf,Endereco,Email,Telefone")] TbProfessor tbProfessor)
        {
            if (id != tbProfessor.IdProfessor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbProfessor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProfessorExists(tbProfessor.IdProfessor))
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
            ViewData["IdCurriculo"] = new SelectList(_context.TbCurriculo, "IdCurriculo", "CursosRealizados", tbProfessor.IdCurriculo);
            return View(tbProfessor);
        }

        // GET: TbProfessors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProfessor = await _context.TbProfessor
                .Include(t => t.IdCurriculoNavigation)
                .FirstOrDefaultAsync(m => m.IdProfessor == id);
            if (tbProfessor == null)
            {
                return NotFound();
            }

            return View(tbProfessor);
        }

        // POST: TbProfessors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbProfessor = await _context.TbProfessor.FindAsync(id);
            _context.TbProfessor.Remove(tbProfessor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbProfessorExists(int id)
        {
            return _context.TbProfessor.Any(e => e.IdProfessor == id);
        }
    }
}
