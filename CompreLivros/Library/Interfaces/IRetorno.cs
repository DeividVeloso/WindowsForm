using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IRetorno
    {
        IClasse Recuperar(IClasse objEnvio, SqlConnection objConnection, Hashtable parametros);
        DataTable Consulta(IClasse objEnvio, SqlConnection objConnection, Hashtable parametros, SqlTransaction objTransacao = null);
        List<IClasse> Lista(IClasse objEnvio, SqlConnection objConnection, Hashtable parametros);
        //Boolean Verificar(IClasse objEnvio, SqlConnection objConnection, Hashtable parametros);
        DataTable Grade(IClasse objEnvio, SqlConnection objConnection, Hashtable parametros);
        DataTable Relatorio(IClasse objEnvio, SqlConnection objConnection, Hashtable parametros);
    }
}
