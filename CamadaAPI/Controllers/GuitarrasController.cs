using System.Web.Http;
using CamadaAPI.Models;
using System.Collections.Generic;
using CamadaComum;
using CamadaAPI.Models.Interfaces;
using CamadaAPI.Models.Concretas;
//using Ninject;

namespace CamadaAPI.Controllers
{
    public class GuitarrasController : ApiController
    {
        
        public List<object> Get()
        {
            return ServicoGuitarra.mostrar();
        }

        [HttpPost]
        public string Post([FromUri] Guitarra guitarra)
        {
            string[] res = guitarra.verificarCampos(guitarra);

            if (res[0] == "OK")
            {
                res[1] = ServicoGuitarra.inserir(guitarra.nome, guitarra.preco, guitarra.descricao,
                    guitarra.urlImagem); ;
            }

            return res[1];
        }

        public string Delete(int idGuitarra)
        {
            ServicoGuitarra.deletar(idGuitarra);
            return "Guitarra deletada com sucesso";
        }

        /*
        public readonly IServicoGuitarra _servicoGuitarra;
        public GuitarrasController(IServicoGuitarra repositorioGuitarra)
        {
            _servicoGuitarra = repositorioGuitarra;
        }

        public List<object> Get()
        {
            return _servicoGuitarra.mostrar();
        }
        
        [HttpPost]
        public string Post([FromUri] Guitarra guitarra)
        {
            string[] res = guitarra.verificarCampos(guitarra);

            if (res[0] == "OK")
            {
                res[1] = _servicoGuitarra.inserir(guitarra.nome, guitarra.preco, guitarra.descricao,
                    guitarra.urlImagem); ;
            }

            return res[1];
        }
        
        public string Delete(int idGuitarra)
        {
            _servicoGuitarra.deletar(idGuitarra);
            return "Guitarra deletada com sucesso";
        }
        
    */
    }
}
