using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using CamadaComum;
using CamadaDados.Interfaces;

namespace CamadaDados
{
    public class RepositorioGuitarra
    {
        public string inserir(Guitarra guitarra)
        {
            string resp = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexao.cn;
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spinserir";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParNome = new SqlParameter();
                sqlParNome.ParameterName = "@nome";
                sqlParNome.SqlDbType = SqlDbType.VarChar;
                sqlParNome.Size = 400;
                sqlParNome.SqlValue = guitarra.nome;
                sqlCmd.Parameters.Add(sqlParNome);

                SqlParameter sqlParPreco = new SqlParameter();
                sqlParPreco.ParameterName = "@preco";
                sqlParPreco.SqlDbType = SqlDbType.Decimal;
                sqlParPreco.Scale = 2;
                sqlParPreco.SqlValue = guitarra.preco;
                sqlCmd.Parameters.Add(sqlParPreco);

                SqlParameter sqlParDescricao = new SqlParameter();
                sqlParDescricao.ParameterName = "@descricao";
                sqlParDescricao.SqlDbType = SqlDbType.VarChar;
                sqlParDescricao.Size = 1000;
                sqlParDescricao.SqlValue = guitarra.descricao;
                sqlCmd.Parameters.Add(sqlParDescricao);

                DateTime dataAgora = DateTime.Now;
                string dataAgoraSql = dataAgora.ToString("yyyy-MM-dd HH:mm:ss.fff");

                SqlParameter sqlParDataInclusao = new SqlParameter();
                sqlParDataInclusao.ParameterName = "@data_inclusao";
                sqlParDataInclusao.SqlDbType = SqlDbType.Date;
                sqlParDataInclusao.SqlValue = dataAgoraSql;
                sqlCmd.Parameters.Add(sqlParDataInclusao);

                SqlParameter sqlParUrlImagem = new SqlParameter();
                sqlParUrlImagem.ParameterName = "@url_imagem";
                sqlParUrlImagem.SqlDbType = SqlDbType.VarChar;
                sqlParUrlImagem.Size = 512;
                sqlParUrlImagem.SqlValue = guitarra.urlImagem;
                sqlCmd.Parameters.Add(sqlParUrlImagem);

                string sku = "";
                try
                {
                    int idUltimaGuitarra = pegarUltimoRegistro(sqlCon);
                    sku = criarSKU(idUltimaGuitarra, guitarra.nome);
                }
                catch (Exception ex)
                {
                    sku = criarSKU(1, guitarra.nome);
                }

                SqlParameter sqlParSku = new SqlParameter();
                sqlParSku.ParameterName = "@sku";
                sqlParSku.SqlDbType = SqlDbType.VarChar;
                sqlParSku.Size = 500;
                sqlParSku.SqlValue = sku;
                sqlCmd.Parameters.Add(sqlParSku);

                resp = sqlCmd.ExecuteNonQuery() == 1 ? "OK" :"Registro não inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if(sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return resp;
        }

        public int pegarUltimoRegistro(SqlConnection sqlCon)
        {
            int idRegistro = 0;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = "sppegar_ultimo_registro";
            sqlCmd.CommandType = CommandType.StoredProcedure;

            idRegistro = (int)sqlCmd.ExecuteScalar();
            return idRegistro;
        }

        public string criarSKU(int id, string nome)
        {
            string sku = (id+1) +"_"+ nome;
            sku = sku.ToLower();
            sku = sku.Replace(' ','_');

            return sku;
        }

        public List<Object> mostrar()
        {
            SqlConnection sqlCon = new SqlConnection();
            var guitarras = new List<Object>();
            try
            {
                sqlCon.ConnectionString = Conexao.cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = sqlCon;
                SqlCmd.CommandText = "spmostrar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();
                SqlDataReader reader = SqlCmd.ExecuteReader();

                while (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Guitarra guitarra = new Guitarra();
                        guitarra.id = reader.GetInt32(0);
                        guitarra.nome = reader.GetString(1);
                        guitarra.preco = (decimal)reader.GetValue(2);
                        guitarra.descricao = reader.GetString(3);
                        guitarra.dataInclusao = (DateTime)reader.GetValue(4);
                        guitarra.urlImagem = reader.GetString(5);

                        guitarras.Add(guitarra);
                    }
                    reader.NextResult();
                }
            }
            catch (Exception ex)
            {
                guitarras.Add(ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return guitarras;
        }

        public string excluir(int idGuitarra)
        {
            string resp = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexao.cn;
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "spdeletar";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParId = new SqlParameter();
                sqlParId.ParameterName = "@idguitarra";
                sqlParId.SqlDbType = SqlDbType.Int;
                sqlParId.SqlValue = idGuitarra;
                sqlCmd.Parameters.Add(sqlParId);

                resp = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            
            return resp;
        }
    }
}
