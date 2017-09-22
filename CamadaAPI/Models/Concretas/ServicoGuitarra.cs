using CamadaAPI.Models.Interfaces;
using CamadaComum;
using CamadaDados;
using CamadaDados.Interfaces;
//using Ninject;
using System;
using System.Collections.Generic;

namespace CamadaAPI.Models.Concretas
{
    public class ServicoGuitarra
    {
        /*
        private readonly IRepositorioGuitarra _repositorioGuitarra;
        public ServicoGuitarra(IRepositorioGuitarra repositorioGuitarra)
        {
            _repositorioGuitarra = repositorioGuitarra;
        }
        */
        public static string inserir(string nome, decimal preco, string descricao, string urlImagem)
        {
            RepositorioGuitarra repositorioGuitarra = new RepositorioGuitarra();
            Guitarra guitarra = new Guitarra();
            guitarra.nome = nome;
            guitarra.preco = preco;
            guitarra.descricao = descricao;
            guitarra.urlImagem = urlImagem;
            
            return repositorioGuitarra.inserir(guitarra);
        }

        public static string deletar(int idGuitarra)
        {
            RepositorioGuitarra guitarra = new RepositorioGuitarra();
            return guitarra.excluir(idGuitarra);
        }

        public static List<Object> mostrar()
        {
            RepositorioGuitarra guitarra = new RepositorioGuitarra();
            return guitarra.mostrar();
        }

    }
}