using System;

namespace entregadia30_pi
{
    public class Administrador : Usuario
    {
        public void AprovarAnuncio(Anuncio anuncio)
        {
            anuncio.Status = "Ativo";
            anuncio.MotivoReprovacao = "";
            Console.WriteLine($"Anúncio '{anuncio.Titulo}' aprovado.");
        }

        public void ReprovarAnuncio(Anuncio anuncio, string motivo)
        {
            anuncio.Status = "Reprovado";
            anuncio.MotivoReprovacao = motivo;
            Console.WriteLine($"Anúncio '{anuncio.Titulo}' reprovado. Motivo: {motivo}");
        }

        public void BloquearUsuario(Usuario usuario)
        {
            usuario.Ativo = false;
            Console.WriteLine($"Usuário '{usuario.Nome}' foi bloqueado.");
        }

        public void DesbloquearUsuario(Usuario usuario)
        {
            usuario.Ativo = true;
            Console.WriteLine($"Usuário '{usuario.Nome}' foi desbloqueado.");
        }
    }
}
