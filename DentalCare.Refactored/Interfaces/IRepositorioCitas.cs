namespace DentalCare.Refactored.Interfaces
{
    public interface IRepositorioCitas
    {
        void GuardarCita(Cita cita);
        void ActualizarCancelacion(string citaId, decimal penalizacion);
    }
}