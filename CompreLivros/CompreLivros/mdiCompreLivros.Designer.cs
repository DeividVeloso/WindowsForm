namespace CompreLivros
{
    partial class mdiCompreLivros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdiCompreLivros));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastro,
            this.mnuConsulta,
            this.mnuRelatorio});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCadastro
            // 
            this.mnuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadCliente,
            this.mnuCadCategoria,
            this.mnuCadProduto,
            this.mnuCadPedidos});
            this.mnuCadastro.Name = "mnuCadastro";
            this.mnuCadastro.Size = new System.Drawing.Size(66, 20);
            this.mnuCadastro.Text = "Cadastro";
            // 
            // mnuCadCliente
            // 
            this.mnuCadCliente.Name = "mnuCadCliente";
            this.mnuCadCliente.Size = new System.Drawing.Size(139, 22);
            this.mnuCadCliente.Text = "Clientes...";
            this.mnuCadCliente.Click += new System.EventHandler(this.mnuCadCliente_Click);
            // 
            // mnuCadCategoria
            // 
            this.mnuCadCategoria.Name = "mnuCadCategoria";
            this.mnuCadCategoria.Size = new System.Drawing.Size(139, 22);
            this.mnuCadCategoria.Text = "Categorias...";
            this.mnuCadCategoria.Click += new System.EventHandler(this.mnuCadCategoria_Click);
            // 
            // mnuCadProduto
            // 
            this.mnuCadProduto.Name = "mnuCadProduto";
            this.mnuCadProduto.Size = new System.Drawing.Size(139, 22);
            this.mnuCadProduto.Text = "Produtos...";
            this.mnuCadProduto.Click += new System.EventHandler(this.mnuCadProduto_Click);
            // 
            // mnuCadPedidos
            // 
            this.mnuCadPedidos.Name = "mnuCadPedidos";
            this.mnuCadPedidos.Size = new System.Drawing.Size(139, 22);
            this.mnuCadPedidos.Text = "Pedidos...";
            this.mnuCadPedidos.Click += new System.EventHandler(this.mnuCadPedidos_Click);
            // 
            // mnuConsulta
            // 
            this.mnuConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConClientes,
            this.mnuConCategoria,
            this.mnuConProdutos,
            this.mnuConPedidos});
            this.mnuConsulta.Name = "mnuConsulta";
            this.mnuConsulta.Size = new System.Drawing.Size(144, 20);
            this.mnuConsulta.Text = "Consultar/Editar/Excluir";
            // 
            // mnuConClientes
            // 
            this.mnuConClientes.Name = "mnuConClientes";
            this.mnuConClientes.Size = new System.Drawing.Size(139, 22);
            this.mnuConClientes.Text = "Clientes...";
            this.mnuConClientes.Click += new System.EventHandler(this.mnuConClientes_Click);
            // 
            // mnuConCategoria
            // 
            this.mnuConCategoria.Name = "mnuConCategoria";
            this.mnuConCategoria.Size = new System.Drawing.Size(139, 22);
            this.mnuConCategoria.Text = "Categorias...";
            this.mnuConCategoria.Click += new System.EventHandler(this.mnuConCategoria_Click);
            // 
            // mnuConProdutos
            // 
            this.mnuConProdutos.Name = "mnuConProdutos";
            this.mnuConProdutos.Size = new System.Drawing.Size(139, 22);
            this.mnuConProdutos.Text = "Produtos...";
            this.mnuConProdutos.Click += new System.EventHandler(this.mnuConProdutos_Click);
            // 
            // mnuConPedidos
            // 
            this.mnuConPedidos.Name = "mnuConPedidos";
            this.mnuConPedidos.Size = new System.Drawing.Size(139, 22);
            this.mnuConPedidos.Text = "Pedidos...";
            this.mnuConPedidos.Click += new System.EventHandler(this.mnuConPedidos_Click);
            // 
            // mnuRelatorio
            // 
            this.mnuRelatorio.Name = "mnuRelatorio";
            this.mnuRelatorio.Size = new System.Drawing.Size(66, 20);
            this.mnuRelatorio.Text = "Relatório";
            // 
            // mdiCompreLivros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 392);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mdiCompreLivros";
            this.Text = "Compre Livros :-)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastro;
        private System.Windows.Forms.ToolStripMenuItem mnuCadCliente;
        private System.Windows.Forms.ToolStripMenuItem mnuCadCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuCadProduto;
        private System.Windows.Forms.ToolStripMenuItem mnuConsulta;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorio;
        private System.Windows.Forms.ToolStripMenuItem mnuConClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuConCategoria;
        private System.Windows.Forms.ToolStripMenuItem mnuConProdutos;
        private System.Windows.Forms.ToolStripMenuItem mnuCadPedidos;
        private System.Windows.Forms.ToolStripMenuItem mnuConPedidos;
    }
}

