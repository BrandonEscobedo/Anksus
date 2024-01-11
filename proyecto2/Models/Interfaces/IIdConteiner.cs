namespace proyecto2.Models.Interfaces
{
    public interface IIdConteiner
    {

        int IdCuestionario { get; }
        int IdPregunta { get; }
        int IdRespuesta { get; }
        void SetIdCuestionario(int id);
        void SetIdRespuesta(int id);
        void SetIdPregunta(int id);
        int GetIdCuestionario();
        int GetIdRespuesta();
        int GetIdPregunta();
    }
}
