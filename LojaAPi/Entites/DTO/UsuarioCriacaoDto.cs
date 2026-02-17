namespace LojaAPi.Entites.DTO
{
    public class UsuarioCriacaoDto
    {
        public string? Password { get; set; }
        public int Tipo { get; set; }
        public string Email { get; set; }

        public int? Id { get; set; }
    }
}
