using CamadaComum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados.Interfaces
{
    public interface IRepositorioGuitarra
    {
        string inserir(Guitarra guitarra);
        int pegarUltimoRegistro(SqlConnection sqlCon);
        string criarSKU(int id, string nome);
        List<Object> mostrar();
        string excluir(int idGuitarra);
    }
}
