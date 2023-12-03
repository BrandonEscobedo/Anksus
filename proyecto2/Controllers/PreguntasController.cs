using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto2.Models.dbModels;
using proyecto2.Models.DTO;

namespace proyecto2.Controllers
{
    public class PreguntasController : Controller
    {
        private readonly ansksusContext _context;

        public PreguntasController(ansksusContext context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index()
        {
            var ansksusContext = _context.Preguntas.Include(p => p.IdCuestionarioNavigation);
            return View(await ansksusContext.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Preguntas == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas
                .Include(p => p.IdCuestionarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPregunta == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // GET: Preguntas/Create
        public IActionResult Create()
        {
            ViewData["IdCuestionario"] = new SelectList(_context.Cuestionarios, "IdCuestionario", "IdCuestionario");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPregunta,IdCuestionario,Respuesta,Estado")] preguntaDTO pregunta)
        {
            if (ModelState.IsValid)
            {
                Pregunta pe = new Pregunta {
                    IdPregunta = pregunta.IdPregunta,
                    IdCuestionario = pregunta.IdCuestionario,
                    pregunta=pregunta.pregunta
                    
                   
                
                };
                _context.Add(pregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCuestionario"] = new SelectList(_context.Cuestionarios, "IdCuestionario", "IdCuestionario", pregunta.IdCuestionario);
            return View(pregunta);
        }

        // GET: Preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Preguntas == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }
            ViewData["IdCuestionario"] = new SelectList(_context.Cuestionarios, "IdCuestionario", "IdCuestionario", pregunta.IdCuestionario);
            return View(pregunta);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPregunta,IdCuestionario,Respuesta,Estado")] Pregunta pregunta)
        {
            if (id != pregunta.IdPregunta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntaExists(pregunta.IdPregunta))
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
            ViewData["IdCuestionario"] = new SelectList(_context.Cuestionarios, "IdCuestionario", "IdCuestionario", pregunta.IdCuestionario);
            return View(pregunta);
        }

        // GET: Preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Preguntas == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas
                .Include(p => p.IdCuestionarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPregunta == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return View(pregunta);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Preguntas == null)
            {
                return Problem("Entity set 'ansksusContext.Preguntas'  is null.");
            }
            var pregunta = await _context.Preguntas.FindAsync(id);
            if (pregunta != null)
            {
                _context.Preguntas.Remove(pregunta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntaExists(int id)
        {
          return (_context.Preguntas?.Any(e => e.IdPregunta == id)).GetValueOrDefault();
        }
    }
}
