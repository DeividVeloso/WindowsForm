using Business;
using ClasseBase;
using CompreLivros.Modulos;
using Library;
using Library.Enumeradores;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompreLivros
{
    public partial class frmCadProduto : Form
    {

        /// <summary>
        /// Objeto utilizada para carregar os dados da consulta
        /// </summary>
        public IClasse objConsulta
        {
            get;
            set;
        }

        public List<string> CamposLiberados
        {
            get;
            set;
        }

        BusinessEnvio objBusinessEnvio;
        BusinessRetorno objBusinessRetorno;

        private EnumTipoOperacao operacaoForm;

        /// <summary>
        /// Operação formulario
        /// </summary>
        public EnumTipoOperacao OperacaoFormulario
        {
            get { return operacaoForm; }
            set { operacaoForm = value; }
        }

		//Criado para Atualizar o Grid a cada alteração de registro.
		public frmConsulta AtualizaGrid { get; set; }
		
		public frmCadProduto(frmConsulta frmConsultaGrid)
        {
            InitializeComponent();

            AplicarEventos(txtPreco);
            this.Text = "Cadastro de Livros";

			AtualizaGrid = frmConsultaGrid;

            dtPickerInclusao.Format = DateTimePickerFormat.Custom;
            dtPickerInclusao.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dtPickerAlteracao.Format = DateTimePickerFormat.Custom;
            dtPickerAlteracao.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        private void frmCadProduto_Load(object sender, EventArgs e)
        {
            CarregaComboCategoria();
            CarregaComboIdioma();
            CarregarTipoCampo();

            //Carrega a tela em modo consulta senão Inclusão
            if (objConsulta != null)
            {
                OperacaoFormulario = EnumTipoOperacao.Consultar;
                CarregarDados();
                Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "" });

                ModoConsulta();
            }
            else
            {
                OperacaoFormulario = EnumTipoOperacao.Incluir;
                ModoInclusao();

            }

            txtCodigo.Enabled = false;
            dtPickerInclusao.Enabled = false;
            dtPickerAlteracao.Enabled = false;
        }

        private bool PreenchimentoValido()
        {

            if (txtTitulo.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, informe o Título!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }
            if (txtISBN.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, informe o ISBN!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }
            if (cboIdioma.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, selecione o Idioma!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboIdioma.Focus();
                return false;
            }
            if (txtEditora.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, informe o Editora!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }
            if (cboCategoria.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, selecione o Categoria!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategoria.Focus();
                return false;
            }
            if (txtPreco.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, informe o Preço!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreco.Focus();
                return false;
            }
            if (mTxtDtDesativ.Text.Trim().TrimEnd('/').TrimStart('/').Trim() != "" && Funcoes.ValidaData(mTxtDtDesativ.Text.Trim()) == false)
            {
                MessageBox.Show("Por favor, informe uma data válida { DD/MM/AAAA }!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mTxtDtDesativ.Focus();
                return false;
            }


            return true;


        }

        private void CarregarDados()
        {
            try
            {
                ProdutoTO objProduto = new ProdutoTO();
                objBusinessRetorno = new BusinessRetorno();
                objProduto = (ProdutoTO)objBusinessRetorno.Recuperar(objConsulta, new ProdutoRetorno(), Funcoes.CONEXAO_ID, null);

                if (objProduto != null)
                {
                    txtCodigo.Text = objProduto.CodProdID.ToString();
                    txtTitulo.Text = objProduto.Titulo;
                    txtISBN.Text = objProduto.ISBN;
                    if (objProduto.Paginas != null)
                    {
                        txtPaginas.Text = objProduto.Paginas.ToString();

                    }
                    if (objProduto.Edicao != null)
                    {
                        txtEdicao.Text = objProduto.Edicao.ToString();

                    }
                    txtAnoLancamento.Text = objProduto.AnoLanca.ToString();
                    cboIdioma.SelectedValue = objProduto.Idioma.ToString();
                    txtEditora.Text = objProduto.Editora;
                    cboCategoria.SelectedValue = objProduto.CategoriaID.ToString();

                    // string decValor = "";
                    decimal valorDecimal = 0;
                    if (objProduto.Preco != 0)
                    {
                        valorDecimal = objProduto.Preco;
                        txtPreco.Text = valorDecimal.ToString("C2");
                    }
                    //txtPreco.Text = objProduto.Preco.ToString("C2");


                    mTxtDtDesativ.Text = objProduto.DataDesativacao.ToString();
                    txtSinopse.Text = objProduto.Sinopse;

                    dtPickerAlteracao.Text = objProduto.DataAlteracao.ToString();
                    dtPickerInclusao.Text = objProduto.DataInclusao.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            //Funcoes.HabilitarCamposFormulario(this, null);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            OperacaoFormulario = EnumTipoOperacao.Alterar;
            Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "txtTitulo", "txtPaginas", "txtEdicao", "txtAnoLancamento", "cboIdioma", "txtEditora", "txtPreco", "txtDtDesativa", "txtSinopse" });
            ModoAlterar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            OperacaoFormulario = EnumTipoOperacao.Excluir;
            Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "" });
            ModoExclusao();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PreenchimentoValido() == true)
                {
                    List<IClasse> objListaProduto = new List<IClasse>();
                    List<List<IClasse>> objListaGeral = new List<List<IClasse>>();

                    ProdutoTO objProduto = new ProdutoTO();
                    if (txtCodigo.Text != "")
                    {
                        objProduto.CodProdID = Convert.ToInt32(txtCodigo.Text);
                    }

                    objProduto.Titulo = txtTitulo.Text;
                    objProduto.ISBN = txtISBN.Text;
                    if (txtPaginas.Text != "")
                    {
                        objProduto.Paginas = Convert.ToInt32(txtPaginas.Text);

                    }
                    if (txtEdicao.Text != "")
                    {
                        objProduto.Edicao = Convert.ToInt32(txtEdicao.Text);

                    }
                    if (txtAnoLancamento.Text != "")
                    {
                        objProduto.AnoLanca = Convert.ToInt32(txtAnoLancamento.Text);

                    }

                    objProduto.Editora = txtEditora.Text;
                    objProduto.CategoriaID = Convert.ToInt32(cboCategoria.SelectedValue);

                    string strValor = "";
                    decimal dblValor = 0;
                    if (txtPreco.Text != "")
                    {
                        strValor = txtPreco.Text.Replace("R$", "").Trim();
                        dblValor = Convert.ToDecimal(strValor);
                        //novovalor = dblValor.ToString("#.##"); 
                        objProduto.Preco = dblValor;
                    }

                    //objProduto.Preco = Convert.ToDecimal(txtPreco.Text);

                    objProduto.Sinopse = txtSinopse.Text;

                    objProduto.Idioma = cboIdioma.SelectedValue.ToString();

                    if (mTxtDtDesativ.Text.Length >= 10)
                    {
                        objProduto.DataDesativacao = Convert.ToDateTime(mTxtDtDesativ.Text, Funcoes.culturaBR);
                    }

                    objListaProduto.Add(objProduto);
                    objListaGeral.Add(objListaProduto);

                    //executa a ação selecionada pelo usuário
                    switch (OperacaoFormulario)
                    {
                        case EnumTipoOperacao.Incluir:
                            BusinessEnvio objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Incluir(objListaGeral, new ProdutoEnvio(), Funcoes.CONEXAO_ID);
                            MessageBox.Show("Cadastrado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            this.Close();
                            break;
                        case EnumTipoOperacao.Alterar:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Alterar(objListaGeral, new ProdutoEnvio(), Funcoes.CONEXAO_ID);
                            Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "" });
                            ModoConsulta();
                            MessageBox.Show("Alterado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                        case EnumTipoOperacao.Excluir:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Excluir(objListaGeral, new ProdutoEnvio(), Funcoes.CONEXAO_ID);
                            MessageBox.Show("Excluído com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                    }
					if (OperacaoFormulario != EnumTipoOperacao.Incluir)
					{
						AtualizaGrid.btnAtualizar_Click(null, null);
						this.Close();
					}
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(Funcoes.ERRO_UNIQUE))
                {
                    MessageBox.Show("ISBN já cadastrado, por favor informar outro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 
                }
                else if (ex.Message.Contains(Funcoes.ERRO_CONSTRAINT))
                {
                    MessageBox.Show("Esse dado não pode ser deletado, pois existe relacionamento com outros dados.\n Por favor, verifique!.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    throw ex;
                }
            }
        }

        private void CarregaComboCategoria()
        {
            CategoriaTO objCategoria = new CategoriaTO();
            //objCategoria.CategoriaID = Funcoes.EMPRESAID;
            objBusinessRetorno = new BusinessRetorno();
            List<IClasse> objListaCombo = new List<IClasse>();
            objListaCombo = objBusinessRetorno.Lista(objCategoria, new CategoriaRetorno(), Funcoes.CONEXAO_ID, null);

            cboCategoria.DataSource = Funcoes.PrepararListaCombo(objListaCombo);
            cboCategoria.DisplayMember = "descricao";
            cboCategoria.ValueMember = "IdItem";
        }

        private void CarregaComboIdioma()
        {
            List<IClasse> lista = new List<IClasse>();
            ItemComboTO item;

            lista.Add(new ItemComboTO());

            item = new ItemComboTO();
            item.IDItem = "I";
            item.Descricao = "Inglês";
            lista.Add(item);

            item = new ItemComboTO();
            item.IDItem = "P";
            item.Descricao = "Português";
            lista.Add(item);

            item = new ItemComboTO();
            item.IDItem = "O";
            item.Descricao = "Outros";
            lista.Add(item);

            cboIdioma.DataSource = Funcoes.PrepararListaCombo(lista); ;
            cboIdioma.DisplayMember = "descricao";
            cboIdioma.ValueMember = "iditem";
        }

        private void CarregarTipoCampo()
        {
            try
            {
                txtCodigo.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.SomenteVisualizar);

                txtTitulo.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                txtISBN.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                cboIdioma.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                txtEditora.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                cboCategoria.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                txtPreco.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);

                txtPaginas.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                txtEdicao.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                txtAnoLancamento.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                mTxtDtDesativ.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                txtSinopse.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        private void ModoInclusao()
        {
            btnIncluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnConfirmar.Enabled = true;
            btnSair.Enabled = true;

            btnIncluir.BackColor = Color.Red;
            btnIncluir.Focus();
        }

        private void ModoAlterar()
        {
            btnIncluir.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = false;
            btnConfirmar.Enabled = true;
            btnSair.Enabled = true;

            btnAlterar.BackColor = Color.Red;
            btnAlterar.Focus();
        }

        private void ModoExclusao()
        {
            btnIncluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = true;
            btnConfirmar.Enabled = true;
            btnSair.Enabled = true;

            btnExcluir.BackColor = Color.Red;
            btnExcluir.Focus();
        }
        private void ModoConsulta()
        {
            btnIncluir.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnConfirmar.Enabled = true;
            btnSair.Enabled = true;

        }

        private void txtPaginas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funcoes.PermiteNumero(e);
        }

        private void txtEdicao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funcoes.PermiteNumero(e);
        }

        private void txtAnoLancamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funcoes.PermiteNumero(e);
        }

        private void RetornarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                txt.Text = double.Parse(txt.Text).ToString("C2");
            }
        }

        private void TirarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }

        private void AplicarEventos(TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMascara;
            txt.KeyPress += ApenasValorNumerico;
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funcoes.PermiteNumero(e);
        }
    }
}
