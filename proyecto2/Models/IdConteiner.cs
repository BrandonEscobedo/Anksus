using proyecto2.Models.dbModels;
using proyecto2.Models.Interfaces;

namespace proyecto2.Models
{
    public class IdConteiner:IIdConteiner
    {
    

     public  int IdCuestionario { get; private set; }
    public int IdPregunta { get; private set; }
    public int IdRespuesta { get; private set; }

        public void SetIdCuestionario(int id)
        {
            IdCuestionario = id;
        }

      public  void SetIdPregunta(int id)
        {
            IdPregunta = id;
        }
        public void SetIdRespuesta(int id)
        {
            IdRespuesta = id;
        }

        int IIdConteiner.GetIdCuestionario()
        {
            return IdCuestionario;        
      }

        int IIdConteiner.GetIdPregunta()
        {
            return IdPregunta;
        }

        int IIdConteiner.GetIdRespuesta()
        {
            return IdRespuesta;
        }

    }
}
