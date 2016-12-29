using Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [Serializable()]
    public class BusinessRetorno
    {

        public DataTable Consultar(IClasse objEnvio, IRetorno objConsulta, String stringconexao, Hashtable parametros)
        {
            SqlConnection objConnection = new SqlConnection(stringconexao);
            try
            {
                return objConsulta.Consulta(objEnvio, objConnection, parametros);
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
            finally
            {
                objConnection.Close();
                objConnection.Dispose();
            }
        }


        public IClasse Recuperar(IClasse objEnvio, IRetorno objConsulta, String stringconexao, Hashtable parametros)
        {
            SqlConnection objConnection = new SqlConnection(stringconexao);
            try
            {
                return objConsulta.Recuperar(objEnvio, objConnection, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConnection.Close();
                objConnection.Dispose();
            }
        }


        public List<IClasse> Lista(IClasse objEnvio, IRetorno objConsulta, String stringconexao, Hashtable parametros)
        {
            SqlConnection objConnection = new SqlConnection(stringconexao);
            objConnection.Open();
            try
            {
                return objConsulta.Lista(objEnvio, objConnection, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objConnection.Close();
                objConnection.Dispose();
            }
        }
    }
}
