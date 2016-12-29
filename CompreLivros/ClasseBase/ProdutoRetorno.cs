using Library;
using Library.Interfaces;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseBase
{
    public class ProdutoRetorno : IRetorno
    {
        SqlDataAdapter objDataAdapter;
        SqlCommand objCommand;

        public IClasse Recuperar(IClasse objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Collections.Hashtable parametros)
        {
            try
            {
                ProdutoTO objProduto = (ProdutoTO)objEnvio;
                SqlParameter[] parametrosProc = new SqlParameter[1];

                parametrosProc[0] = new SqlParameter("@PAR_CodProdID", SqlDbType.Int);
                parametrosProc[0].Direction = ParameterDirection.Input;
                parametrosProc[0].Value = objProduto.CodProdID;

                SqlDataReader dr = SqlHelper.ExecuteReader(objConnection, CommandType.StoredProcedure, "PRODUTOS_RECUPERAR", parametrosProc);

                if (dr.Read())
                {
                    if (dr["Titulo"] != System.DBNull.Value)
                    {
                        objProduto.Titulo = Convert.ToString(dr["Titulo"]); ;
                    }
                    if (dr["ISBN"] != System.DBNull.Value)
                    {
                        objProduto.ISBN = Convert.ToString(dr["ISBN"]); ;
                    }
                    if (dr["Paginas"] != System.DBNull.Value)
                    {
                        objProduto.Paginas = Convert.ToInt32(dr["Paginas"]); ;
                    }
                    if (dr["Edicao"] != System.DBNull.Value)
                    {
                        objProduto.Edicao = Convert.ToInt32(dr["Edicao"]); ;
                    }
                    if (dr["Editora"] != System.DBNull.Value)
                    {
                        objProduto.Editora = Convert.ToString(dr["Editora"]); ;
                    }
                    if (dr["AnoLanca"] != System.DBNull.Value)
                    {
                        objProduto.AnoLanca = Convert.ToInt32(dr["AnoLanca"]); ;
                    }
                    if (dr["CategoriaID"] != System.DBNull.Value)
                    {
                        objProduto.CategoriaID = Convert.ToInt32(dr["CategoriaID"]); ;
                    }
                    if (dr["Idioma"] != System.DBNull.Value)
                    {
                        objProduto.Idioma = Convert.ToString(dr["Idioma"]); ;
                    }
                    if (dr["Sinopse"] != System.DBNull.Value)
                    {
                        objProduto.Sinopse = Convert.ToString(dr["Sinopse"]); ;
                    }

                    if (dr["Preco"] != System.DBNull.Value)
                    {
                        objProduto.Preco = Convert.ToDecimal(dr["Preco"]); ;
                    }

                    if (dr["DtDesativacao"] != System.DBNull.Value)
                    {
                        objProduto.DataDesativacao = Convert.ToDateTime(dr["DtDesativacao"]);
                    }
                    if (dr["DtInclusao"] != System.DBNull.Value)
                    {
                        objProduto.DataInclusao = Convert.ToDateTime(dr["DtInclusao"]);
                    }
                    if (dr["DtAlteracao"] != System.DBNull.Value)
                    {
                        objProduto.DataAlteracao = Convert.ToDateTime(dr["DtAlteracao"]);
                    }

                    dr.Close();
                    return objProduto;
                }
                else
                {
                    dr.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        public System.Data.DataTable Consulta(IClasse objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Collections.Hashtable parametros, System.Data.SqlClient.SqlTransaction objTransacao = null)
        {
            try
            {
                ProdutoTO objProduto = (ProdutoTO)objEnvio;
                List<SqlParameter> listaParametros = new List<SqlParameter>();


                string storedProcedure = "";

                objCommand = new SqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter parametrosObj = new SqlParameter();

                storedProcedure = "PRODUTOS_CONSULTAR";

                objCommand.CommandText = storedProcedure;
                objCommand.Parameters.AddRange(listaParametros.ToArray());
                this.objDataAdapter = new SqlDataAdapter();
                this.objDataAdapter.SelectCommand = objCommand;

                DataTable dt = new DataTable();

                objDataAdapter.SelectCommand.CommandTimeout = 0;

                objDataAdapter.Fill(dt);
                objDataAdapter.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }

        }

        public List<IClasse> Lista(IClasse objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Collections.Hashtable parametros)
        {
            try
            {
                List<IClasse> listaRetorno = new List<IClasse>();
                ItemComboProdutoTO objItem;
                ProdutoTO objProdutoTO = (ProdutoTO)objEnvio;

                //SqlParameter[] parametrosProc = new SqlParameter[2];


                objCommand = new SqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "PRODUTOS_LISTA";
                //objCommand.Parameters.AddRange(parametrosProc);
                this.objDataAdapter = new SqlDataAdapter();
                this.objDataAdapter.SelectCommand = objCommand;

                DataTable dt = new DataTable();
                objDataAdapter.Fill(dt);

                //Linha em branco
                listaRetorno.Add(new ItemComboProdutoTO());

                foreach (DataRow item in dt.Rows)
                {
                    objItem = new ItemComboProdutoTO();

                    objItem.IDItem = item["Código"].ToString().Trim();
                    objItem.Descricao = item["Titulo"].ToString().Trim();
                    objItem.Preco = Convert.ToDecimal(item["Preco"]);


                    listaRetorno.Add(objItem);
                }

                return listaRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        public System.Data.DataTable Grade(IClasse objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Collections.Hashtable parametros)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Relatorio(IClasse objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Collections.Hashtable parametros)
        {
            throw new NotImplementedException();
        }
    }
}
