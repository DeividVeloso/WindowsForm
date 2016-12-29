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
    public class ClienteRetorno : IRetorno
    {
        SqlDataAdapter objDataAdapter;
        SqlCommand objCommand;

        public IClasse Recuperar(IClasse objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Collections.Hashtable parametros)
        {
            try
            {
               ClienteTO objCliente = (ClienteTO)objEnvio;
                SqlParameter[] parametrosProc = new SqlParameter[1];

                parametrosProc[0] = new SqlParameter("@PAR_CodCliID", SqlDbType.Int);
                parametrosProc[0].Direction = ParameterDirection.Input;
                parametrosProc[0].Value = objCliente.CodCliID;

                SqlDataReader dr = SqlHelper.ExecuteReader(objConnection, CommandType.StoredProcedure, "CLIENTES_RECUPERAR", parametrosProc);

                if (dr.Read())
                {
                    if (dr["Nome"] != System.DBNull.Value)
                    {
                        objCliente.Nome = Convert.ToString(dr["Nome"]); ;
                    }


                    if (dr["CPF"] != System.DBNull.Value)
                    {
                        objCliente.CPF = Convert.ToString(dr["CPF"]);
                    }

                    if (dr["DtNascimento"] != System.DBNull.Value)
                    {
                        objCliente.DtNascimento = Convert.ToDateTime(dr["DtNascimento"]);
                    }

                    if (dr["Sexo"] != System.DBNull.Value)
                    {
                        objCliente.Sexo = Convert.ToString(dr["Sexo"]);
                    }

                    if (dr["Telefone"] != System.DBNull.Value)
                    {
                        objCliente.Telefone = Convert.ToString(dr["Telefone"]);
                    }
                    if (dr["Celular"] != System.DBNull.Value)
                    {
                        objCliente.Celular = Convert.ToString(dr["Celular"]);
                    }
                    if (dr["Email"] != System.DBNull.Value)
                    {
                        objCliente.Email = Convert.ToString(dr["Email"]);
                    }
                    if (dr["DataDesativacao"] != System.DBNull.Value)
                    {
                        objCliente.DataDesativacao = Convert.ToDateTime(dr["DataDesativacao"]);
                    }
                    if (dr["DataInclusao"] != System.DBNull.Value)
                    {
                        objCliente.DataInclusao = Convert.ToDateTime(dr["DataInclusao"]);
                    }
                    if (dr["DtAlteracao"] != System.DBNull.Value)
                    {
                        objCliente.DataAlteracao = Convert.ToDateTime(dr["DtAlteracao"]);
                    }

                    dr.Close();
                    return objCliente;
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
                ClienteTO objCliente = (ClienteTO)objEnvio;
                List<SqlParameter> listaParametros = new List<SqlParameter>();


                string storedProcedure = "";

                objCommand = new SqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter parametrosObj = new SqlParameter();

                if (parametros != null)
                {
                    if (parametros.ContainsKey("Cpf"))
                    {
                        parametrosObj = new SqlParameter();
                        parametrosObj = new SqlParameter("@PAR_CPF", SqlDbType.TinyInt);
                        parametrosObj.Direction = ParameterDirection.Input;
                        parametrosObj.Value = objCliente.CPF;

                        listaParametros.Add(parametrosObj);

                        storedProcedure = "CLIENTE_CONSULTAR_CPF";
                    }

                }
                else
                {
                    storedProcedure = "CLIENTES_CONSULTAR";
                }


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
                ClienteTO objCliente = (ClienteTO)objEnvio;

                //SqlParameter[] parametrosProc = new SqlParameter[2];


                objCommand = new SqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "CLIENTES_LISTA";
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
