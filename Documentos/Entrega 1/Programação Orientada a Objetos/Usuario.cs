using System;

namespace entregadia30_pi
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Senha { get; set; } = "";
        public string Telefone { get; set; } = "";
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;

        public void Login()
        {
            Console.WriteLine($"{Nome} realizou login.");
        }

        public void Logout()
        {
            Console.WriteLine($"{Nome} saiu do sistema.");
        }

        public void AtualizarPerfil(string nome, string telefone)
        {
            Nome = nome;
            Telefone = telefone;
        }
    }
}