using CompreLivros;
using Library;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseBase
{
    public class ProdutoEnvio : IEnvio
    {
        public int Incluir(List<List<IClasse>> objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Data.SqlClient.SqlTransaction objTransacao)
        {
            try
            {
                Int32 intCodigo = 0;
                SqlParameter[] parametros = new SqlParameter[11];
                ProdutoTO objProduto;

                parametros[0] = new SqlParameter("@PAR_Titulo", SqlDbType.VarChar);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_ISBN", SqlDbType.VarChar);
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@PAR_Paginas", SqlDbType.Int);
                parametros[2].Direction = ParameterDirection.Input;
                parametros[3] = new SqlParameter("@PAR_Edicao", SqlDbType.Char);
                parametros[3].Direction = ParameterDirection.Input;
                parametros[4] = new SqlParameter("@PAR_Editora", SqlDbType.VarChar);
                parametros[4].Direction = ParameterDirection.Input;
                parametros[5] = new SqlParameter("@PAR_AnoLanca", SqlDbType.Int);
                parametros[5].Direction = ParameterDirection.Input;
                parametros[6] = new SqlParameter("@PAR_CategoriaID", SqlDbType.Int);
                parametros[6].Direction = ParameterDirection.Input;
                parametros[7] = new SqlParameter("@PAR_Idioma", SqlDbType.VarChar);
                parametros[7].Direction = ParameterDirection.Input;
                parametros[8] = new SqlParameter("@PAR_Sinopse", SqlDbType.VarChar);
                parametros[8].Direction = ParameterDirection.Input;
                parametros[9] = new SqlParameter("@PAR_DtDesativacao", SqlDbType.DateTime);
                parametros[9].Direction = ParameterDirection.Input;
                parametros[10] = new SqlParameter("@PAR_Preco", SqlDbType.Decimal);
                parametros[10].Direction = ParameterDirection.Input;
                      
                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objProduto = (ProdutoTO)obj;
                        parametros[0].Value = objProduto.Titulo;
                        parametros[1].Value = FuncoesUtils.RecuperaValor(objProduto.ISBN);
                        parametros[2].Value = FuncoesUtils.RecuperaValor(objProduto.Paginas);
                        parametros[3].Value = FuncoesUtils.RecuperaValor(objProduto.Edicao);
                        parametros[4].Value = FuncoesUtils.RecuperaValor(objProduto.Editora);
                        parametros[5].Value = FuncoesUtils.RecuperaValor(objProduto.AnoLanca);
                        parametros[6].Value = FuncoesUtils.RecuperaValor(objProduto.CategoriaID);
                        parametros[7].Value = FuncoesUtils.RecuperaValor(objProduto.Idioma);
                        parametros[8].Value = FuncoesUtils.RecuperaValor(objProduto.Sinopse);
                        parametros[9].Value = FuncoesUtils.RecuperaValor(objProduto.DataDesativacao);
                        parametros[10].Value = FuncoesUtils.RecuperaValor(objProduto.Preco);

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "PRODUTOS_INCLUIR";
                        objCommand.Parameters.Clear();
                        objCommand.Parameters.AddRange(parametros);
                        intCodigo += objCommand.ExecuteNonQuery();
                    }
                }

                return intCodigo;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        public int Alterar(List<List<IClasse>> objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Data.SqlClient.SqlTransaction objTransacao)
        {
            try
            {
                Int32 intCodigo = 0;
                SqlParameter[] parametros = new SqlParameter[12];
                ProdutoTO objProduto;

                parametros[0] = new SqlParameter("@PAR_Titulo", SqlDbType.VarChar);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_ISBN", SqlDbType.VarChar);
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@PAR_Paginas", SqlDbType.Int);
                parametros[2].Direction = ParameterDirection.Input;
                parametros[3] = new SqlParameter("@PAR_Edicao", SqlDbType.Char);
                parametros[3].Direction = ParameterDirection.Input;
                parametros[4] = new SqlParameter("@PAR_Editora", SqlDbType.VarChar);
                parametros[4].Direction = ParameterDirection.Input;
                parametros[5] = new SqlParameter("@PAR_AnoLanca", SqlDbType.Int);
                parametros[5].Direction = ParameterDirection.Input;
                parametros[6] = new SqlParameter("@PAR_CategoriaID", SqlDbType.Int);
                parametros[6].Direction = ParameterDirection.Input;
                parametros[7] = new SqlParameter("@PAR_Idioma", SqlDbType.VarChar);
                parametros[7].Direction = ParameterDirection.Input;
                parametros[8] = new SqlParameter("@PAR_Sinopse", SqlDbType.VarChar);
                parametros[8].Direction = ParameterDirection.Input;
                parametros[9] = new SqlParameter("@PAR_DtDesativacao", SqlDbType.DateTime);
                parametros[9].Direction = ParameterDirection.Input;
                parametros[10] = new SqlParameter("@PAR_Preco", SqlDbType.Decimal);
                parametros[10].Direction = ParameterDirection.Input;
                parametros[11] = new SqlParameter("@PAR_CodProdID", SqlDbType.Int);
                parametros[11].Direction = ParameterDirection.Input;

                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objProduto = (ProdutoTO)obj;
                        parametros[0].Value = objProduto.Titulo;
                        parametros[1].Value = FuncoesUtils.RecuperaValor(objProduto.ISBN);
                        parametros[2].Value = FuncoesUtils.RecuperaValor(objProduto.Paginas);
                        parametros[3].Value = FuncoesUtils.RecuperaValor(objProduto.Edicao);
                        parametros[4].Value = FuncoesUtils.RecuperaValor(objProduto.Editora);
                        parametros[5].Value = FuncoesUtils.RecuperaValor(objProduto.AnoLanca);
                        parametros[6].Value = FuncoesUtils.RecuperaValor(objProduto.CategoriaID);
                        parametros[7].Value = FuncoesUtils.RecuperaValor(objProduto.Idioma);
                        parametros[8].Value = FuncoesUtils.RecuperaValor(objProduto.Sinopse);
                        parametros[9].Value = FuncoesUtils.RecuperaValor(objProduto.DataDesativacao);
                        parametros[10].Value = FuncoesUtils.RecuperaValor(objProduto.Preco);
                        parametros[11].Value = FuncoesUtils.RecuperaValor(objProduto.CodProdID);


                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "PRODUTOS_ALTERAR";
                        objCommand.Parameters.Clear();
                        objCommand.Parameters.AddRange(parametros);
                        intCodigo += objCommand.ExecuteNonQuery();
                    }
                }

                return intCodigo;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        public int Excluir(List<List<IClasse>> objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Data.SqlClient.SqlTransaction objTransacao)
        {

            try
            {
                SqlParameter[] parametros = new SqlParameter[1];
                ProdutoTO objProduto = new ProdutoTO();
                Int32 intRegistrosAfetados = 0;
                SqlCommand objCommand = new SqlCommand();

                parametros[0] = new SqlParameter("@PAR_CodProdID", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.Input;

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objProduto = (ProdutoTO)obj;
                        parametros[0].Value = objProduto.CodProdID;

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "PRODUTOS_EXCLUIR";
                        objCommand.Parameters.Clear();
                        objCommand.Parameters.AddRange(parametros);
                        intRegistrosAfetados += objCommand.ExecuteNonQuery();
                    }
                }

                return intRegistrosAfetados;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }
    }
}
