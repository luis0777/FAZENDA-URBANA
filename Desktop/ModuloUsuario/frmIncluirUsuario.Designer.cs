namespace Desktop.ModuloUsuario
{
    partial class frmIncluirUsuario
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
            lblCep = new Label();
            mskCep = new MaskedTextBox();
            lblBairro = new Label();
            txtBairro = new TextBox();
            SuspendLayout();
            // 
            // lblCep
            // 
            lblCep.AutoSize = true;
            lblCep.Location = new Point(29, 26);
            lblCep.Name = "lblCep";
            lblCep.Size = new Size(31, 15);
            lblCep.TabIndex = 0;
            lblCep.Text = "Cep:";
            // 
            // mskCep
            // 
            mskCep.Location = new Point(109, 26);
            mskCep.Mask = "00000-000";
            mskCep.Name = "mskCep";
            mskCep.Size = new Size(100, 23);
            mskCep.TabIndex = 1;
            mskCep.MaskInputRejected += mskCep_MaskInputRejected;
            // 
            // lblBairro
            // 
            lblBairro.AutoSize = true;
            lblBairro.Location = new Point(29, 86);
            lblBairro.Name = "lblBairro";
            lblBairro.Size = new Size(41, 15);
            lblBairro.TabIndex = 2;
            lblBairro.Text = "Bairro:";
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(112, 81);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(100, 23);
            txtBairro.TabIndex = 3;
            // 
            // frmIncluirUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBairro);
            Controls.Add(lblBairro);
            Controls.Add(mskCep);
            Controls.Add(lblCep);
            Name = "frmIncluirUsuario";
            Text = "frmIncluirUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCep;
        private MaskedTextBox mskCep;
        private Label lblBairro;
        private TextBox txtBairro;
    }
}