using CamadaComum.Helpers;
using System;

namespace CamadaComum
{
    public class Guitarra
    {
        public int id;
        public string nome;
        public decimal preco;
        public string descricao;
        public DateTime dataInclusao;
        public string urlImagem;
        public string sku;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }
        public decimal Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }
        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }
        public DateTime DataInclusao
        {
            get
            {
                return dataInclusao;
            }

            set
            {
                dataInclusao = value;
            }
        }
        public string UrlImagem
        {
            get
            {
                return urlImagem;
            }

            set
            {
                urlImagem = value;
            }
        }
        public string Sku
        {
            get
            {
                return sku;
            }

            set
            {
                sku = value;
            }
        }

        public Guitarra()
        {
        }

        public Guitarra(int id, string nome, decimal preco, string descricao, DateTime dataInclusao,
            string urlImagem)
        {
            this.nome = nome;
            this.preco = preco;
            this.descricao = descricao;
            this.dataInclusao = dataInclusao;
            this.urlImagem = urlImagem;
        }

        public string[] verificarCampos(Guitarra guitarra)
        {
            string[] campos = new string[2];
            VerificadorDeCampos verificadorDeCampos = new VerificadorDeCampos();

            campos = verificadorDeCampos.verificarIsNullOrEmpty(guitarra.nome);
            if (campos[0] == "Not OK") return campos;
            campos = verificadorDeCampos.verificarTamanhoMaximo(guitarra.nome, 400);
            if (campos[0] == "Not OK") return campos;

            campos = verificadorDeCampos.verificarIsNullOrEmpty(guitarra.descricao);
            if (campos[0] == "Not OK") return campos;
            campos = verificadorDeCampos.verificarTamanhoMaximo(guitarra.nome, 400);
            if (campos[0] == "Not OK") return campos;

            campos = verificadorDeCampos.verificarDecimal(guitarra.preco);
            if (campos[0] == "Not OK") return campos;

            return campos;
        }
    }
}
