using MessagePack;
using Microsoft.AspNetCore.Mvc.Rendering;
using proyecto2.Models.dbModels;
using proyecto2.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace proyecto2.Models.ViewModel
{

    public class CuestionarioHR
    {
        public int IdCuestionario { get; set; }
        public int IdPregunta { get; set; }
        public List<Cuestionario> cuestionario { get; set; }
        public CuestionarioDTO? AgregarCuestionario { get; set; }
        public Categoria? Categoria { get; set; }
        public List<Categoria>? Categorias { get; set; }
        public List<Pregunta>? Preguntas { get; set; }
        public Pregunta? AgregarPregunta { get; set; }
        public List<Respuesta> Respuestas { get; set; }

        public CuestionarioHR()
        {
            Categorias = new List<Categoria>();
            AgregarCuestionario = new CuestionarioDTO();
            cuestionario = new List<Cuestionario>();
            Respuestas = new List<Respuesta>();
            Preguntas = new List<Pregunta>();
        }


    }



}
