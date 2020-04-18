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
    public class TbDisciplinasController : Controller
    {
        private readonly AD___2FAContext _context;

        public TbDisciplinasController(AD___2FAContext context)
        {
            _context = context;
        }

        // GET: TbDisciplinas
        public async Task<IActionResult> Index()
        {
            var aD___2FAContext = _context.TbDisciplinas.Include(t => t.IdCursoNavigation).Include(t => t.IdProfessorNavigation);
            return View(await aD___2FAContext.ToListAsync());
        }

        // GET: TbDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDisciplinas = await _context.TbDisciplinas
                .Include(t => t.IdCursoNavigation)
                .Include(t => t.IdProfessorNavigation)
                .FirstOrDefaultAsync(m => m.IdDisciplinas == id);
            if (tbDisciplinas == null)
            {
                return NotFound();
            }

            return View(tbDisciplinas);
        }

        // GET: TbDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa");
            ViewData["IdProfessor"] = new SelectList(_context.Set<TbProfessor>(), "IdProfessor", "Email");
            return View();
        }

        // POST: TbDisciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDisciplinas,IdProfessor,IdCurso")] TbDisciplinas tbDisciplinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDisciplinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCurso"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa", tbDisciplinas.IdCurso);
            ViewData["IdProfessor"] = new SelectList(_context.Set<TbProfessor>(), "IdProfessor", "Email", tbDisciplinas.IdProfessor);
            return View(tbDisciplinas);
        }

        // GET: TbDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDisciplinas = await _context.TbDisciplinas.FindAsync(id);
            if (tbDisciplinas == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa", tbDisciplinas.IdCurso);
            ViewData["IdProfessor"] = new SelectList(_context.Set<TbProfessor>(), "IdProfessor", "Email", tbDisciplinas.IdProfessor);
            return View(tbDisciplinas);
        }

        // POST: TbDisciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDisciplinas,IdProfessor,IdCurso")] TbDisciplinas tbDisciplinas)
        {
            if (id != tbDisciplinas.IdDisciplinas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDisciplinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDisciplinasExists(tbDisciplinas.IdDisciplinas))
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
            ViewData["IdCurso"] = new SelectList(_context.TbCursos, "IdCursos", "Ementa", tbDisciplinas.IdCurso);
            ViewData["IdProfessor"] = new SelectList(_context.Set<TbProfessor>(), "IdProfessor", "Email", tbDisciplinas.IdProfessor);
            return View(tbDisciplinas);
        }

        // GET: TbDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDisciplinas = await _context.TbDisciplinas
                .Include(t => t.IdCursoNavigation)
                .Include(t => t.IdProfessorNavigation)
                .FirstOrDefaultAsync(m => m.IdDisciplinas == id);
            if (tbDisciplinas == null)
            {
                return NotFound();
            }

            return View(tbDisciplinas);
        }

        // POST: TbDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDisciplinas = await _context.TbDisciplinas.FindAsync(id);
            _context.TbDisciplinas.Remove(tbDisciplinas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDisciplinasExists(int id)
        {
            return _context.TbDisciplinas.Any(e => e.IdDisciplinas == id);
        }
    }
}
