namespace DesmodusTemplate.Entities.Autores
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPais { get; set; }
        public bool Estado { get; set; }


    }
}
