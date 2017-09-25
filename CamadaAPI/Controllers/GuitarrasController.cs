using System.Web.Http;
using CamadaAPI.Models;
using System.Collections.Generic;
using CamadaComum;

namespace CamadaAPI.Controllers
{
    public class GuitarrasController : ApiController
    {
        private IServicoGuitarra _servicoGuitarra;
        
        public GuitarrasController(IServicoGuitarra servicoGuitarra)
        {
            _servicoGuitarra = servicoGuitarra;
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
                res[1] = _servicoGuitarra.inserir(guitarra); ;
            }

            return res[1];
        }

        public string Delete(int idGuitarra)
        {
            _servicoGuitarra.deletar(idGuitarra);
            return "Guitarra deletada com sucesso";
        }
        
    }
}
