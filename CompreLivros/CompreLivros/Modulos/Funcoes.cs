using Library;
using Library.Enumeradores;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompreLivros.Modulos
{
    public static class Funcoes
    {
        public static CultureInfo culturaBR = new CultureInfo("pt-BR");

        /// <summary>
        /// String de conexão do banco Controler
        /// </summary>
        public static string CONEXAO_ID = "Data Source=Deivid-PC;Initial Catalog=TocaLivrosDB;Persist Security Info=True;User ID=sa;Password=sa@2016;";

		//public static string CONEXAO_ID = @"Data Source=K14\SQLEXPRESS;Initial Catalog=TocaLivrosDB;Integrated Security=True";
        //public static string CONEXAO_ID = PropriedadeConfig("ConexaoNegocioDireto");

        //Usada para informar se tem registro duplicado.
        public static string ERRO_UNIQUE = "UNIQUE";
        //Relacionamento
        public static string ERRO_CONSTRAINT = "constraint";


        public static bool ValidaData(string data)
        {
            if (data != null)
            {
                try
                {
                    DateTime myDate = DateTime.ParseExact(data, "dd/MM/yyyy", culturaBR);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
                
            }
            else
            {
                return false;
            }
        }

        // '**** ATENÇÃO o retorno do remoting esta causando um problema de memoria
        //'conforme pesquisado na microsoft é um problema conhecido no framework 2.0 mais no 4.0 não deveria acontecer
        //'tiver que fazer um workarround para burlar o problema, mais ainda tem que pesquisar mais - prols 06/01/2011
        //07/05/2012 - Atualização - O erro está ocorrendo ainda que não utilizemos o remoting - WillianG
        public static List<ItemComboTO> PrepararListaCombo(List<IClasse> lista)
        {

            List<ItemComboTO> listaRetorno = new List<ItemComboTO>();

            DataTable dt = new DataTable();
            dt.Columns.Add("IDItem");
            dt.Columns.Add("descricao");
            DataRow dr;

            foreach (ItemComboTO item in lista)
            {
                dr = dt.NewRow();
                dr["IDItem"] = item.IDItem;
                dr["descricao"] = item.Descricao;
                dt.Rows.Add(dr);
            }

            ItemComboTO itemcbo;

            foreach (DataRow drItem in dt.Rows)
            {
                itemcbo = new ItemComboTO();

                itemcbo.IDItem = drItem["IDItem"].ToString();
                itemcbo.Descricao = drItem["descricao"].ToString();
                listaRetorno.Add(itemcbo);
            }

            return listaRetorno;
        }

        // '**** ATENÇÃO o retorno do remoting esta causando um problema de memoria
        //'conforme pesquisado na microsoft é um problema conhecido no framework 2.0 mais no 4.0 não deveria acontecer
        //'tiver que fazer um workarround para burlar o problema, mais ainda tem que pesquisar mais - prols 06/01/2011
        //07/05/2012 - Atualização - O erro está ocorrendo ainda que não utilizemos o remoting - WillianG
        public static List<ItemComboProdutoTO> PrepararListaComboProduto(List<IClasse> lista)
        {

            List<ItemComboProdutoTO> listaRetorno = new List<ItemComboProdutoTO>();

            DataTable dt = new DataTable();
            dt.Columns.Add("IDItem");
            dt.Columns.Add("descricao");
            dt.Columns.Add("preco");

            DataRow dr;

            foreach (ItemComboProdutoTO item in lista)
            {
                dr = dt.NewRow();
                dr["IDItem"] = item.IDItem;
                dr["descricao"] = item.Descricao;
                dr["preco"] = item.Preco;

                dt.Rows.Add(dr);
            }

            ItemComboProdutoTO itemcbo;

            foreach (DataRow drItem in dt.Rows)
            {
                itemcbo = new ItemComboProdutoTO();

                itemcbo.IDItem = drItem["IDItem"].ToString();
                itemcbo.Descricao = drItem["descricao"].ToString();
                itemcbo.Preco = Convert.ToDecimal(drItem["preco"]);

                listaRetorno.Add(itemcbo);
            }

            return listaRetorno;
        }

        /// <summary>
        /// Retorna a cor de fundo para o componente no formulário
        /// </summary>
        /// <param name="tipocampo">Tipo do campo para definição da cor de fundo</param>
        /// <returns>A cor correspondente para o tipo de restrição do campo</returns>
        /// <remarks>usado quando for necessario determinar o tipo de cor de fundo do componente no formulário</remarks>
        public static Color RetornaCorCampo(EnumTipoCor tipocampo)
        {
            switch (tipocampo)
            {
                case EnumTipoCor.SomenteVisualizar:
                    return Color.FromArgb(230, 255, 255);
                case EnumTipoCor.InformarObrigatoriamente:
                    return Color.FromArgb(255, 255, 255);
                case EnumTipoCor.InformarOpcionalmente:
                    return Color.FromArgb(255, 255, 223);
                default:
                    return Color.FromArgb(255, 255, 255);
            }
        }


        public static void HabilitarCamposFormulario(Form formulario, List<string> campos)
        {
            try
            {
                HabilitaCampos(formulario.Controls, campos);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        /// <summary>
        /// Habilita os campos dentro de uma coleção de controles
        /// </summary>
        /// <param name="controles">Coleção de controles</param>
        /// <param name="campos">Nome dos controles a serem habilitados</param>
        private static void HabilitaCampos(Control.ControlCollection controles, List<string> campos)
        {
            //Primeiro desabilita todos os campos, menos os Buttons
            foreach (Control ctr in controles)
            {
                if ((ctr) is Button || (ctr) is Label)
                {
                    //
                }
                else
                {
                    ctr.Enabled = false;
                }
            }

            //Habilita somente o que eu passar na List<string>
            foreach (Control ctr in controles)
            {
                if (campos != null)
                {
                    for (Int32 cont = 0; cont <= campos.Count - 1; cont++)
                    {
                        if (campos[cont].Trim().ToUpper() == ctr.Name.ToUpper())
                        {
                            ctr.Enabled = true;

                            if ((ctr) is GroupBox || (ctr) is Panel || (ctr) is TabControl)
                            {
                                //Se for um container tem que habilitar os componentes dentro dele, não tem jeito
                                foreach (Control item in ctr.Controls)
                                {
                                    item.Enabled = true;
                                }
                            }
                            else if (ctr is DataGridView)
                            {
                                ((DataGridView)ctr).ReadOnly = false;
                            }

                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Função para permitir somente numeros e vírgula nos campos
        /// </summary>
        /// <param name="e">Evento KeyPress do objeto a qual se deseja usar a função</param>
        public static bool PermiteNumero(System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 44) || (e.KeyChar == (char)Keys.Back))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Função para permitir somente numeros e vírgula nos campos
        /// </summary>
        /// <param name="e">Evento KeyPress do objeto a qual se deseja usar a função</param>
        public static bool PermiteNumero(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 44) || (e.KeyChar == (char)Keys.Back))  //Aceita somente virgula, números ou backspace
            {
                if (((System.Windows.Forms.Control)(sender)).Text != "")   //Valida se o valor da célula não é nulo, para não dar erro na validação abaixo.
                    if (((System.Windows.Forms.Control)(sender)).Text.LastIndexOf(",") >= 0 && e.KeyChar == 44)  //Para não permitir que digite mais de um ponto.
                        return true;
                    else
                        return false;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidaEmail(string s)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(s);
        }

      
        /// <summary>
        /// Verifica se o CPF informado é um CPF válido
        /// </summary>
        /// <param name="CPF">CPF a ser verificado</param>
        /// <returns>True se o CPF for válido</returns>
        public static Boolean ValidaCPF(String CPF)
        {
            try
            {
                Int32 soma1 = 0;
                Int32 soma2 = 0;
                Int32 dig1, dig2;
                double resto1, resto2;

                for (int i = 0; i < 9; i++)
                {
                    soma1 += Convert.ToInt32(CPF.Substring(i, 1)) * (10 - i);
                }
                resto1 = soma1 % 11;
                dig1 = Convert.ToInt32(11 - resto1);
                if (dig1 > 9) dig1 = 0;

                for (int j = 0; j < 9; j++)
                {
                    soma2 += Convert.ToInt32(CPF.Substring(j, 1)) * (11 - j);
                }
                soma2 += dig1 * 2;
                resto2 = soma2 % 11;
                dig2 = Convert.ToInt32(11 - resto2);

                if (dig2 > 9) dig2 = 0;

                if (dig1 + "" + dig2 == CPF.Substring(9, 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
