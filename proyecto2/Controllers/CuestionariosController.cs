﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto2.Models;
using proyecto2.Models.dbModels;
using proyecto2.Models.DTO;
using proyecto2.ViewModel;

namespace proyecto2.Controllers
{

    public class CuestionariosController : Controller
    {
        private readonly ansksusContext _context;
        private readonly UserManager<AplicationUser> _userManager;
        private bool primeraEntrada = true;
        private int IdCuestionario;
        List<Categoria> categorias= new List<Categoria>();
        public CuestionariosController(ansksusContext context, UserManager<AplicationUser> usermanger)
        {

            _context = context;
            _userManager = usermanger;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CuestionarioHR();
            model.cuest =  _context.Cuestionarios.ToList();
            model.Preguntas2 = _context.Preguntas.ToList();
            model.Respuestas2 = _context.Respuestas.ToList();
            return View(model);
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
          
            var model = new CuestionarioHR();
            model.Categorias = _context.Categorias.ToList();
            model.Preguntas2 = _context.Preguntas.ToList();
            model.cuest=_context.Cuestionarios.ToList();
            model.CuestionarioExistente = false;
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Categoria1");
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            Response.Cookies.Delete("MiCokkie");
            return View(model);
        }


        // POST: Cuestionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult>  Create( CuestionarioHR cuestHR)
        {
            bool entrada = true;
            Console.WriteLine("entrada 2" + entrada);
            try
            {   
        var user = await _userManager.GetUserAsync(User);
                Console.WriteLine((_context.Preguntas.Any(e => e.IdCuestionario == cuestHR.IdCuestionario)));
                var existingcuestionario = await _context.Cuestionarios.FindAsync(idcuestionario);
                    Cuestionario cuest = new Cuestionario
                    {      
                        Estado = true,                        
                        IdCategoria = 1,
                        Publico = true,
                        IdUsuario = user.Id
                    };
                    idcuestionario = cuest.IdCuestionario;
                Console.WriteLine("entrada" + primeraEntrada);
                if(entrada==true)
                {
                    _context.Cuestionarios.Add(cuest);
                   await _context.SaveChangesAsync();
                    var idcuestionario1 = cuest.IdCuestionario;

                    var cuestionarioCreado= await _context.Cuestionarios
                        .Include(c=>c.IdCategoriaNavigation)
                        .Include(c=>c.IdUsuarioNavigation)
                        .FirstOrDefaultAsync(m=>m.IdCuestionario==idcuestionario1);
                    Console.WriteLine(cuestHR.Preguntas2.Count(e=>e.IdCuestionario==idcuestionario1));

                 return View(cuestionarioCreado);
                }

                else
                {
                    return Json(new { success = false, message = "Cuestionario Existente" });

                }

            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Error al crear el cuestionario", error = ex.Message });

            }

        }
        private bool ObtenerPrimerEntrada()
        {
            var primeraEntradaCookie = Request.Cookies["MiCokkie"];
            
            bool.TryParse(primeraEntradaCookie,out  primeraEntrada);
            return primeraEntrada;
        }
      public string cambiarnombre(string nombre)
        {
            nombre = nombre.ToUpper();
            return nombre;
        }
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
