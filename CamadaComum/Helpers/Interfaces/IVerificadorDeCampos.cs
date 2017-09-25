using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaComum.Helpers.Interfaces
{
    public interface IVerificadorDeCampos
    {
        string[] verificarIsNullOrEmpty(string texto);
        string[] verificarTamanhoMaximo(string texto, int tamanhoMaximo);
        string[] verificarDecimal(decimal numero);

    }
}
