namespace DentalCare.Refactored
{
    public class Cita
    {
        public string Id { get; set; }= string.Empty;
        public int EspecialidadId { get; set; }
        public int ConvenioId { get; set; }
        public bool EsPrimeraVez { get; set; }
        public bool RequiereRadiografia { get; set; }
    }
}