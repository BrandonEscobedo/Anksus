﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto2.Models;
using proyecto2.Models.dbModels;

namespace proyecto2.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CuestionariosController : Controller
    {
        private readonly ansksusContext _context;
        private readonly UserManager<AplicationUser> _userManager;
        public CuestionariosController(ansksusContext context,UserManager<AplicationUser> usermanger)
        {
           
            _context = context;
            _userManager = usermanger;
        }
      
        public async Task<IActionResult> Index()
        {
            var ansksusContext = _context.Cuestionarios.Include(c => c.IdCategoriaNavigation).Include(c => c.IdUsuarioNavigation);
            return View(await ansksusContext.ToListAsync());
        }

        // GET: Cuestionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cuestionarios == null)
            {
                return NotFound();
            }

            var cuestionario = await _context.Cuestionarios
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdUsuarioNavigation)
               
                .FirstOrDefaultAsync(m => m.IdCuestionario == id);
            if (cuestionario == null)
            {
                return NotFound();
            }

            return View(cuestionario);
        }

        // GET: Cuestionarios/Create
        public IActionResult Create()
        {
           
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Categoria1");
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            
            return View();
        }

        // POST: Cuestionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCuestionario,IdUsuario,IdCategoria,Estado,Titulo,Publico")] CuestionarioHR cuestionario)
        {
            var user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                Cuestionario cuest = new Cuestionario{
                IdCategoria = cuestionario.IdCategoria,
                IdUsuario = user.Id,
               Estado=cuestionario.Estado,
               Titulo=cuestionario.Titulo,
               Publico=cuestionario.Publico


                };

                _context.Cuestionarios.Add(cuest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", cuestionario.IdCategoria);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", cuestionario.IdUsuario);

           
            return View(cuestionario);
        }

        // GET: Cuestionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cuestionarios == null)
            {
                return NotFound();
            }

            var cuestionario = await _context.Cuestionarios.FindAsync(id);
            if (cuestionario == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", cuestionario.IdCategoria);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", cuestionario.IdUsuario);
            return View(cuestionario);
        }

        // POST: Cuestionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCuestionario,IdUsuario,IdCategoria,Estado,Titulo,Publico")] Cuestionario cuestionario)
        {
            if (id != cuestionario.IdCuestionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuestionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuestionarioExists(cuestionario.IdCuestionario))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", cuestionario.IdCategoria);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", cuestionario.IdUsuario);
            return View(cuestionario);
        }

        // GET: Cuestionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cuestionarios == null)
            {
                return NotFound();
            }

            var cuestionario = await _context.Cuestionarios
                .Include(c => c.IdCategoriaNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCuestionario == id);
            if (cuestionario == null)
            {
                return NotFound();
            }

            return View(cuestionario);
        }

        // POST: Cuestionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cuestionarios == null)
            {
                return Problem("Entity set 'ansksusContext.Cuestionarios'  is null.");
            }
            var cuestionario = await _context.Cuestionarios.FindAsync(id);
            if (cuestionario != null)
            {
                _context.Cuestionarios.Remove(cuestionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuestionarioExists(int id)
        {
          return (_context.Cuestionarios?.Any(e => e.IdCuestionario == id)).GetValueOrDefault();
        }
    }
}
