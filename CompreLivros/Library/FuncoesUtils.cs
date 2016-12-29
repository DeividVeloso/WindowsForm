using Library.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompreLivros
{
    public class FuncoesUtils
    {
        
        //Funções anteriormente na classe base do netAtlas
        /// <summary>
        /// Função para tratar se o valor a ser enviado para o banco será NULL ou não
        /// </summary>
        public static Object RecuperaValor(object valor)
        {
            Object objValRetorno;
            if (valor is String)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(valor)))
                {
                    objValRetorno = valor;
                }
                else
                {
                    objValRetorno = DBNull.Value;
                }
            }
            else if (valor == null)
            {
                objValRetorno = DBNull.Value;
            }
            else
            {
                objValRetorno = valor;
            }

            return objValRetorno;
        }
    }
    
}
