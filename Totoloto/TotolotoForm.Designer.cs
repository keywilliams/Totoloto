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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TotolotoForm));
            txtInformations = new TextBox();
            btnAtualizarJogos = new Button();
            tabControlGeneral = new TabControl();
            tabPageMain = new TabPage();
            btnGenerateGame = new Button();
            tabPageConfig = new TabPage();
            btnSaveRows = new Button();
            btnAddNewRow = new Button();
            dataGridViewConfiguration = new DataGridView();
            configurationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            configurationKeyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            configurationValueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            configurationBindingSource1 = new BindingSource(components);
            configurationBindingSource = new BindingSource(components);
            tabControlGeneral.SuspendLayout();
            tabPageMain.SuspendLayout();
            tabPageConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConfiguration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)configurationBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)configurationBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txtInformations
            // 
            txtInformations.CharacterCasing = CharacterCasing.Upper;
            txtInformations.Location = new Point(10, 378);
            txtInformations.Margin = new Padding(3, 2, 3, 2);
            txtInformations.Multiline = true;
            txtInformations.Name = "txtInformations";
            txtInformations.ReadOnly = true;
            txtInformations.Size = new Size(726, 20);
            txtInformations.TabIndex = 50;
            txtInformations.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAtualizarJogos
            // 
            btnAtualizarJogos.BackColor = SystemColors.Control;
            btnAtualizarJogos.Enabled = false;
            btnAtualizarJogos.Font = new Font("Arial Black", 20F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtualizarJogos.ForeColor = SystemColors.Desktop;
            btnAtualizarJogos.Location = new Point(192, 112);
            btnAtualizarJogos.Margin = new Padding(3, 2, 3, 2);
            btnAtualizarJogos.Name = "btnAtualizarJogos";
            btnAtualizarJogos.Size = new Size(329, 146);
            btnAtualizarJogos.TabIndex = 0;
            btnAtualizarJogos.Text = "Atualizar Jogos";
            btnAtualizarJogos.UseVisualStyleBackColor = false;
            btnAtualizarJogos.Visible = false;
            btnAtualizarJogos.Click += btnAtualizarJogos_Click;
            // 
            // tabControlGeneral
            // 
            tabControlGeneral.Controls.Add(tabPageMain);
            tabControlGeneral.Controls.Add(tabPageConfig);
            tabControlGeneral.Location = new Point(10, 12);
            tabControlGeneral.Name = "tabControlGeneral";
            tabControlGeneral.SelectedIndex = 0;
            tabControlGeneral.Size = new Size(724, 346);
            tabControlGeneral.TabIndex = 52;
            // 
            // tabPageMain
            // 
            tabPageMain.BackgroundImage = Properties.Resources.Totoloto;
            tabPageMain.BackgroundImageLayout = ImageLayout.Stretch;
            tabPageMain.Controls.Add(btnGenerateGame);
            tabPageMain.Location = new Point(4, 24);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Padding = new Padding(3);
            tabPageMain.Size = new Size(716, 318);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "Main";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // btnGenerateGame
            // 
            btnGenerateGame.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerateGame.Location = new Point(14, 15);
            btnGenerateGame.Name = "btnGenerateGame";
            btnGenerateGame.Size = new Size(106, 38);
            btnGenerateGame.TabIndex = 0;
            btnGenerateGame.Text = "Gerar Jogo";
            btnGenerateGame.UseVisualStyleBackColor = true;
            btnGenerateGame.Click += btnGenerateGame_Click;
            // 
            // tabPageConfig
            // 
            tabPageConfig.BackgroundImage = Properties.Resources.Totoloto;
            tabPageConfig.BackgroundImageLayout = ImageLayout.Stretch;
            tabPageConfig.Controls.Add(btnSaveRows);
            tabPageConfig.Controls.Add(btnAddNewRow);
            tabPageConfig.Controls.Add(dataGridViewConfiguration);
            tabPageConfig.Location = new Point(4, 24);
            tabPageConfig.Name = "tabPageConfig";
            tabPageConfig.Padding = new Padding(3);
            tabPageConfig.Size = new Size(716, 318);
            tabPageConfig.TabIndex = 1;
            tabPageConfig.Text = "Config";
            tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // btnSaveRows
            // 
            btnSaveRows.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveRows.Location = new Point(535, 289);
            btnSaveRows.Name = "btnSaveRows";
            btnSaveRows.Size = new Size(75, 23);
            btnSaveRows.TabIndex = 2;
            btnSaveRows.Text = "Save";
            btnSaveRows.UseVisualStyleBackColor = true;
            btnSaveRows.Click += btnSaveRows_Click;
            // 
            // btnAddNewRow
            // 
            btnAddNewRow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddNewRow.Location = new Point(87, 289);
            btnAddNewRow.Name = "btnAddNewRow";
            btnAddNewRow.Size = new Size(75, 23);
            btnAddNewRow.TabIndex = 1;
            btnAddNewRow.Text = "Add";
            btnAddNewRow.UseVisualStyleBackColor = true;
            btnAddNewRow.Click += btnAddNewRow_Click;
            // 
            // dataGridViewConfiguration
            // 
            dataGridViewConfiguration.AllowUserToResizeColumns = false;
            dataGridViewConfiguration.AllowUserToResizeRows = false;
            dataGridViewConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewConfiguration.AutoGenerateColumns = false;
            dataGridViewConfiguration.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewConfiguration.ColumnHeadersHeight = 25;
            dataGridViewConfiguration.Columns.AddRange(new DataGridViewColumn[] { configurationIdDataGridViewTextBoxColumn, configurationKeyDataGridViewTextBoxColumn, configurationValueDataGridViewTextBoxColumn });
            dataGridViewConfiguration.DataSource = configurationBindingSource;
            dataGridViewConfiguration.Location = new Point(6, 6);
            dataGridViewConfiguration.Name = "dataGridViewConfiguration";
            dataGridViewConfiguration.RowHeadersWidth = 50;
            dataGridViewConfiguration.RowTemplate.Height = 25;
            dataGridViewConfiguration.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewConfiguration.Size = new Size(704, 277);
            dataGridViewConfiguration.TabIndex = 0;
            // 
            // configurationIdDataGridViewTextBoxColumn
            // 
            configurationIdDataGridViewTextBoxColumn.DataPropertyName = "ConfigurationId";
            configurationIdDataGridViewTextBoxColumn.HeaderText = "ConfigurationId";
            configurationIdDataGridViewTextBoxColumn.Name = "configurationIdDataGridViewTextBoxColumn";
            configurationIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // configurationKeyDataGridViewTextBoxColumn
            // 
            configurationKeyDataGridViewTextBoxColumn.DataPropertyName = "ConfigurationKey";
            configurationKeyDataGridViewTextBoxColumn.HeaderText = "ConfigurationKey";
            configurationKeyDataGridViewTextBoxColumn.Name = "configurationKeyDataGridViewTextBoxColumn";
            // 
            // configurationValueDataGridViewTextBoxColumn
            // 
            configurationValueDataGridViewTextBoxColumn.DataPropertyName = "ConfigurationValue";
            configurationValueDataGridViewTextBoxColumn.HeaderText = "ConfigurationValue";
            configurationValueDataGridViewTextBoxColumn.Name = "configurationValueDataGridViewTextBoxColumn";
            // 
            // configurationBindingSource
            // 
            configurationBindingSource.DataSource = typeof(TotolotoRepository.Models.Configuration);
            // 
            // TotolotoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Totoloto;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(746, 406);
            Controls.Add(txtInformations);
            Controls.Add(tabControlGeneral);
            Controls.Add(btnAtualizarJogos);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "TotolotoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Totoloto";
            Load += Totoloto_Load;
            tabControlGeneral.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            tabPageConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewConfiguration).EndInit();
            ((System.ComponentModel.ISupportInitialize)configurationBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)configurationBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInformations;
        private Button btnAtualizarJogos;
        private TabControl tabControlGeneral;
        private TabPage tabPageMain;
        private TabPage tabPageConfig;
        private Button btnGenerateGame;
        private DataGridView dataGridViewConfiguration;
        private BindingSource configurationBindingSource;
        private DataGridViewTextBoxColumn configurationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn configurationKeyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn configurationValueDataGridViewTextBoxColumn;
        private BindingSource configurationBindingSource1;
        private Button btnSaveRows;
        private Button btnAddNewRow;
    }
}