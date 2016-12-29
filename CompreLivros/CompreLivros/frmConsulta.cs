using Business;
using ClasseBase;
using CompreLivros.Modulos;
using Library;
using Library.Enumeradores;
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
    public partial class frmConsulta : Form
    {
        BusinessRetorno objBusinessRetorno;
        ParametroTO _parametro = new ParametroTO();


        public ParametroTO objParametro
        {
            get { return _parametro; }
            set { _parametro = value; }
        }

        EnumModulo _modulo;

        protected EnumModulo GetModulo
        {
            get
            {
                return _modulo;
            }
        }

        public frmConsulta(EnumModulo modulo, string menu, string nomeFomulario)
        {
            InitializeComponent();
            objParametro.MenuToolStripMenuItem = menu.ToString();
            this.Text = nomeFomulario;
            _modulo = modulo;
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            switch (GetModulo)
            {
                case EnumModulo.ConCliente:
                    objBusinessRetorno = new BusinessRetorno();

                    ClienteTO objCliente = new ClienteTO();
                    DataTable dtCliente = new DataTable();
                    dtCliente = objBusinessRetorno.Consultar(objCliente, new ClienteRetorno(), Funcoes.CONEXAO_ID, null);

                    dtgDados.DataSource = dtCliente;
                    break;
                case EnumModulo.ConCategoria:
                    objBusinessRetorno = new BusinessRetorno();

                    CategoriaTO objCategoria = new CategoriaTO();
                    DataTable dtCategoria = new DataTable();
                    dtCategoria = objBusinessRetorno.Consultar(objCategoria, new CategoriaRetorno(), Funcoes.CONEXAO_ID, null);

                    dtgDados.DataSource = dtCategoria;
                    break;

                case EnumModulo.ConProduto:
                    objBusinessRetorno = new BusinessRetorno();

                    ProdutoTO objProduto = new ProdutoTO();
                    DataTable dtProduto= new DataTable();
                    dtProduto = objBusinessRetorno.Consultar(objProduto, new ProdutoRetorno(), Funcoes.CONEXAO_ID, null);

                    dtgDados.DataSource = dtProduto;
                    break;

                case EnumModulo.ConPedidos:
                    objBusinessRetorno = new BusinessRetorno();

                    PedidoTO objPedido = new PedidoTO();
                    DataTable dtPedido = new DataTable();
                    dtPedido = objBusinessRetorno.Consultar(objPedido, new PedidoRetorno(), Funcoes.CONEXAO_ID, null);

                    dtgDados.DataSource = dtPedido;
                    break;

            }
        }

        private void dtgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (GetModulo)
            {
                case EnumModulo.ConCliente:
                    frmCadCliente objfrmCadCliente = new frmCadCliente(this);
                    ClienteTO objCliente = new ClienteTO();

                    objCliente.CodCliID = Convert.ToInt32(dtgDados.Rows[e.RowIndex].Cells["Código"].Value);
                    objCliente.Operacao = EnumTipoOperacao.Consultar;

                    objfrmCadCliente.objConsulta = objCliente;
                    objfrmCadCliente.StartPosition = FormStartPosition.CenterParent;
                    objfrmCadCliente.Show();
                    break;
                case EnumModulo.ConCategoria:
                    frmCadCategoria objfrmCadCategoria = new frmCadCategoria(this);
                    CategoriaTO objCategoria = new CategoriaTO();

                    objCategoria.CategoriaID = Convert.ToInt32(dtgDados.Rows[e.RowIndex].Cells["Código"].Value);
                    objCategoria.Operacao = EnumTipoOperacao.Consultar;

                    objfrmCadCategoria.objConsulta = objCategoria;
                    objfrmCadCategoria.StartPosition = FormStartPosition.CenterParent;
                    objfrmCadCategoria.Show();

                    break;

                case EnumModulo.ConProduto:
                    frmCadProduto objfrmCadProduto = new frmCadProduto(this);
                    ProdutoTO objProduto = new ProdutoTO();

                    objProduto.CodProdID = Convert.ToInt32(dtgDados.Rows[e.RowIndex].Cells["Código"].Value);
                    objProduto.Operacao = EnumTipoOperacao.Consultar;

                    objfrmCadProduto.objConsulta = objProduto;
                    objfrmCadProduto.StartPosition = FormStartPosition.CenterParent;
                    objfrmCadProduto.Show();

                    break;
                case EnumModulo.ConPedidos:
                    frmCadPedido objfrmCadPedido = new frmCadPedido(this);
                    PedidoTO objPedido = new PedidoTO();

                    objPedido.CodPedidoID = Convert.ToInt32(dtgDados.Rows[e.RowIndex].Cells["Código"].Value);
                    objPedido.Operacao = EnumTipoOperacao.Consultar;

                    objfrmCadPedido.objConsulta = objPedido;
                    objfrmCadPedido.StartPosition = FormStartPosition.CenterParent;
                    objfrmCadPedido.Show();

                    break;
            }
            //switch (GetModulo)
            //{
            //    case EnumModulo.ConCliente:
            //        frmCadCliente objfrmCadCliente = new frmCadCliente();
            //        ClienteTO objCliente = new ClienteTO();

            //        objCliente.CodCliID = Convert.ToInt32(dtgDados.Rows[e.RowIndex].Cells["Código"].Value);
            //        objCliente.Operacao = EnumTipoOperacao.Consultar;

            //        objfrmCadCliente.objConsulta = objCliente;
            //        objfrmCadCliente.StartPosition = FormStartPosition.CenterParent;
            //        objfrmCadCliente.Show();
            //        break;

            //    case EnumModulo.ConCliente:
            //        frmCadCategoria objfrmCadCategoria = new frmCadCategoria();
            //        CategoriaTO objCategoria = new CategoriaTO();

            //        objCategoria.CategoriaID = Convert.ToInt32(dtgDados.Rows[e.RowIndex].Cells["Código"].Value);
            //        objCategoria.Operacao = EnumTipoOperacao.Consultar;

            //        objfrmCadCategoria.objConsulta = objCliente;
            //        objfrmCadCategoria.StartPosition = FormStartPosition.CenterParent;
            //        objfrmCadCategoria.Show();
            //        break;

            //    default:
            //        break;
            //}
        }

        public void btnAtualizar_Click(object sender, EventArgs e)
        {
            frmConsulta_Load(sender, e);
        }




    }
}
