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
    public class PedidoEnvio : IEnvio
    {
        public int Incluir(List<List<IClasse>> objEnvio, System.Data.SqlClient.SqlConnection objConnection, System.Data.SqlClient.SqlTransaction objTransacao)
        {
            try
            {
                Int32 intCodigo = 0;
                SqlParameter[] parametros = new SqlParameter[5];
                PedidoTO objPedido;

                parametros[0] = new SqlParameter("@PAR_CodCliID", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_CodProdID", SqlDbType.Int);
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@PAR_DtCompra", SqlDbType.DateTime);
                parametros[2].Direction = ParameterDirection.Input;
                parametros[3] = new SqlParameter("@PAR_DtCancelado", SqlDbType.DateTime);
                parametros[3].Direction = ParameterDirection.Input;
                parametros[4] = new SqlParameter("@PAR_Obs", SqlDbType.DateTime);
                parametros[4].Direction = ParameterDirection.Input;

                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objPedido = (PedidoTO)obj;
                        parametros[0].Value = objPedido.CodCliID;
                        parametros[1].Value = objPedido.CodProdID;
                        parametros[2].Value = DateTime.Now;
                        parametros[3].Value = FuncoesUtils.RecuperaValor(objPedido.DtCancelado);
                        parametros[4].Value = FuncoesUtils.RecuperaValor(objPedido.Obs);
             

     
                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "PEDIDOS_INCLUIR";
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
                PedidoTO objPedido;

                parametros[0] = new SqlParameter("@PAR_CodPedidoID", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@PAR_DtCancelado", SqlDbType.DateTime);
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@PAR_Obs", SqlDbType.VarChar);
                parametros[2].Direction = ParameterDirection.Input;
      

                SqlCommand objCommand = new SqlCommand();

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objPedido = (PedidoTO)obj;
                        parametros[0].Value = objPedido.CodPedidoID;
                        parametros[1].Value = FuncoesUtils.RecuperaValor(objPedido.DtCancelado);
                        parametros[2].Value = FuncoesUtils.RecuperaValor(objPedido.Obs);

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "PEDIDOS_ALTERAR";
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
                PedidoTO objPedido = new PedidoTO();
                Int32 intRegistrosAfetados = 0;
                SqlCommand objCommand = new SqlCommand();

                parametros[0] = new SqlParameter("@PAR_CodPedidoID", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.Input;

                foreach (List<IClasse> objLista in objEnvio)
                {
                    foreach (IClasse obj in objLista)
                    {
                        objPedido = (PedidoTO)obj;
                        parametros[0].Value = objPedido.CodPedidoID;

                        objCommand.Connection = objConnection;
                        objCommand.Transaction = objTransacao;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "PedidoS_EXCLUIR";
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
