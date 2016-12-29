using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Interfaces;
using System.Data.SqlClient;

namespace Business
{
    [Serializable()]
    public class BusinessEnvio
    {

        public Int32 Incluir(List<List<IClasse>> obj, IEnvio objEnvio, String stringConexao)
        {

            Int32 retorno = 0;
            SqlConnection objConnection = new SqlConnection();
            SqlTransaction objTransacao = null;

            try
            {
                objConnection.ConnectionString = stringConexao;
                objConnection.Open();

                objTransacao = objConnection.BeginTransaction();

                retorno = objEnvio.Incluir(obj, objConnection, objTransacao);
                objTransacao.Commit();
                return retorno;
            }
            catch (Exception ex)
            {
                objTransacao.Rollback();
                throw ex;
            }
            finally
            {
                objConnection.Close();
                objConnection = null;

                if (objTransacao != null)
                {
                    objTransacao.Dispose();
                }
            }
        }

        public Int32 Alterar(List<List<IClasse>> obj, IEnvio objEnvio, String stringConexao)
        {



            Int32 retorno = 0;
            SqlConnection objConnection = new SqlConnection();
            SqlTransaction objTransacao = null;

            try
            {
                objConnection.ConnectionString = stringConexao;
                objConnection.Open();

                objTransacao = objConnection.BeginTransaction();

                retorno = objEnvio.Alterar(obj, objConnection, objTransacao);
                objTransacao.Commit();

                return retorno;
            }
            catch (Exception ex)
            {
                objTransacao.Rollback();
                throw new Exception("Erro ao alterar PersistenciaEnvio " + ex.Message + "\n " + ex.InnerException);
            }
            finally
            {
                objConnection.Close();
                objConnection = null;

                if (objTransacao != null)
                {
                    objTransacao.Dispose();
                }
            }
        }

        public Int32 Excluir(List<List<IClasse>> obj, IEnvio objEnvio, String stringConexao)
        {
            Int32 retorno = 0;
            SqlConnection objConnection = new SqlConnection();
            SqlTransaction objTransacao = null;

            try
            {
                objConnection.ConnectionString = stringConexao;
                objConnection.Open();

                objTransacao = objConnection.BeginTransaction();

                retorno = objEnvio.Excluir(obj, objConnection, objTransacao);
                objTransacao.Commit();

                return retorno;
            }
            catch (Exception ex)
            {
                objTransacao.Rollback();
                throw ex;
            }
            finally
            {
                objConnection.Close();
                objConnection = null;

                if (objTransacao != null)
                {
                    objTransacao.Dispose();
                }
            }
        }
    }
}
