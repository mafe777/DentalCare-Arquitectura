using DentalCare.Refactored.Interfaces;
using DentalCare.Refactored.Servicios;

namespace DentalCare.Refactored
{
    public class GestorCitasRefactorizado
    {
        private readonly IRepositorioCitas _repositorioCitas;
        private readonly IServicioNotificacion _servicioNotificacion;
        private readonly CalculadorTarifas _calculadorTarifas;

        // Inyección de Dependencias a través del constructor (Principio DIP y OCP)
        public GestorCitasRefactorizado(
            IRepositorioCitas repositorioCitas,
            IServicioNotificacion servicioNotificacion,
            CalculadorTarifas calculadorTarifas)
        {
            _repositorioCitas = repositorioCitas;
            _servicioNotificacion = servicioNotificacion;
            _calculadorTarifas = calculadorTarifas;
        }

        public decimal ProcesarYCalcularCita(int tipoEspecialidad, int tipoConvenio, bool esPrimeraVez, bool requiereRadiografia)
        {
            // Delegamos el cálculo de tarifas a su clase especializada (SRP)
            return _calculadorTarifas.CalcularCopago(tipoEspecialidad, tipoConvenio, esPrimeraVez, requiereRadiografia);
        }

        public void AgendarCita(Cita cita)
        {
            // Guardamos usando la abstracción (DIP)
            _repositorioCitas.GuardarCita(cita);

            // Notificamos usando el servicio inyectado
            _servicioNotificacion.EnviarNotificacionCita(cita, "Su cita ha sido agendada con éxito.");
        }
    }
}