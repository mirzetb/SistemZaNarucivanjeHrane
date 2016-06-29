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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnProzovi = new System.Windows.Forms.Button();
            this.lbNarudzbe = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNarudzba = new System.Windows.Forms.ComboBox();
            this.tbPager = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.cBPortovi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKonektuj = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.btnProzovi);
            this.tabPage2.Controls.Add(this.lbNarudzbe);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(339, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Prozivanje";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::Serijska_komunikacija.Properties.Resources.cancel;
            this.button1.Location = new System.Drawing.Point(176, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 42);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnProzovi
            // 
            this.btnProzovi.Image = global::Serijska_komunikacija.Properties.Resources.phone_call;
            this.btnProzovi.Location = new System.Drawing.Point(8, 270);
            this.btnProzovi.Name = "btnProzovi";
            this.btnProzovi.Size = new System.Drawing.Size(150, 42);
            this.btnProzovi.TabIndex = 1;
            this.btnProzovi.UseVisualStyleBackColor = true;
            this.btnProzovi.Click += new System.EventHandler(this.btnProzovi_Click);
            // 
            // lbNarudzbe
            // 
            this.lbNarudzbe.FormattingEnabled = true;
            this.lbNarudzbe.Location = new System.Drawing.Point(8, 6);
            this.lbNarudzbe.Name = "lbNarudzbe";
            this.lbNarudzbe.Size = new System.Drawing.Size(318, 251);
            this.lbNarudzbe.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(339, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dodaj narudžbu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbNarudzba);
            this.groupBox2.Controls.Add(this.tbPager);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnDodaj);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 153);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Naručivanje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pager:";
            // 
            // cbNarudzba
            // 
            this.cbNarudzba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNarudzba.FormattingEnabled = true;
            this.cbNarudzba.Items.AddRange(new object[] {
            "Krompiruša",
            "Zeljanica",
            "Sirnica",
            "Burek"});
            this.cbNarudzba.Location = new System.Drawing.Point(112, 68);
            this.cbNarudzba.Name = "cbNarudzba";
            this.cbNarudzba.Size = new System.Drawing.Size(104, 21);
            this.cbNarudzba.TabIndex = 9;
            // 
            // tbPager
            // 
            this.tbPager.Location = new System.Drawing.Point(112, 29);
            this.tbPager.Name = "tbPager";
            this.tbPager.Size = new System.Drawing.Size(104, 20);
            this.tbPager.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Narudžba:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(112, 108);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(104, 23);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 139);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selektujte port:";
            // 
            // btnResetuj
            // 
            this.btnResetuj.Enabled = false;
            this.btnResetuj.Location = new System.Drawing.Point(112, 100);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(104, 23);
            this.btnResetuj.TabIndex = 3;
            this.btnResetuj.Text = "Resetuj";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.btnResetuj_Click);
            // 
            // cBPortovi
            // 
            this.cBPortovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBPortovi.FormattingEnabled = true;
            this.cBPortovi.Location = new System.Drawing.Point(112, 24);
            this.cBPortovi.Name = "cBPortovi";
            this.cBPortovi.Size = new System.Drawing.Size(104, 21);
            this.cBPortovi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // btnKonektuj
            // 
            this.btnKonektuj.Location = new System.Drawing.Point(112, 62);
            this.btnKonektuj.Name = "btnKonektuj";
            this.btnKonektuj.Size = new System.Drawing.Size(104, 23);
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
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(347, 349);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(339, 323);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Komunikacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 351);
            this.Controls.Add(this.tabControl1);
            this.Name = "Komunikacija";
            this.Text = "Restaurant Paging System";
            this.Load += new System.EventHandler(this.Komunikacija_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnProzovi;
        private System.Windows.Forms.ListBox lbNarudzbe;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNarudzba;
        private System.Windows.Forms.TextBox tbPager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResetuj;
        private System.Windows.Forms.ComboBox cBPortovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKonektuj;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

