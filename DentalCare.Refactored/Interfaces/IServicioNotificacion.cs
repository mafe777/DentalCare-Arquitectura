namespace DentalCare.Refactored.Interfaces
{
    public interface IServicioNotificacion
    {
        void EnviarNotificacionCita(Cita cita, string mensaje);
    }
}