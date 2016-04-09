namespace Serijska_komunikacija
{
    partial class Komunikacija
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
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.cBPortovi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKonektuj = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBNarudzba = new System.Windows.Forms.ComboBox();
            this.txtPodatak = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnProzovi = new System.Windows.Forms.Button();
            this.lBNarudzbe = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // cBPortovi
            // 
            this.cBPortovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBPortovi.FormattingEnabled = true;
            this.cBPortovi.Location = new System.Drawing.Point(71, 36);
            this.cBPortovi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBPortovi.Name = "cBPortovi";
            this.cBPortovi.Size = new System.Drawing.Size(160, 24);
            this.cBPortovi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // btnKonektuj
            // 
            this.btnKonektuj.Location = new System.Drawing.Point(97, 69);
            this.btnKonektuj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKonektuj.Name = "btnKonektuj";
            this.btnKonektuj.Size = new System.Drawing.Size(100, 28);
            this.btnKonektuj.TabIndex = 2;
            this.btnKonektuj.Text = "Poveži";
            this.btnKonektuj.UseVisualStyleBackColor = true;
            this.btnKonektuj.Click += new System.EventHandler(this.btnKonektuj_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(435, 468);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(427, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dodaj narudžbu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cBNarudzba);
            this.groupBox2.Controls.Add(this.txtPodatak);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnDodaj);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(23, 174);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(376, 215);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Naručivanje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pager:";
            // 
            // cBNarudzba
            // 
            this.cBNarudzba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBNarudzba.FormattingEnabled = true;
            this.cBNarudzba.Items.AddRange(new object[] {
            "Krompiruša",
            "Zeljanica",
            "Sirnica"});
            this.cBNarudzba.Location = new System.Drawing.Point(123, 116);
            this.cBNarudzba.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBNarudzba.Name = "cBNarudzba";
            this.cBNarudzba.Size = new System.Drawing.Size(160, 24);
            this.cBNarudzba.TabIndex = 9;
            // 
            // txtPodatak
            // 
            this.txtPodatak.Enabled = false;
            this.txtPodatak.Location = new System.Drawing.Point(123, 62);
            this.txtPodatak.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPodatak.Name = "txtPodatak";
            this.txtPodatak.Size = new System.Drawing.Size(160, 22);
            this.txtPodatak.TabIndex = 4;
            this.txtPodatak.TextChanged += new System.EventHandler(this.txtPodatak_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Narudžba:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(149, 162);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(100, 28);
            this.btnDodaj.TabIndex = 5;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResetuj);
            this.groupBox1.Controls.Add(this.cBPortovi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnKonektuj);
            this.groupBox1.Location = new System.Drawing.Point(75, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(287, 143);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selektujte port:";
            // 
            // btnResetuj
            // 
            this.btnResetuj.Enabled = false;
            this.btnResetuj.Location = new System.Drawing.Point(97, 105);
            this.btnResetuj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(100, 28);
            this.btnResetuj.TabIndex = 3;
            this.btnResetuj.Text = "Resetuj";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.btnResetuj_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnProzovi);
            this.tabPage2.Controls.Add(this.lBNarudzbe);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(427, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Prozivanje";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnProzovi
            // 
            this.btnProzovi.Location = new System.Drawing.Point(163, 277);
            this.btnProzovi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProzovi.Name = "btnProzovi";
            this.btnProzovi.Size = new System.Drawing.Size(100, 28);
            this.btnProzovi.TabIndex = 1;
            this.btnProzovi.Text = "Prozovi";
            this.btnProzovi.UseVisualStyleBackColor = true;
            this.btnProzovi.Click += new System.EventHandler(this.btnProzovi_Click);
            // 
            // lBNarudzbe
            // 
            this.lBNarudzbe.FormattingEnabled = true;
            this.lBNarudzbe.ItemHeight = 16;
            this.lBNarudzbe.Location = new System.Drawing.Point(11, 36);
            this.lBNarudzbe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lBNarudzbe.Name = "lBNarudzbe";
            this.lBNarudzbe.Size = new System.Drawing.Size(401, 212);
            this.lBNarudzbe.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(427, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Gotove narudžbe";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(435, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Komunikacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 501);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Komunikacija";
            this.Text = "Embedded solutions";
            this.Load += new System.EventHandler(this.Komunikacija_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cBPortovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKonektuj;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TextBox txtPodatak;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.ComboBox cBNarudzba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProzovi;
        private System.Windows.Forms.ListBox lBNarudzbe;
        private System.Windows.Forms.Button btnResetuj;
    }
}

