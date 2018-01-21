namespace modelsGenerator
{
    partial class frmApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApp));
            this.grbParameters = new System.Windows.Forms.GroupBox();
            this.btnGenScript = new System.Windows.Forms.Button();
            this.grbAditionalParameters = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numPlayers = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEscenario3 = new System.Windows.Forms.RadioButton();
            this.rbEscenario2 = new System.Windows.Forms.RadioButton();
            this.rbEscenario1 = new System.Windows.Forms.RadioButton();
            this.grbScriptViewer = new System.Windows.Forms.GroupBox();
            this.grbConsole = new System.Windows.Forms.GroupBox();
            this.richConsoleViewer = new System.Windows.Forms.RichTextBox();
            this.btnExecuteProgram = new System.Windows.Forms.Button();
            this.richScriptViewer = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLeadTime = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fbdResults = new System.Windows.Forms.FolderBrowserDialog();
            this.txtResultDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.grbParameters.SuspendLayout();
            this.grbAditionalParameters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbScriptViewer.SuspendLayout();
            this.grbConsole.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbParameters
            // 
            this.grbParameters.Controls.Add(this.btnGenScript);
            this.grbParameters.Controls.Add(this.grbAditionalParameters);
            this.grbParameters.Controls.Add(this.groupBox1);
            this.grbParameters.Location = new System.Drawing.Point(17, 7);
            this.grbParameters.Margin = new System.Windows.Forms.Padding(4);
            this.grbParameters.Name = "grbParameters";
            this.grbParameters.Padding = new System.Windows.Forms.Padding(4);
            this.grbParameters.Size = new System.Drawing.Size(251, 497);
            this.grbParameters.TabIndex = 0;
            this.grbParameters.TabStop = false;
            this.grbParameters.Text = "Parametros de entrada";
            // 
            // btnGenScript
            // 
            this.btnGenScript.Location = new System.Drawing.Point(33, 461);
            this.btnGenScript.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenScript.Name = "btnGenScript";
            this.btnGenScript.Size = new System.Drawing.Size(168, 28);
            this.btnGenScript.TabIndex = 2;
            this.btnGenScript.Text = "Generar Script GAMS";
            this.btnGenScript.UseVisualStyleBackColor = true;
            this.btnGenScript.Click += new System.EventHandler(this.btnGenScript_Click);
            // 
            // grbAditionalParameters
            // 
            this.grbAditionalParameters.Controls.Add(this.groupBox4);
            this.grbAditionalParameters.Controls.Add(this.groupBox2);
            this.grbAditionalParameters.Controls.Add(this.numPlayers);
            this.grbAditionalParameters.Controls.Add(this.label1);
            this.grbAditionalParameters.Location = new System.Drawing.Point(9, 158);
            this.grbAditionalParameters.Margin = new System.Windows.Forms.Padding(4);
            this.grbAditionalParameters.Name = "grbAditionalParameters";
            this.grbAditionalParameters.Padding = new System.Windows.Forms.Padding(4);
            this.grbAditionalParameters.Size = new System.Drawing.Size(227, 295);
            this.grbAditionalParameters.TabIndex = 1;
            this.grbAditionalParameters.TabStop = false;
            this.grbAditionalParameters.Text = "Parametros Adicionales";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLeadTime);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(9, 66);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(209, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lead Time";
            // 
            // numPlayers
            // 
            this.numPlayers.Location = new System.Drawing.Point(133, 32);
            this.numPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.numPlayers.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPlayers.Name = "numPlayers";
            this.numPlayers.ReadOnly = true;
            this.numPlayers.Size = new System.Drawing.Size(60, 22);
            this.numPlayers.TabIndex = 1;
            this.numPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "# de jugadores";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEscenario3);
            this.groupBox1.Controls.Add(this.rbEscenario2);
            this.groupBox1.Controls.Add(this.rbEscenario1);
            this.groupBox1.Location = new System.Drawing.Point(8, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(228, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccion Escenario";
            // 
            // rbEscenario3
            // 
            this.rbEscenario3.AutoSize = true;
            this.rbEscenario3.Location = new System.Drawing.Point(27, 80);
            this.rbEscenario3.Margin = new System.Windows.Forms.Padding(4);
            this.rbEscenario3.Name = "rbEscenario3";
            this.rbEscenario3.Size = new System.Drawing.Size(104, 21);
            this.rbEscenario3.TabIndex = 2;
            this.rbEscenario3.Text = "Escenario 3";
            this.rbEscenario3.UseVisualStyleBackColor = true;
            // 
            // rbEscenario2
            // 
            this.rbEscenario2.AutoSize = true;
            this.rbEscenario2.Location = new System.Drawing.Point(27, 52);
            this.rbEscenario2.Margin = new System.Windows.Forms.Padding(4);
            this.rbEscenario2.Name = "rbEscenario2";
            this.rbEscenario2.Size = new System.Drawing.Size(104, 21);
            this.rbEscenario2.TabIndex = 1;
            this.rbEscenario2.Text = "Escenario 2";
            this.rbEscenario2.UseVisualStyleBackColor = true;
            // 
            // rbEscenario1
            // 
            this.rbEscenario1.AutoSize = true;
            this.rbEscenario1.Checked = true;
            this.rbEscenario1.Location = new System.Drawing.Point(27, 23);
            this.rbEscenario1.Margin = new System.Windows.Forms.Padding(4);
            this.rbEscenario1.Name = "rbEscenario1";
            this.rbEscenario1.Size = new System.Drawing.Size(104, 21);
            this.rbEscenario1.TabIndex = 0;
            this.rbEscenario1.TabStop = true;
            this.rbEscenario1.Text = "Escenario 1";
            this.rbEscenario1.UseVisualStyleBackColor = true;
            // 
            // grbScriptViewer
            // 
            this.grbScriptViewer.Controls.Add(this.grbConsole);
            this.grbScriptViewer.Controls.Add(this.btnExecuteProgram);
            this.grbScriptViewer.Controls.Add(this.richScriptViewer);
            this.grbScriptViewer.Location = new System.Drawing.Point(578, 7);
            this.grbScriptViewer.Margin = new System.Windows.Forms.Padding(4);
            this.grbScriptViewer.Name = "grbScriptViewer";
            this.grbScriptViewer.Padding = new System.Windows.Forms.Padding(4);
            this.grbScriptViewer.Size = new System.Drawing.Size(545, 497);
            this.grbScriptViewer.TabIndex = 1;
            this.grbScriptViewer.TabStop = false;
            this.grbScriptViewer.Text = "Visor de Script";
            // 
            // grbConsole
            // 
            this.grbConsole.Controls.Add(this.richConsoleViewer);
            this.grbConsole.Location = new System.Drawing.Point(9, 270);
            this.grbConsole.Name = "grbConsole";
            this.grbConsole.Size = new System.Drawing.Size(527, 184);
            this.grbConsole.TabIndex = 2;
            this.grbConsole.TabStop = false;
            this.grbConsole.Text = "Consola";
            // 
            // richConsoleViewer
            // 
            this.richConsoleViewer.Location = new System.Drawing.Point(7, 22);
            this.richConsoleViewer.Name = "richConsoleViewer";
            this.richConsoleViewer.ReadOnly = true;
            this.richConsoleViewer.Size = new System.Drawing.Size(514, 156);
            this.richConsoleViewer.TabIndex = 0;
            this.richConsoleViewer.Text = "";
            // 
            // btnExecuteProgram
            // 
            this.btnExecuteProgram.Location = new System.Drawing.Point(202, 461);
            this.btnExecuteProgram.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecuteProgram.Name = "btnExecuteProgram";
            this.btnExecuteProgram.Size = new System.Drawing.Size(137, 28);
            this.btnExecuteProgram.TabIndex = 1;
            this.btnExecuteProgram.Text = "Ejecutar Programa";
            this.btnExecuteProgram.UseVisualStyleBackColor = true;
            this.btnExecuteProgram.Click += new System.EventHandler(this.btnExecuteProgram_Click);
            // 
            // richScriptViewer
            // 
            this.richScriptViewer.Location = new System.Drawing.Point(9, 23);
            this.richScriptViewer.Margin = new System.Windows.Forms.Padding(4);
            this.richScriptViewer.Name = "richScriptViewer";
            this.richScriptViewer.ReadOnly = true;
            this.richScriptViewer.Size = new System.Drawing.Size(527, 239);
            this.richScriptViewer.TabIndex = 0;
            this.richScriptViewer.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLimpiar);
            this.groupBox3.Controls.Add(this.dgvParameters);
            this.groupBox3.Location = new System.Drawing.Point(276, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(294, 497);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variables y Parametros";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(95, 461);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescripcion,
            this.colValor});
            this.dgvParameters.Location = new System.Drawing.Point(11, 23);
            this.dgvParameters.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.Size = new System.Drawing.Size(275, 430);
            this.dgvParameters.TabIndex = 0;
            this.dgvParameters.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvVariables_CellBeginEdit);
            this.dgvParameters.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVariables_CellEndEdit);
            this.dgvParameters.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvVariables_EditingControlShowing);
            this.dgvParameters.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvVariables_KeyPress);
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 70;
            // 
            // colValor
            // 
            this.colValor.HeaderText = "valor";
            this.colValor.Name = "colValor";
            this.colValor.Width = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor";
            // 
            // txtLeadTime
            // 
            this.txtLeadTime.Location = new System.Drawing.Point(63, 31);
            this.txtLeadTime.Name = "txtLeadTime";
            this.txtLeadTime.Size = new System.Drawing.Size(121, 22);
            this.txtLeadTime.TabIndex = 1;
            this.txtLeadTime.Text = "0.0";
            this.txtLeadTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLeadTime_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBrowseFolder);
            this.groupBox4.Controls.Add(this.txtResultDirectory);
            this.groupBox4.Location = new System.Drawing.Point(9, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(209, 76);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Guardar Resultados";
            // 
            // txtResultDirectory
            // 
            this.txtResultDirectory.Location = new System.Drawing.Point(15, 30);
            this.txtResultDirectory.Name = "txtResultDirectory";
            this.txtResultDirectory.ReadOnly = true;
            this.txtResultDirectory.Size = new System.Drawing.Size(143, 22);
            this.txtResultDirectory.TabIndex = 0;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(164, 30);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(39, 23);
            this.btnBrowseFolder.TabIndex = 1;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // frmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 517);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grbScriptViewer);
            this.Controls.Add(this.grbParameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Models Generator App";
            this.grbParameters.ResumeLayout(false);
            this.grbAditionalParameters.ResumeLayout(false);
            this.grbAditionalParameters.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbScriptViewer.ResumeLayout(false);
            this.grbConsole.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbParameters;
        private System.Windows.Forms.Button btnGenScript;
        private System.Windows.Forms.GroupBox grbAditionalParameters;
        private System.Windows.Forms.NumericUpDown numPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEscenario3;
        private System.Windows.Forms.RadioButton rbEscenario2;
        private System.Windows.Forms.RadioButton rbEscenario1;
        private System.Windows.Forms.GroupBox grbScriptViewer;
        private System.Windows.Forms.Button btnExecuteProgram;
        private System.Windows.Forms.RichTextBox richScriptViewer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox grbConsole;
        private System.Windows.Forms.RichTextBox richConsoleViewer;
        private System.Windows.Forms.TextBox txtLeadTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FolderBrowserDialog fbdResults;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtResultDirectory;
    }
}

