using System;
using DentalCare.Refactored;
using DentalCare.Refactored.Interfaces;
using DentalCare.Refactored.Servicios;

namespace DentaCare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DENTAL CARE REFACTORIZADO ===");

            // 1. Instanciamos las dependencias concretas (o simuladas para el ejemplo)
            // En una aplicación real con ASP.NET Core, esto lo haría el contenedor IoC automáticamente.
            IRepositorioCitas repositorio = new RepositorioCitasSimulado(); 
            IServicioNotificacion notificacion = new ServicioNotificacionSimulado();
            CalculadorTarifas calculador = new CalculadorTarifas();

            // 2. Inyectamos las dependencias en nuestro nuevo Gestor refactorizado (Principio DIP)
            GestorCitasRefactorizado gestor = new GestorCitasRefactorizado(repositorio, notificacion, calculador);

            // 3. Probamos el cálculo de una tarifa (Especialidad: Ortodoncia [1], Convenio: EPS [2], Primera vez: Sí, Radiografía: No)
            decimal costoCopago = gestor.ProcesarYCalcularCita(1, 2, true, false);
            
            Console.WriteLine($"El copago calculado para la cita es: ${costoCopago}");
        }
    }

    // Clases temporales de soporte para que compile y pruebes la demostración
    public class RepositorioCitasSimulado : IRepositorioCitas
    {
        public void GuardarCita(Cita cita) { Console.WriteLine("Cita guardada en la base de datos."); }
        public void ActualizarCancelacion(string citaId, decimal penalizacion) { }
    }

    public class ServicioNotificacionSimulado : IServicioNotificacion
    {
        public void EnviarNotificacionCita(Cita cita, string mensaje) { Console.WriteLine($"Notificación enviada: {mensaje}"); }
    }
}