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
    public class ClienteEnvio : IEnvio
    {
        public int Incluir(List<List<IClasse>> objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Data.SqlClient.SqlTransaction objTransacao)
        {
            try
            {
                Int32 intCodigo = 0;
                SqlParameter[] parametros = new SqlParameter[8];
                ClienteTO objCliente;

                parametros[0] = new SqlParameter("@PAR_Nome", SqlDbType.VarChar);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_CPF", SqlDbType.VarChar);
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@PAR_DtNascimento", SqlDbType.SmallDateTime);
                parametros[2].Direction = ParameterDirection.Input;
                parametros[3] = new SqlParameter("@PAR_Sexo", SqlDbType.Char);
                parametros[3].Direction = ParameterDirection.Input;
                parametros[4] = new SqlParameter("@PAR_Telefone", SqlDbType.VarChar);
                parametros[4].Direction = ParameterDirection.Input;
                parametros[5] = new SqlParameter("@PAR_Celular", SqlDbType.VarChar);
                parametros[5].Direction = ParameterDirection.Input;
                parametros[6] = new SqlParameter("@PAR_Email", SqlDbType.VarChar);
                parametros[6].Direction = ParameterDirection.Input;
                parametros[7] = new SqlParameter("@PAR_DataDesativacao", SqlDbType.SmallDateTime);
                parametros[7].Direction = ParameterDirection.Input;

                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objCliente = (ClienteTO)obj;
                        parametros[0].Value = objCliente.Nome;
                        parametros[1].Value = objCliente.CPF;
                        parametros[2].Value = FuncoesUtils.RecuperaValor(objCliente.DtNascimento);
                        parametros[3].Value = FuncoesUtils.RecuperaValor(objCliente.Sexo);
                        parametros[4].Value = FuncoesUtils.RecuperaValor(objCliente.Telefone);
                        parametros[5].Value = FuncoesUtils.RecuperaValor(objCliente.Celular);
                        parametros[6].Value = FuncoesUtils.RecuperaValor(objCliente.Email);
                        parametros[7].Value = FuncoesUtils.RecuperaValor(objCliente.DataDesativacao);


                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "CLIENTES_INCLUIR";//Constantes.RH_CARGO_INCLUIR;
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
                SqlParameter[] parametros = new SqlParameter[9];
                ClienteTO objCliente;

                parametros[0] = new SqlParameter("@PAR_Nome", SqlDbType.VarChar);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_CPF", SqlDbType.VarChar);
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@PAR_DtNascimento", SqlDbType.SmallDateTime);
                parametros[2].Direction = ParameterDirection.Input;
                parametros[3] = new SqlParameter("@PAR_Sexo", SqlDbType.Char);
                parametros[3].Direction = ParameterDirection.Input;
                parametros[4] = new SqlParameter("@PAR_Telefone", SqlDbType.VarChar);
                parametros[4].Direction = ParameterDirection.Input;
                parametros[5] = new SqlParameter("@PAR_Celular", SqlDbType.VarChar);
                parametros[5].Direction = ParameterDirection.Input;
                parametros[6] = new SqlParameter("@PAR_Email", SqlDbType.VarChar);
                parametros[6].Direction = ParameterDirection.Input;
                parametros[7] = new SqlParameter("@PAR_DataDesativacao", SqlDbType.SmallDateTime);
                parametros[7].Direction = ParameterDirection.Input;
                parametros[8] = new SqlParameter("@PAR_CodCliID", SqlDbType.Int);
                parametros[8].Direction = ParameterDirection.Input;

                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objCliente = (ClienteTO)obj;
                        parametros[0].Value = objCliente.Nome;
                        parametros[1].Value = objCliente.CPF;
                        parametros[2].Value = FuncoesUtils.RecuperaValor(objCliente.DtNascimento);
                        parametros[3].Value = FuncoesUtils.RecuperaValor(objCliente.Sexo);
                        parametros[4].Value = FuncoesUtils.RecuperaValor(objCliente.Telefone);
                        parametros[5].Value = FuncoesUtils.RecuperaValor(objCliente.Celular);
                        parametros[6].Value = FuncoesUtils.RecuperaValor(objCliente.Email);
                        parametros[7].Value = FuncoesUtils.RecuperaValor(objCliente.DataDesativacao);
                        parametros[8].Value = FuncoesUtils.RecuperaValor(objCliente.CodCliID);

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "CLIENTES_ALTERAR";//Constantes.RH_CARGO_INCLUIR;
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
                ClienteTO objCliente = new ClienteTO();
                Int32 intRegistrosAfetados = 0;
                SqlCommand objCommand = new SqlCommand();

                parametros[0] = new SqlParameter("@PAR_CodCliID", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.Input;

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objCliente = (ClienteTO)obj;
                        parametros[0].Value = objCliente.CodCliID;

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "CLIENTES_EXCLUIR";
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
