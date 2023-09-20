namespace Totoloto
{
    partial class TotolotoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotolotoForm));
            txtInformations = new TextBox();
            btnAtualizarJogos = new Button();
            SuspendLayout();
            // 
            // txtInformations
            // 
            txtInformations.CharacterCasing = CharacterCasing.Upper;
            txtInformations.Location = new Point(12, 504);
            txtInformations.Multiline = true;
            txtInformations.Name = "txtInformations";
            txtInformations.ReadOnly = true;
            txtInformations.Size = new Size(829, 25);
            txtInformations.TabIndex = 50;
            txtInformations.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAtualizarJogos
            // 
            btnAtualizarJogos.BackColor = SystemColors.Control;
            btnAtualizarJogos.Enabled = false;
            btnAtualizarJogos.Font = new Font("Arial Black", 20F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtualizarJogos.ForeColor = SystemColors.Desktop;
            btnAtualizarJogos.Location = new Point(220, 150);
            btnAtualizarJogos.Name = "btnAtualizarJogos";
            btnAtualizarJogos.Size = new Size(376, 194);
            btnAtualizarJogos.TabIndex = 0;
            btnAtualizarJogos.Text = "Atualizar Jogos";
            btnAtualizarJogos.UseVisualStyleBackColor = false;
            btnAtualizarJogos.Visible = false;
            btnAtualizarJogos.Click += btnAtualizarJogos_Click;
            // 
            // TotolotoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Totoloto;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(853, 541);
            Controls.Add(btnAtualizarJogos);
            Controls.Add(txtInformations);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TotolotoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Totoloto";
            Load += Totoloto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInformations;
        private Button btnAtualizarJogos;
    }
}