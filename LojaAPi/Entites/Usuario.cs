namespace LojaAPi.Entites
{
    public class Usuario
    {
        public int Id { get; set; } // O push é utilizado apenas quando for para incluir dados em uma lista, apenas incluir para atualizar é utilizado por exemplo o for, mas nesse momento aqui estamos se referindo a um objeto e não a uma lista 
        public string Password { get; set; }
        public int Tipo { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

        
    }
}
