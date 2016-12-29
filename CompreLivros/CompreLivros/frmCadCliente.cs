using Business;
using ClasseBase;
using CompreLivros.Modulos;
using Library;
using Library.Enumeradores;
using Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompreLivros
{
    public partial class frmCadCliente : Form
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

        //Objeto para receber dados do formulário de consulta
		public frmCadCliente(frmConsulta frmConsultaGrid)
        {
            InitializeComponent();
            this.Text = "Cadastro de Clientes";

			AtualizaGrid = frmConsultaGrid;

            dtPickerInclusao.Format = DateTimePickerFormat.Custom;
            dtPickerInclusao.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dtPickerAlteracao.Format = DateTimePickerFormat.Custom;
            dtPickerAlteracao.CustomFormat = "dd/MM/yyyy hh:mm:ss";

        }

        private void frmCadCliente_Load(object sender, EventArgs e)
        {
            CarregaComboSexo();
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

            if (mkTxtCPF.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, informe o CPF!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mkTxtCPF.Focus();
                return false;
            }
            if (mTxtDtNascimento.Text.Trim().TrimEnd('/').TrimStart('/').Trim() != "" && Funcoes.ValidaData(mTxtDtNascimento.Text.Trim()) == false)
            {
                MessageBox.Show("Por favor, informe uma data válida { DD/MM/AAAA }!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mTxtDtNascimento.Focus();
                return false;
            }
            if (mTxtDtDesativ.Text.Trim().TrimEnd('/').TrimStart('/').Trim() != "" && Funcoes.ValidaData(mTxtDtDesativ.Text.Trim()) == false)
            {
                MessageBox.Show("Por favor, informe uma data válida { DD/MM/AAAA }!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mTxtDtDesativ.Focus();
                return false;
            }
            if (cboSexo.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, selecione o Sexo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSexo.Focus();
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, informe o E-mail!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mkTxtCPF.Focus();
                return false;
            }

            if (mkTxtCPF.Text.Length >= 11 && Funcoes.ValidaCPF(mkTxtCPF.Text) == false)
            {
                MessageBox.Show("Por favor, informe um CPF válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mkTxtCPF.Focus();
                return false;
            }

            if (Funcoes.ValidaEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Por favor, informe um E-mail válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mkTxtCPF.Focus();
                return false;
            }
                       
            return true;
            

        }

        public void CarregarDados()
        {
            try
            {
                ClienteTO objCliente = new ClienteTO();
                objBusinessRetorno = new BusinessRetorno();
                objCliente = (ClienteTO)objBusinessRetorno.Recuperar(objConsulta, new ClienteRetorno(), Funcoes.CONEXAO_ID, null);

                if (objCliente != null)
                {

                    txtCodigo.Text = objCliente.CodCliID.ToString();
                    txtNome.Text = objCliente.Nome;
                    mkTxtCPF.Text = objCliente.CPF;
                    mTxtDtNascimento.Text = objCliente.DtNascimento.ToString();
                    mTxtDtDesativ.Text = objCliente.DataDesativacao.ToString();
                    cboSexo.SelectedValue = objCliente.Sexo;
                    txtEmail.Text = objCliente.Email.ToString();
                    mkTxtTelefone.Text = objCliente.Telefone;
                    mkTxtCelular.Text = objCliente.Celular;
                    dtPickerAlteracao.Text = objCliente.DataAlteracao.ToString();
                    dtPickerInclusao.Text = objCliente.DataInclusao.ToString();


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
			Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "txtNome", "txtEmail", "mTxtDtDesativ", "cboSexo", "mkTxtTelefone", "mkTxtCelular" });
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
                    List<IClasse> objListaCliente = new List<IClasse>();
                    List<List<IClasse>> objListaGeral = new List<List<IClasse>>();

                    ClienteTO objCliente = new ClienteTO();
                    if (txtCodigo.Text != "")
                    {
                        objCliente.CodCliID = Convert.ToInt32(txtCodigo.Text);
                    }
                    objCliente.Nome = txtNome.Text;
                    objCliente.Celular = mkTxtCelular.Text;
                    objCliente.Telefone = mkTxtTelefone.Text;
                    objCliente.CPF = mkTxtCPF.Text;
                    objCliente.Email = txtEmail.Text;
                    if (mTxtDtNascimento.Text.Length >= 10)
                    {
                        objCliente.DtNascimento = Convert.ToDateTime(mTxtDtNascimento.Text,Funcoes.culturaBR);
                    }
                    objCliente.Sexo = cboSexo.SelectedValue.ToString();

                    if (mTxtDtDesativ.Text.Length >= 10)
                    {
                        objCliente.DataDesativacao = Convert.ToDateTime(mTxtDtDesativ.Text,Funcoes.culturaBR);
                    }

                    objListaCliente.Add(objCliente);
                    objListaGeral.Add(objListaCliente);

                    //executa a ação selecionada pelo usuário
                    switch (OperacaoFormulario)
                    {
                        case EnumTipoOperacao.Incluir:
                            BusinessEnvio objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Incluir(objListaGeral, new ClienteEnvio(), Funcoes.CONEXAO_ID);
                            MessageBox.Show("Cadastrado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                        case EnumTipoOperacao.Alterar:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Alterar(objListaGeral, new ClienteEnvio(), Funcoes.CONEXAO_ID);
                            Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "" });
                            ModoConsulta();
                             MessageBox.Show("Alterado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();

                            break;
                        case EnumTipoOperacao.Excluir:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Excluir(objListaGeral, new ClienteEnvio(), Funcoes.CONEXAO_ID);
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
                    MessageBox.Show("CPF já cadastrado, por favor informar outro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
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

        public void CarregaComboSexo()
        {
            List<IClasse> lista = new List<IClasse>();
            ItemComboTO item;

            lista.Add(new ItemComboTO());

            item = new ItemComboTO();
            item.IDItem = "M";
            item.Descricao = "Masculino";
            lista.Add(item);

            item = new ItemComboTO();
            item.IDItem = "F";
            item.Descricao = "Feminino";
            lista.Add(item);

            item = new ItemComboTO();
            item.IDItem = "O";
            item.Descricao = "Outros";
            lista.Add(item);

            cboSexo.DataSource = Funcoes.PrepararListaCombo(lista); ;
            cboSexo.DisplayMember = "descricao";
            cboSexo.ValueMember = "iditem";
        }

        public void CarregarTipoCampo()
        {
            try
            {
                txtCodigo.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.SomenteVisualizar);
                txtNome.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
				txtEmail.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                mkTxtCPF.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                mkTxtTelefone.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                mkTxtCelular.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                mTxtDtDesativ.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                mTxtDtNascimento.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                dtPickerAlteracao.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.SomenteVisualizar);
                dtPickerInclusao.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.SomenteVisualizar);
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
