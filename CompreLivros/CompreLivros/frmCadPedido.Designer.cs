namespace CompreLivros
{
    partial class frmCadPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadPedido));
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dtPickerAlteracao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtPickerInclusao = new System.Windows.Forms.DateTimePicker();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mTxtDtCompra = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.cboProduto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mTxtDtCancelamento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(222, 12);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(74, 50);
            this.btnConfirmar.TabIndex = 25;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(302, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 50);
            this.btnSair.TabIndex = 26;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(73, 12);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(68, 50);
            this.btnAlterar.TabIndex = 23;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(147, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(69, 50);
            this.btnExcluir.TabIndex = 24;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(2, 12);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(65, 50);
            this.btnIncluir.TabIndex = 22;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Data Alteração";
            // 
            // dtPickerAlteracao
            // 
            this.dtPickerAlteracao.Location = new System.Drawing.Point(3, 446);
            this.dtPickerAlteracao.Name = "dtPickerAlteracao";
            this.dtPickerAlteracao.Size = new System.Drawing.Size(358, 20);
            this.dtPickerAlteracao.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Data Inclusão";
            // 
            // dtPickerInclusao
            // 
            this.dtPickerInclusao.Location = new System.Drawing.Point(5, 399);
            this.dtPickerInclusao.Name = "dtPickerInclusao";
            this.dtPickerInclusao.Size = new System.Drawing.Size(356, 20);
            this.dtPickerInclusao.TabIndex = 34;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(9, 91);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(48, 20);
            this.txtCodigo.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Código";
            // 
            // mTxtDtCompra
            // 
            this.mTxtDtCompra.Location = new System.Drawing.Point(9, 213);
            this.mTxtDtCompra.Mask = "00/00/0000";
            this.mTxtDtCompra.Name = "mTxtDtCompra";
            this.mTxtDtCompra.Size = new System.Drawing.Size(100, 20);
            this.mTxtDtCompra.TabIndex = 42;
            this.mTxtDtCompra.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Data da Compra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Cliente";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(7, 131);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(360, 21);
            this.cboCliente.TabIndex = 44;
            // 
            // cboProduto
            // 
            this.cboProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProduto.FormattingEnabled = true;
            this.cboProduto.Location = new System.Drawing.Point(7, 172);
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Size = new System.Drawing.Size(360, 21);
            this.cboProduto.TabIndex = 46;
            this.cboProduto.SelectedValueChanged += new System.EventHandler(this.cboProduto_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Produto";
            // 
            // mTxtDtCancelamento
            // 
            this.mTxtDtCancelamento.Location = new System.Drawing.Point(147, 212);
            this.mTxtDtCancelamento.Mask = "00/00/0000";
            this.mTxtDtCancelamento.Name = "mTxtDtCancelamento";
            this.mTxtDtCancelamento.Size = new System.Drawing.Size(100, 20);
            this.mTxtDtCancelamento.TabIndex = 47;
            this.mTxtDtCancelamento.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Data do Cancelamento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Observação";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(6, 291);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacao.Size = new System.Drawing.Size(358, 84);
            this.txtObservacao.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "Total:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(264, 242);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(72, 20);
            this.lblValor.TabIndex = 52;
            this.lblValor.Text = "R$ 0,00";
            // 
            // frmCadPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 474);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mTxtDtCancelamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.mTxtDtCompra);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtPickerAlteracao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtPickerInclusao);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnIncluir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadPedido";
            this.Text = "frmPedido";
            this.Load += new System.EventHandler(this.frmPedido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtPickerAlteracao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtPickerInclusao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mTxtDtCompra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.ComboBox cboProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mTxtDtCancelamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblValor;
    }
}