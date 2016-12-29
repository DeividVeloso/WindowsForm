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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompreLivros
{
    public partial class frmCadCategoria : Form
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

		public frmCadCategoria(frmConsulta frmConsultaGrid)
        {
            InitializeComponent();
            this.Text = "Cadastro de Categorias de Livros";

			AtualizaGrid = frmConsultaGrid;

            dtPickerInclusao.Format = DateTimePickerFormat.Custom;
            dtPickerInclusao.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dtPickerAlteracao.Format = DateTimePickerFormat.Custom;
            dtPickerAlteracao.CustomFormat = "dd/MM/yyyy hh:mm:ss";

        }

        private void frmCadCategoria_Load(object sender, EventArgs e)
        {
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

        public bool PreenchimentoValido()
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, informe o Nome!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
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

        public void CarregarDados()
        {
            try
            {
                CategoriaTO objCategoria = new CategoriaTO();
                objBusinessRetorno = new BusinessRetorno();
                objCategoria = (CategoriaTO)objBusinessRetorno.Recuperar(objConsulta, new CategoriaRetorno(), Funcoes.CONEXAO_ID, null);

                if (objCategoria != null)
                {
                    txtCodigo.Text = objCategoria.CategoriaID.ToString();
                    txtNome.Text = objCategoria.Nome;
                    mTxtDtDesativ.Text = objCategoria.DataDesativacao.ToString();
                    dtPickerAlteracao.Text = objCategoria.DataAlteracao.ToString();
                    dtPickerInclusao.Text = objCategoria.DataInclusao.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            OperacaoFormulario = EnumTipoOperacao.Alterar;
			Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "txtNome", "mTxtDtDesativ" });
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
			//AtualizaGrid.Click(sender, e);
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PreenchimentoValido() == true)
                {
                    List<IClasse> objListaCategoria = new List<IClasse>();
                    List<List<IClasse>> objListaGeral = new List<List<IClasse>>();

                    CategoriaTO objCategoria = new CategoriaTO();
                    if (txtCodigo.Text != "")
                    {
                        objCategoria.CategoriaID = Convert.ToInt32(txtCodigo.Text);
                    }
                    objCategoria.Nome = txtNome.Text;

                    if (mTxtDtDesativ.Text.Length >= 10)
                    {
                        objCategoria.DataDesativacao = Convert.ToDateTime(mTxtDtDesativ.Text, Funcoes.culturaBR);
                    }

                    objListaCategoria.Add(objCategoria);
                    objListaGeral.Add(objListaCategoria);

                    //executa a ação selecionada pelo usuário
                    switch (OperacaoFormulario)
                    {
                        case EnumTipoOperacao.Incluir:
                            BusinessEnvio objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Incluir(objListaGeral, new CategoriaEnvio(), Funcoes.CONEXAO_ID);
                            MessageBox.Show("Cadastrado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                        case EnumTipoOperacao.Alterar:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Alterar(objListaGeral, new CategoriaEnvio(), Funcoes.CONEXAO_ID);
                            Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "" });
                            ModoConsulta();
                            MessageBox.Show("Alterado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            break;
                        case EnumTipoOperacao.Excluir:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Excluir(objListaGeral, new CategoriaEnvio(), Funcoes.CONEXAO_ID);
                            MessageBox.Show("Excluído com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Categoria já cadastrado, por favor informar outra.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void CarregarTipoCampo()
        {
            try
            {
                txtCodigo.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.SomenteVisualizar);
                txtNome.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                mTxtDtDesativ.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
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


    }
}
