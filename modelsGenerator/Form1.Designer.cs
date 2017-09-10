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
            this.numPlayers = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEscenario3 = new System.Windows.Forms.RadioButton();
            this.rbEscenario2 = new System.Windows.Forms.RadioButton();
            this.rbEscenario1 = new System.Windows.Forms.RadioButton();
            this.grbScriptViewer = new System.Windows.Forms.GroupBox();
            this.btnExecuteProgram = new System.Windows.Forms.Button();
            this.richScriptViewer = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grbParameters.SuspendLayout();
            this.grbAditionalParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbScriptViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbParameters
            // 
            this.grbParameters.Controls.Add(this.btnGenScript);
            this.grbParameters.Controls.Add(this.grbAditionalParameters);
            this.grbParameters.Controls.Add(this.groupBox1);
            this.grbParameters.Location = new System.Drawing.Point(13, 6);
            this.grbParameters.Name = "grbParameters";
            this.grbParameters.Size = new System.Drawing.Size(188, 295);
            this.grbParameters.TabIndex = 0;
            this.grbParameters.TabStop = false;
            this.grbParameters.Text = "Parametros de entrada";
            // 
            // btnGenScript
            // 
            this.btnGenScript.Location = new System.Drawing.Point(26, 256);
            this.btnGenScript.Name = "btnGenScript";
            this.btnGenScript.Size = new System.Drawing.Size(126, 23);
            this.btnGenScript.TabIndex = 2;
            this.btnGenScript.Text = "Generar Script GAMS";
            this.btnGenScript.UseVisualStyleBackColor = true;
            this.btnGenScript.Click += new System.EventHandler(this.btnGenScript_Click);
            // 
            // grbAditionalParameters
            // 
            this.grbAditionalParameters.Controls.Add(this.groupBox2);
            this.grbAditionalParameters.Controls.Add(this.numPlayers);
            this.grbAditionalParameters.Controls.Add(this.label1);
            this.grbAditionalParameters.Location = new System.Drawing.Point(7, 128);
            this.grbAditionalParameters.Name = "grbAditionalParameters";
            this.grbAditionalParameters.Size = new System.Drawing.Size(170, 122);
            this.grbAditionalParameters.TabIndex = 1;
            this.grbAditionalParameters.TabStop = false;
            this.grbAditionalParameters.Text = "Parametros Adicionales";
            this.grbAditionalParameters.Enter += new System.EventHandler(this.grbAditionalParameters_Enter);
            // 
            // numPlayers
            // 
            this.numPlayers.Location = new System.Drawing.Point(100, 26);
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
            this.numPlayers.Size = new System.Drawing.Size(45, 20);
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
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# de jugadores";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEscenario3);
            this.groupBox1.Controls.Add(this.rbEscenario2);
            this.groupBox1.Controls.Add(this.rbEscenario1);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccion Escenario";
            // 
            // rbEscenario3
            // 
            this.rbEscenario3.AutoSize = true;
            this.rbEscenario3.Location = new System.Drawing.Point(20, 65);
            this.rbEscenario3.Name = "rbEscenario3";
            this.rbEscenario3.Size = new System.Drawing.Size(81, 17);
            this.rbEscenario3.TabIndex = 2;
            this.rbEscenario3.Text = "Escenario 3";
            this.rbEscenario3.UseVisualStyleBackColor = true;
            // 
            // rbEscenario2
            // 
            this.rbEscenario2.AutoSize = true;
            this.rbEscenario2.Location = new System.Drawing.Point(20, 42);
            this.rbEscenario2.Name = "rbEscenario2";
            this.rbEscenario2.Size = new System.Drawing.Size(81, 17);
            this.rbEscenario2.TabIndex = 1;
            this.rbEscenario2.Text = "Escenario 2";
            this.rbEscenario2.UseVisualStyleBackColor = true;
            // 
            // rbEscenario1
            // 
            this.rbEscenario1.AutoSize = true;
            this.rbEscenario1.Checked = true;
            this.rbEscenario1.Location = new System.Drawing.Point(20, 19);
            this.rbEscenario1.Name = "rbEscenario1";
            this.rbEscenario1.Size = new System.Drawing.Size(81, 17);
            this.rbEscenario1.TabIndex = 0;
            this.rbEscenario1.TabStop = true;
            this.rbEscenario1.Text = "Escenario 1";
            this.rbEscenario1.UseVisualStyleBackColor = true;
            // 
            // grbScriptViewer
            // 
            this.grbScriptViewer.Controls.Add(this.btnExecuteProgram);
            this.grbScriptViewer.Controls.Add(this.richScriptViewer);
            this.grbScriptViewer.Location = new System.Drawing.Point(207, 6);
            this.grbScriptViewer.Name = "grbScriptViewer";
            this.grbScriptViewer.Size = new System.Drawing.Size(612, 295);
            this.grbScriptViewer.TabIndex = 1;
            this.grbScriptViewer.TabStop = false;
            this.grbScriptViewer.Text = "Visor de Script";
            // 
            // btnExecuteProgram
            // 
            this.btnExecuteProgram.Location = new System.Drawing.Point(270, 256);
            this.btnExecuteProgram.Name = "btnExecuteProgram";
            this.btnExecuteProgram.Size = new System.Drawing.Size(103, 23);
            this.btnExecuteProgram.TabIndex = 1;
            this.btnExecuteProgram.Text = "Ejecutar Programa";
            this.btnExecuteProgram.UseVisualStyleBackColor = true;
            this.btnExecuteProgram.Click += new System.EventHandler(this.btnExecuteProgram_Click);
            // 
            // richScriptViewer
            // 
            this.richScriptViewer.Location = new System.Drawing.Point(7, 19);
            this.richScriptViewer.Name = "richScriptViewer";
            this.richScriptViewer.Size = new System.Drawing.Size(599, 231);
            this.richScriptViewer.TabIndex = 0;
            this.richScriptViewer.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(7, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Guardar Resultados ";
            // 
            // frmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 305);
            this.Controls.Add(this.grbScriptViewer);
            this.Controls.Add(this.grbParameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Models Generator App";
            this.Load += new System.EventHandler(this.frmApp_Load);
            this.grbParameters.ResumeLayout(false);
            this.grbAditionalParameters.ResumeLayout(false);
            this.grbAditionalParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbScriptViewer.ResumeLayout(false);
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
    }
}

