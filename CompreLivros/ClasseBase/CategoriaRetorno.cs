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
    public class CategoriaRetorno : IRetorno
    {
        SqlDataAdapter objDataAdapter;
        SqlCommand objCommand;

        public IClasse Recuperar(IClasse objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Collections.Hashtable parametros)
        {
            try
            {
                CategoriaTO objCategoria = (CategoriaTO)objEnvio;
                SqlParameter[] parametrosProc = new SqlParameter[1];

                parametrosProc[0] = new SqlParameter("@PAR_CategoriaID", SqlDbType.Int);
                parametrosProc[0].Direction = ParameterDirection.Input;
                parametrosProc[0].Value = objCategoria.CategoriaID;

                SqlDataReader dr = SqlHelper.ExecuteReader(objConnection, CommandType.StoredProcedure, "CATEGORIAS_RECUPERAR", parametrosProc);

                if (dr.Read())
                {
                    if (dr["Nome"] != System.DBNull.Value)
                    {
                        objCategoria.Nome = Convert.ToString(dr["Nome"]); ;
                    }

                    if (dr["DtDesativacao"] != System.DBNull.Value)
                    {
                        objCategoria.DataDesativacao = Convert.ToDateTime(dr["DtDesativacao"]);
                    }
                    if (dr["DtInclusao"] != System.DBNull.Value)
                    {
                        objCategoria.DataInclusao = Convert.ToDateTime(dr["DtInclusao"]);
                    }
                    if (dr["DtAlteracao"] != System.DBNull.Value)
                    {
                        objCategoria.DataAlteracao = Convert.ToDateTime(dr["DtAlteracao"]);
                    }

                    dr.Close();
                    return objCategoria;
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
                CategoriaTO objCategoria = (CategoriaTO)objEnvio;
                List<SqlParameter> listaParametros = new List<SqlParameter>();


                string storedProcedure = "";

                objCommand = new SqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter parametrosObj = new SqlParameter();

                storedProcedure = "CATEGORIAS_CONSULTAR";

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
                ItemComboTO objItem;
                CategoriaTO objCategoriaTO = (CategoriaTO)objEnvio;

                //SqlParameter[] parametrosProc = new SqlParameter[2];

               
                    objCommand = new SqlCommand();
                    objCommand.Connection = objConnection;
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "CATEGORIAS_LISTA";
                    //objCommand.Parameters.AddRange(parametrosProc);
                    this.objDataAdapter = new SqlDataAdapter();
                    this.objDataAdapter.SelectCommand = objCommand;

                    DataTable dt = new DataTable();
                    objDataAdapter.Fill(dt);

                    //Linha em branco
                    listaRetorno.Add(new ItemComboTO());

                    foreach (DataRow item in dt.Rows)
                    {
                        objItem = new ItemComboTO();

                        objItem.IDItem = item["Código"].ToString().Trim();
                        objItem.Descricao = item["Nome"].ToString().Trim();

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
