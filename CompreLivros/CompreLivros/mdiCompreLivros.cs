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
    public partial class mdiCompreLivros : Form
    {
        public mdiCompreLivros()
        {

            InitializeComponent();
            this.Text = "Compre Livros";
        }
		frmConsulta objfrmConsulta;
        #region Cadastro
        private void mnuCadCliente_Click(object sender, EventArgs e)
        {
			frmCadCliente objfrmCadCliente = new frmCadCliente(objfrmConsulta);
            objfrmCadCliente.StartPosition = FormStartPosition.CenterScreen;
            objfrmCadCliente.Show();
        }

        private void mnuCadCategoria_Click(object sender, EventArgs e)
        {
			frmCadCategoria objfrmCadCategoria = new frmCadCategoria(objfrmConsulta);
            objfrmCadCategoria.StartPosition = FormStartPosition.CenterScreen;
            objfrmCadCategoria.Show();
        }

        private void mnuCadPedidos_Click(object sender, EventArgs e)
        {
			frmCadPedido objfrmCadPedido = new frmCadPedido(objfrmConsulta);
            objfrmCadPedido.StartPosition = FormStartPosition.CenterScreen;
            objfrmCadPedido.Show();
        }

        private void mnuCadProduto_Click(object sender, EventArgs e)
        {
			frmCadProduto objfrmCadProduto = new frmCadProduto(objfrmConsulta);
            objfrmCadProduto.StartPosition = FormStartPosition.CenterScreen;
            objfrmCadProduto.Show();
        }

        #endregion

        #region Consulta

        private void mnuConClientes_Click(object sender, EventArgs e)
        {
            frmConsulta objfrmConsulta = new frmConsulta(EnumModulo.ConCliente, "mnuConClientes", "Consultar/Editar/Excluir Clientes");
            objfrmConsulta.StartPosition = FormStartPosition.CenterParent;
            objfrmConsulta.Show();

        }

        private void mnuConCategoria_Click(object sender, EventArgs e)
        {
            frmConsulta objfrmConsulta = new frmConsulta(EnumModulo.ConCategoria, "mnuConCategoria", "Consultar/Editar/Excluir Categorias");
            objfrmConsulta.StartPosition = FormStartPosition.CenterParent;
            objfrmConsulta.Show();
        }

        private void mnuConProdutos_Click(object sender, EventArgs e)
        {
            frmConsulta objfrmConsulta = new frmConsulta(EnumModulo.ConProduto, "mnuConProdutos", "Consultar/Editar/Excluir Produtos");
            objfrmConsulta.StartPosition = FormStartPosition.CenterParent;
            objfrmConsulta.Show();
        }

        private void mnuConPedidos_Click(object sender, EventArgs e)
        {
            frmConsulta objfrmConsulta = new frmConsulta(EnumModulo.ConPedidos, "mnuConPedidos", "Consultar/Editar/Excluir Pedidos");
            objfrmConsulta.StartPosition = FormStartPosition.CenterParent;
            objfrmConsulta.Show();
        }

        #endregion
    }
}
