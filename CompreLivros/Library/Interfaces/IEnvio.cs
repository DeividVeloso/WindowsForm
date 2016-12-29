using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IEnvio
    {
        /// do sistema 
        Int32 Incluir(List<List<IClasse>> objEnvio, SqlConnection objConnection, SqlTransaction objTransacao);
        Int32 Alterar(List<List<IClasse>> objEnvio, SqlConnection objConnection, SqlTransaction objTransacao);
        Int32 Excluir(List<List<IClasse>> objEnvio, SqlConnection objConnection, SqlTransaction objTransacao);
    }
}
