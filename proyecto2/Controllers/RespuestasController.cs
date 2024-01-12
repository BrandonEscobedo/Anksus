using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto2.Models.dbModels;

namespace proyecto2.Controllers
{
    public class RespuestasController : Controller
    {
        private readonly ansksusContext _context;

        public RespuestasController(ansksusContext context)
        {
            _context = context;
        }

        // GET: Respuestas
        public async Task<IActionResult> Index()
        {
            var ansksusContext = _context.Respuestas.Include(r => r.IdPreguntaNavigation);
            return View(await ansksusContext.ToListAsync());
        }

        // GET: Respuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Respuestas == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.IdPreguntaNavigation)
                .FirstOrDefaultAsync(m => m.IdRespuesta == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // GET: Respuestas/Create
        public IActionResult Create()
        {
            ViewData["IdPregunta"] = new SelectList(_context.Preguntas, "IdPregunta", "IdPregunta");
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRespuesta,IdPregunta,respuesta,RCorrecta")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPregunta"] = new SelectList(_context.Preguntas, "IdPregunta", "IdPregunta", respuesta.IdPregunta);
            return View(respuesta);
        }

        // GET: Respuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Respuestas == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta == null)
            {
                return NotFound();
            }
            ViewData["IdPregunta"] = new SelectList(_context.Preguntas, "IdPregunta", "IdPregunta", respuesta.IdPregunta);
            return View(respuesta);
        }

        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRespuesta,IdPregunta,respuesta,RCorrecta")] Respuesta respuesta)
        {
            if (id != respuesta.IdRespuesta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestaExists(respuesta.IdRespuesta))
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
            ViewData["IdPregunta"] = new SelectList(_context.Preguntas, "IdPregunta", "IdPregunta", respuesta.IdPregunta);
            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Respuestas == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.IdPreguntaNavigation)
                .FirstOrDefaultAsync(m => m.IdRespuesta == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Respuestas == null)
            {
                return Problem("Entity set 'ansksusContext.Respuestas'  is null.");
            }
            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta != null)
            {
                _context.Respuestas.Remove(respuesta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespuestaExists(int id)
        {
          return (_context.Respuestas?.Any(e => e.IdRespuesta == id)).GetValueOrDefault();
        }
    }
}
