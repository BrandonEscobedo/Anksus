namespace proyecto2.Models
{
    public class CuestionarioHR
    {
        
        public int IdCuestionario { get; set; }
       
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
     
        public bool Estado { get; set; }
    
        public string? Titulo { get; set; }
     
        public bool Publico { get; set; }
    }
}
