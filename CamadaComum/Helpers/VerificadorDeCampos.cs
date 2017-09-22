using System.Text.RegularExpressions;

namespace CamadaComum.Helpers
{
    public class VerificadorDeCampos
    {
        public string[] verificarIsNullOrEmpty(string texto)
        {
            string[] campos = new string[2];
            if (string.IsNullOrEmpty(texto))
            {
                campos[0] = "Not OK";
                campos[1] = "Campo obrigatório não preenchido.";
                return campos;
            }
            campos[0] = "OK";
            return campos;
        }

        public string[] verificarTamanhoMaximo(string texto, int tamanhoMaximo)
        {
            string[] campos = new string[2];
            if (texto.Length > tamanhoMaximo)
            {
                campos[0] = "Not OK";
                campos[1] = "Tamanho do texto("+texto.Length+") excedeu o tamanho máximo "+
                    "permitido (" + tamanhoMaximo.ToString()+").";
                return campos;
            }
            campos[0] = "OK";
            return campos;
        }

        public string[] verificarDecimal(decimal numero)
        {
            string[] campos = new string[2];
            if (!Regex.IsMatch(numero.ToString(), "^[0-9]+(\\,[0-9]{2})$"))
            {
                campos[0] = "Not OK";
                campos[1] = "Número enviado inválido ("+numero+"), é necessário "+
                "enviar um número decimal com duas casas de precisão. Ex: 100,00";
                return campos;
            }
            campos[0] = "OK";
            return campos;
        }
        
    }
}