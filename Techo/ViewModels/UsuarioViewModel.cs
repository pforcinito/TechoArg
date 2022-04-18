namespace Techo.ViewModels
{
    public class UsuarioViewModel
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public bool Activo { get; set; }
    }
}