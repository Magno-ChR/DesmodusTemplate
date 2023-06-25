namespace DesmodusTemplate.DTOs
{
    public class UserJWTClaims
    {
        public string ID { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string IdRol { get; set; }
        public string Rol { get; set; }
    }
}
