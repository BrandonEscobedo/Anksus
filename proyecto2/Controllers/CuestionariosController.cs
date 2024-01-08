using System;
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
using NuGet.Protocol;
using proyecto2.Models;
using proyecto2.Models.dbModels;
using proyecto2.Models.DTO;
using proyecto2.Models.ViewModel;

namespace proyecto2.Controllers
{

    public class CuestionariosController : Controller
    {

        List<Respuesta> ListaRespuestas = new List<Respuesta>();
        private readonly ansksusContext _context;
        private readonly UserManager<AplicationUser> _userManager;
        List<Categoria> categorias= new List<Categoria>();
        public CuestionariosController(ansksusContext context, UserManager<AplicationUser> usermanger)
        {

            _context = context;
            _userManager = usermanger;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CuestionarioHR();
            model.Preguntas = _context.Preguntas.ToList();
            model.Respuestas = _context.Respuestas.ToList();
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
            IdPregunta = 0;
            IdCuestionario = 0; 
            var model = new CuestionarioHR();
            model.cuestionario = _context.Cuestionarios.ToList();
            model.Categorias = _context.Categorias.ToList();
            model.Preguntas = _context.Preguntas.ToList();
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Categoria1");
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View(model);
        }


        // POST: Cuestionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create( Cuestionario cuestHR,IdConteinerCuestionarios idConteinerCuestionarios )
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                Cuestionario cuest = new Cuestionario();
                cuest.Titulo = cuestHR.Titulo;
                cuest.Estado = false;
                cuest.IdCategoria = cuestHR.IdCategoria;
                cuest.IdUsuario = user.Id;
                cuest.Publico = false;
                if (cuestHR.IdCuestionario == 0)
                {
                Console.WriteLine(IdCuestionario);
                 _context.Cuestionarios.Add(cuest);          
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Cuestionario Creado Exitosamente" });
                }
                else
                {
                    await EditarCuestionario(1,cuest);
                    return Json(new { message = "Editado Correctamente en Create" });
                }               
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Error al crear el cuestionario", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearPreguntas(int _Idcuestionario, preguntaDTO PreguntasDTO,IdConteinerCuestionarios idConteiner)
        {
            List<Pregunta> preg = null;
            try
            {

                if (_Idcuestionario == 0)
                {
                    Console.WriteLine("error en id" + _Idcuestionario);
                    Create();
                    return Json(new {succes=false, message = "No se creo el cuestionario" });
                }
                else
                {
                    Pregunta pregunta = new Pregunta
                    {
                        IdCuestionario = _Idcuestionario,
                        pregunta = PreguntasDTO.pregunta,
                        Estado = false,
                    };
                
                      _context.Preguntas.Add(pregunta);
                      await _context.SaveChangesAsync();
                    idConteiner.IdPregunta = pregunta.IdPregunta;
                    var model = new CuestionarioHR();
                    preg =await _context.Preguntas.Where(e=>e.IdCuestionario == _Idcuestionario).OrderByDescending(e=>e.IdPregunta).ToListAsync();
                    var PreguntaActual = preg.FirstOrDefault();
                    return Json(new { pregunta = PreguntaActual.pregunta, idpregunta = PreguntaActual.IdPregunta });
                        
                }                   
            }
            catch (Exception ex) 
            {
                return Json(new { success = true, message = "Error al Agregar pregunta" + ex.Message.ToString() });

            }
        }
        [HttpPost]
        public async Task<IActionResult> CrearRespuesta([FromBody] List <RespuestaDTO> RespuestasHR,IdConteinerCuestionarios idConteiner)
        {
            try
            {

                if ( IdPregunta == 0)
                {
                    return Json(new { message = "No se creo el cuestionario por respuesta" });

                }
                else
                {
                   
            foreach(var respuesta in RespuestasHR)
                    {
                        var NuevaRespuesta = new Respuesta
                        {
                            respuesta=respuesta.respuesta,
                            RCorrecta=false,
                            IdPregunta=idConteiner.IdPregunta
                        };
                        _context.Respuestas.Add(NuevaRespuesta);
                        await _context.SaveChangesAsync();
                    }
                    return Json(new { success = true, message = "respuestas Agregadas Correctamente" });
                };
                  
                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al Agregar respuesta " + ex.Message.ToString() });

            }

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
        public async Task<IActionResult> EditarCuestionario(int id, Cuestionario cuestionario)
        {
            if (id == cuestionario.IdCuestionario)
            {
                Console.WriteLine(id+ " " + cuestionario.IdCuestionario);
                Console.WriteLine("Error en editar");
                return NotFound();

            }
            
                try
                {
                Console.WriteLine("En editar 1: " + IdCuestionario);
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
