using Automacao.Api.Controllers;
using Automacao.Api.ViewModel;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Automacao.Test
{
    public class ASCControllerTests
    {
        [Fact]
        public void Autenticacao()
        {
            //arrange
            var controller = new AscController();

            // act
            var usuario = new UsuarioLoginViewModel
            {
                Nome = "TER02699@robotbrasil",
                Senha = "Passw0rd"
            };

            var result = controller.Logar(usuario);

            // assert

        }
    }
}
