using Microsoft.AspNetCore.Mvc.Rendering;
using proyecto2.Models;
using proyecto2.Models.dbModels;
using proyecto2.Models.DTO;

namespace proyecto2.ViewModel
{
    public class CPRmodel
    {
        public Cuestionario  cuestionario { get; set; } = null!;
       public Pregunta   pregunta { get; set; }=null!;
       
    }
}
