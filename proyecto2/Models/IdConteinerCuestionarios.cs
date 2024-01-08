using proyecto2.Models.dbModels;

namespace proyecto2.Models
{
    public class IdConteinerCuestionarios
    {
        public Cuestionario cuestionario  { get; set; }
        public int IdPregunta  { get; set; }
        public int IdRespuesta  { get; set; }
    }
}
