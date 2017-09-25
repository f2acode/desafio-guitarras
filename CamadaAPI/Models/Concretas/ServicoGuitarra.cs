using CamadaComum;
using CamadaDados;
using System;
using System.Collections.Generic;

namespace CamadaAPI.Models
{
    public class ServicoGuitarra : IServicoGuitarra
    {
        private readonly IRepositorioGuitarra _repositorioGuitarra;
        public ServicoGuitarra(IRepositorioGuitarra repositorioGuitarra)
        {
            _repositorioGuitarra = repositorioGuitarra;
        }
        
        public string inserir(Guitarra guitarra)
        {
            return _repositorioGuitarra.inserir(guitarra);
        }

        public string deletar(int idGuitarra)
        {
            return _repositorioGuitarra.excluir(idGuitarra);
        }

        public List<Object> mostrar()
        {
            return _repositorioGuitarra.mostrar();
        }

    }
}