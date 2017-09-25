using CamadaComum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaAPI.Models
{
    public interface IServicoGuitarra
    {
        string inserir(Guitarra guitarra);
        string deletar(int idGuitarra);
        List<Object> mostrar();
    }
}
