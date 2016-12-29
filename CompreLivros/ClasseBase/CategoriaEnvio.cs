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
    public class CategoriaEnvio : IEnvio
    {
        public int Incluir(List<List<IClasse>> objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Data.SqlClient.SqlTransaction objTransacao)
        {
            try
            {
                Int32 intCodigo = 0;
                SqlParameter[] parametros = new SqlParameter[2];
                CategoriaTO objCategoria;

                parametros[0] = new SqlParameter("@PAR_Nome", SqlDbType.VarChar);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_DtDesativacao", SqlDbType.DateTime);
                parametros[1].Direction = ParameterDirection.Input;
                      
                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objCategoria = (CategoriaTO)obj;
                        parametros[0].Value = objCategoria.Nome;
                        parametros[1].Value = FuncoesUtils.RecuperaValor(objCategoria.DataDesativacao);
     
                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "CATEGORIAS_INCLUIR";
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
                SqlParameter[] parametros = new SqlParameter[3];
                CategoriaTO objCategoria;

                parametros[0] = new SqlParameter("@PAR_CategoriaID", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_Nome", SqlDbType.VarChar);
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@PAR_DtDesativacao", SqlDbType.DateTime);
                parametros[2].Direction = ParameterDirection.Input;

                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objCategoria = (CategoriaTO)obj;
                        parametros[0].Value = objCategoria.CategoriaID;
                        parametros[1].Value = objCategoria.Nome;
                        parametros[2].Value = FuncoesUtils.RecuperaValor(objCategoria.DataDesativacao);

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "CATEGORIAS_ALTERAR";
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
                CategoriaTO objCategoria = new CategoriaTO();
                Int32 intRegistrosAfetados = 0;
                SqlCommand objCommand = new SqlCommand();

                parametros[0] = new SqlParameter("@PAR_CategoriaID", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.Input;

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objCategoria = (CategoriaTO)obj;
                        parametros[0].Value = objCategoria.CategoriaID;

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "CATEGORIAS_EXCLUIR";
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
