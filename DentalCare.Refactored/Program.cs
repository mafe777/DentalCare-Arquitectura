using System;
using DentalCare.Refactored;
using DentalCare.Refactored.Servicios;
using DentalCare.Refactored.Interfaces;

// Clases simuladas que implementan las interfaces correctamente
public class RepositorioCitasSimulado : IRepositorioCitas
{
    public void GuardarCita(Cita cita) 
    {
        Console.WriteLine("Cita guardada exitosamente en el repositorio.");
    }

    public void ActualizarCancelacion(string idCita, decimal montoReembolso) 
    {
        Console.WriteLine($"Cancelación actualizada para la cita {idCita}. Reembolso: {montoReembolso}");
    }
}

public class ServicioNotificacionSimulado : IServicioNotificacion
{
    public void EnviarNotificacionCita(Cita cita, string mensaje) 
    {
        Console.WriteLine($"Notificación enviada: {mensaje}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IRepositorioCitas repositorio = new RepositorioCitasSimulado();
        IServicioNotificacion notificacion = new ServicioNotificacionSimulado();
        CalculadorTarifas calculador = new CalculadorTarifas();

        GestorCitasRefactorizado gestor = new GestorCitasRefactorizado(repositorio, notificacion, calculador);

        var cita = new Cita { Id = "1", EspecialidadId = 1, ConvenioId = 1, EsPrimeraVez = true, RequiereRadiografia = false };
        gestor.AgendarCita(cita);
    }
}