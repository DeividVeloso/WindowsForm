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
    public partial class frmCadPedido : Form
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

		public frmCadPedido(frmConsulta frmConsultaGrid)
        {
            InitializeComponent();
            this.Text = "Cadastro de Pedidos";

			AtualizaGrid = frmConsultaGrid;

            dtPickerInclusao.Format = DateTimePickerFormat.Custom;
            dtPickerInclusao.CustomFormat = "dd/MM/yyyy hh:mm:ss";

            dtPickerAlteracao.Format = DateTimePickerFormat.Custom;
            dtPickerAlteracao.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            CarregaComboCliente();
            CarregaComboProduto();
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
                mTxtDtCompra.Text = DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Year.ToString().PadLeft(2, '0');
                ModoInclusao();

            }

            txtCodigo.Enabled = false;
            mTxtDtCompra.Enabled = false;
            dtPickerInclusao.Enabled = false;
            dtPickerAlteracao.Enabled = false;
        }

        public bool PreenchimentoValido()
        {
            if (cboCliente.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, selecione um Cliente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus();
                return false;
            }
            if (cboProduto.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, selecione um Produto!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus();
                return false;
            }
            if (mTxtDtCompra.Text.Trim().TrimEnd('/').TrimStart('/').Trim() == "" && Funcoes.ValidaData(mTxtDtCompra.Text.Trim()) == false)
            {
                MessageBox.Show("Por favor, informe uma data válida { DD/MM/AAAA }!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mTxtDtCompra.Focus();
                return false;
            }
            if (mTxtDtCancelamento.Text.Trim().TrimEnd('/').TrimStart('/').Trim() != "" && Funcoes.ValidaData(mTxtDtCancelamento.Text.Trim()) == false)
            {
                MessageBox.Show("Por favor, informe uma data válida { DD/MM/AAAA }!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mTxtDtCancelamento.Focus();
                return false;
            }

            return true;


        }

        public void CarregarDados()
        {
            try
            {
                PedidoTO objPedido = new PedidoTO();
                objBusinessRetorno = new BusinessRetorno();
                objPedido = (PedidoTO)objBusinessRetorno.Recuperar(objConsulta, new PedidoRetorno(), Funcoes.CONEXAO_ID, null);

                if (objPedido != null)
                {
                    txtCodigo.Text = objPedido.CodPedidoID.ToString();
                    cboCliente.SelectedValue = objPedido.CodCliID.ToString();
                    cboProduto.SelectedValue = objPedido.CodProdID.ToString();

                    mTxtDtCompra.Text = objPedido.DtCompra.ToString();

                    if (objPedido.DtCancelado != null)
                    {
                        mTxtDtCancelamento.Text = objPedido.DtCancelado.ToString();
                    }
                    txtObservacao.Text = objPedido.Obs;

                    dtPickerAlteracao.Text = objPedido.DataAlteracao.ToString();
                    dtPickerInclusao.Text = objPedido.DataInclusao.ToString();
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
            Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "mTxtDtCancelamento", "txtObservacao" });
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
                    List<IClasse> objListaPedido = new List<IClasse>();
                    List<List<IClasse>> objListaGeral = new List<List<IClasse>>();

                    PedidoTO objPedido = new PedidoTO();
                    if (txtCodigo.Text != "")
                    {
                        objPedido.CodPedidoID = Convert.ToInt32(txtCodigo.Text);
                    }
                    objPedido.CodCliID = Convert.ToInt32(cboCliente.SelectedValue);
                    objPedido.CodProdID = Convert.ToInt32(cboProduto.SelectedValue);

                    if (mTxtDtCancelamento.Text.Length >= 10)
                    {
                        objPedido.DtCancelado = Convert.ToDateTime(mTxtDtCancelamento.Text, Funcoes.culturaBR);
                    }

                    if (mTxtDtCompra.Text.Length >= 10)
                    {
                        objPedido.DtCompra = Convert.ToDateTime(mTxtDtCompra.Text, Funcoes.culturaBR);
                    }

                    objPedido.Obs = txtObservacao.Text;

                    objListaPedido.Add(objPedido);
                    objListaGeral.Add(objListaPedido);

                    //executa a ação selecionada pelo usuário
                    switch (OperacaoFormulario)
                    {
                        case EnumTipoOperacao.Incluir:
                            BusinessEnvio objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Incluir(objListaGeral, new PedidoEnvio(), Funcoes.CONEXAO_ID);
                            MessageBox.Show("Cadastrado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            this.Close();
                            break;
                        case EnumTipoOperacao.Alterar:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Alterar(objListaGeral, new PedidoEnvio(), Funcoes.CONEXAO_ID);
                            Funcoes.HabilitarCamposFormulario(this, CamposLiberados = new List<string> { "" });
                            ModoConsulta();
                            MessageBox.Show("Alterado com Sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();

                            break;
                        case EnumTipoOperacao.Excluir:
                            objBusinessEnvio = new BusinessEnvio();
                            objBusinessEnvio.Excluir(objListaGeral, new PedidoEnvio(), Funcoes.CONEXAO_ID);
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
                    MessageBox.Show("Pedido já cadastrado, por favor informar outro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cboCliente.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                cboProduto.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);
                mTxtDtCompra.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarObrigatoriamente);

                mTxtDtCancelamento.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);
                txtObservacao.BackColor = Funcoes.RetornaCorCampo(EnumTipoCor.InformarOpcionalmente);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro em {0} - {1} \n {2}", ex.Source, ex.Message, ex.InnerException));
            }
        }

        private void CarregaComboCliente()
        {
            ClienteTO objCliente = new ClienteTO();
            //objCategoria.CategoriaID = Funcoes.EMPRESAID;
            objBusinessRetorno = new BusinessRetorno();
            List<IClasse> objListaCombo = new List<IClasse>();
            objListaCombo = objBusinessRetorno.Lista(objCliente, new ClienteRetorno(), Funcoes.CONEXAO_ID, null);

            cboCliente.DataSource = Funcoes.PrepararListaCombo(objListaCombo);
            cboCliente.DisplayMember = "descricao";
            cboCliente.ValueMember = "IdItem";
        }

        private void CarregaComboProduto()
        {
            ProdutoTO objProduto = new ProdutoTO();
            //objCategoria.CategoriaID = Funcoes.EMPRESAID;
            objBusinessRetorno = new BusinessRetorno();
            List<IClasse> objListaCombo = new List<IClasse>();
            objListaCombo = objBusinessRetorno.Lista(objProduto, new ProdutoRetorno(), Funcoes.CONEXAO_ID, null);

            cboProduto.DataSource = Funcoes.PrepararListaComboProduto(objListaCombo);
            cboProduto.DisplayMember = "descricao";
            cboProduto.ValueMember = "IdItem";
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

        private void cboProduto_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboProduto.SelectedValue != null)
            {
                if (cboProduto.SelectedIndex >= 1)
                {
                    //Convert.ToByte(((ItemComboFuncionarioTO)cboResponsavel.SelectedItem).EmpresaId);
                    lblValor.Text = Convert.ToString(((ItemComboProdutoTO)cboProduto.SelectedItem).Preco);
                }
            }

        }

    }
}
