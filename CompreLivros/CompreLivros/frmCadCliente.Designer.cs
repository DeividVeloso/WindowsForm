namespace CompreLivros
{
    partial class frmCadCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadCliente));
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSexo = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtPickerInclusao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mkTxtCPF = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mkTxtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.mkTxtCelular = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtPickerAlteracao = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.mTxtDtNascimento = new System.Windows.Forms.MaskedTextBox();
            this.mTxtDtDesativ = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(8, 12);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(65, 50);
            this.btnIncluir.TabIndex = 12;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(153, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(69, 50);
            this.btnExcluir.TabIndex = 14;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(79, 12);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(68, 50);
            this.btnAlterar.TabIndex = 13;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(308, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 50);
            this.btnSair.TabIndex = 16;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(16, 98);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(48, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(16, 138);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(350, 20);
            this.txtNome.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CPF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data Nascimento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sexo";
            // 
            // cboSexo
            // 
            this.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Location = new System.Drawing.Point(15, 268);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Size = new System.Drawing.Size(121, 21);
            this.cboSexo.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(16, 309);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(350, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "E-mail";
            // 
            // dtPickerInclusao
            // 
            this.dtPickerInclusao.Location = new System.Drawing.Point(10, 398);
            this.dtPickerInclusao.Name = "dtPickerInclusao";
            this.dtPickerInclusao.Size = new System.Drawing.Size(356, 20);
            this.dtPickerInclusao.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Data Inclusão";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Data Desativação";
            // 
            // mkTxtCPF
            // 
            this.mkTxtCPF.Location = new System.Drawing.Point(16, 178);
            this.mkTxtCPF.Mask = "###,###,###-##";
            this.mkTxtCPF.Name = "mkTxtCPF";
            this.mkTxtCPF.Size = new System.Drawing.Size(287, 20);
            this.mkTxtCPF.TabIndex = 3;
            this.mkTxtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Telefone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Celular";
            // 
            // mkTxtTelefone
            // 
            this.mkTxtTelefone.Location = new System.Drawing.Point(15, 349);
            this.mkTxtTelefone.Mask = "(99) 0000-0000";
            this.mkTxtTelefone.Name = "mkTxtTelefone";
            this.mkTxtTelefone.Size = new System.Drawing.Size(163, 20);
            this.mkTxtTelefone.TabIndex = 8;
            this.mkTxtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // mkTxtCelular
            // 
            this.mkTxtCelular.Location = new System.Drawing.Point(190, 349);
            this.mkTxtCelular.Mask = "(99) 00000-0000";
            this.mkTxtCelular.Name = "mkTxtCelular";
            this.mkTxtCelular.Size = new System.Drawing.Size(176, 20);
            this.mkTxtCelular.TabIndex = 9;
            this.mkTxtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 429);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Data Alteração";
            // 
            // dtPickerAlteracao
            // 
            this.dtPickerAlteracao.Location = new System.Drawing.Point(8, 445);
            this.dtPickerAlteracao.Name = "dtPickerAlteracao";
            this.dtPickerAlteracao.Size = new System.Drawing.Size(358, 20);
            this.dtPickerAlteracao.TabIndex = 11;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(228, 12);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(74, 50);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // mTxtDtNascimento
            // 
            this.mTxtDtNascimento.Location = new System.Drawing.Point(15, 228);
            this.mTxtDtNascimento.Mask = "00/00/0000";
            this.mTxtDtNascimento.Name = "mTxtDtNascimento";
            this.mTxtDtNascimento.Size = new System.Drawing.Size(100, 20);
            this.mTxtDtNascimento.TabIndex = 4;
            this.mTxtDtNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // mTxtDtDesativ
            // 
            this.mTxtDtDesativ.Location = new System.Drawing.Point(138, 227);
            this.mTxtDtDesativ.Mask = "00/00/0000";
            this.mTxtDtDesativ.Name = "mTxtDtDesativ";
            this.mTxtDtDesativ.Size = new System.Drawing.Size(100, 20);
            this.mTxtDtDesativ.TabIndex = 5;
            this.mTxtDtDesativ.ValidatingType = typeof(System.DateTime);
            // 
            // frmCadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 475);
            this.Controls.Add(this.mTxtDtDesativ);
            this.Controls.Add(this.mTxtDtNascimento);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtPickerAlteracao);
            this.Controls.Add(this.mkTxtCelular);
            this.Controls.Add(this.mkTxtTelefone);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mkTxtCPF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtPickerInclusao);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboSexo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnIncluir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCadCliente";
            this.Text = "frmCadCliente";
            this.Load += new System.EventHandler(this.frmCadCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSexo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPickerInclusao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mkTxtCPF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox mkTxtTelefone;
        private System.Windows.Forms.MaskedTextBox mkTxtCelular;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtPickerAlteracao;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.MaskedTextBox mTxtDtNascimento;
        private System.Windows.Forms.MaskedTextBox mTxtDtDesativ;
    }
}