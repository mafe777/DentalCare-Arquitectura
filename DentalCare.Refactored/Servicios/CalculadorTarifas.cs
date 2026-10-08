namespace DentalCare.Refactored.Servicios
{
    public class CalculadorTarifas
    {
        public decimal CalcularCopago(int tipoEspecialidad, int tipoConvenio, bool esPrimeraVez, bool requiereRadiografia)
        {
            decimal costoConsulta = 100.0m;
            decimal copagoFinal = 0;

            // Especialidades
            if (tipoEspecialidad == 1) // Ortodoncia
            {
                copagoFinal = costoConsulta * 1.2m;
            }
            else if (tipoEspecialidad == 2) // Endodoncia
            {
                copagoFinal = costoConsulta * 1.8m;
            }
            else if (tipoEspecialidad == 3) // Cirugía
            {
                copagoFinal = costoConsulta * 2.5m;
            }
            else if (tipoEspecialidad == 4) // Odontopediatría
            {
                copagoFinal = costoConsulta * 1.1m;
            }

            // Descuentos por convenio
            if (tipoConvenio == 2) // EPS
            {
                copagoFinal *= 0.30m;
            }
            else if (tipoConvenio == 3) // Prepagada
            {
                copagoFinal *= 0.10m;
            }

            // Recargos adicionales
            if (esPrimeraVez)
            {
                copagoFinal += 20.0m;
            }

            if (requiereRadiografia)
            {
                copagoFinal += 35.0m;
            }

            return copagoFinal;
        }
    }
}