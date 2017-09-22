using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaAPI.Models.Interfaces
{
    public interface IServicoGuitarra
    {
        string inserir(string nome, decimal preco, string descricao, string urlImagem);
        string deletar(int idGuitarra);
        List<Object> mostrar();
    }
}
