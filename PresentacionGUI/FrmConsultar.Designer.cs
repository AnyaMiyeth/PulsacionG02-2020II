namespace PresentacionGUI
{
    partial class FrmConsultar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultar));
            this.DtgPersona = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TxtFiltrar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFiltroSexo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgPersona
            // 
            this.DtgPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgPersona.Location = new System.Drawing.Point(60, 363);
            this.DtgPersona.Name = "DtgPersona";
            this.DtgPersona.RowHeadersWidth = 102;
            this.DtgPersona.RowTemplate.Height = 40;
            this.DtgPersona.Size = new System.Drawing.Size(1206, 425);
            this.DtgPersona.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 194);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 38);
            this.textBox1.TabIndex = 2;
            // 
            // TxtFiltrar
            // 
            this.TxtFiltrar.AutoSize = true;
            this.TxtFiltrar.Location = new System.Drawing.Point(133, 194);
            this.TxtFiltrar.Name = "TxtFiltrar";
            this.TxtFiltrar.Size = new System.Drawing.Size(127, 32);
            this.TxtFiltrar.TabIndex = 3;
            this.TxtFiltrar.Text = "Filtar por";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, -5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1203, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Location = new System.Drawing.Point(877, 161);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(317, 140);
            this.BtnConsultar.TabIndex = 18;
            this.BtnConsultar.Text = "Consultar";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filtar por";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CmbFiltroSexo
            // 
            this.CmbFiltroSexo.FormattingEnabled = true;
            this.CmbFiltroSexo.Items.AddRange(new object[] {
            "F",
            "M",
            "Todos"});
            this.CmbFiltroSexo.Location = new System.Drawing.Point(341, 266);
            this.CmbFiltroSexo.Name = "CmbFiltroSexo";
            this.CmbFiltroSexo.Size = new System.Drawing.Size(471, 39);
            this.CmbFiltroSexo.TabIndex = 20;
            // 
            // FrmConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 929);
            this.Controls.Add(this.CmbFiltroSexo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtFiltrar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DtgPersona);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Pulsaciones";
            this.Load += new System.EventHandler(this.FrmConsultar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DtgPersona;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label TxtFiltrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFiltroSexo;
    }
}