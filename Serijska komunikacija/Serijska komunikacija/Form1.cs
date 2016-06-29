using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Serijska_komunikacija
{
    public partial class Komunikacija : Form
    {
        List<string> Portovi = new List<string>();
        List<Narudzba> Narudzbe = new List<Narudzba>();
        bool daoNaziv = false;
        

        public Komunikacija()
        {
            InitializeComponent();
        }

        private void btnKonektuj_Click(object sender, EventArgs e)
        {
            if (cBPortovi.Text == "") MessageBox.Show("Selektirajte port", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!daoNaziv)
            {
                serialPort.PortName = cBPortovi.Text;
                serialPort.BaudRate = 9600;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.ReadTimeout = 500;
                serialPort.Handshake = Handshake.None;
                daoNaziv = true;
                btnKonektuj.Enabled = false;
                cBPortovi.Enabled = false;
                btnResetuj.Enabled = true;
                groupBox2.Enabled = true;
            }

            if(daoNaziv)
            {
                try
                {
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Komunikacija_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            foreach (string s in SerialPort.GetPortNames())
            {
                cBPortovi.Items.Add(s);
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(PrikaziPodatak));
        }

        private void PrikaziPodatak(object sender, EventArgs e)
        {
            MessageBox.Show(serialPort.ReadExisting());
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string pager = tbPager.Text;
            if(pager == "")
            {
                MessageBox.Show("Niste unijeli broj pagera!", "Omaska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte pagerID;
            if(!Byte.TryParse(pager, out pagerID)) {
                MessageBox.Show("Broj pagera mora biti u rasponu 0 - 255 (osim 42 i 35)!", "Omaska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cbNarudzba.Text == "")
            {
                MessageBox.Show("Niste odabrali narudzbu!", "Omaska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(Narudzbe.Any(n => n.Pager == pagerID))
            {
                MessageBox.Show("Pager zauzet!", "Omaska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Narudzbe.Add(new Narudzba(cbNarudzba.Text, pagerID));
            MessageBox.Show("Narudzba: " + cbNarudzba.Text + " uspjesno dodana.", "Uspijeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tbPager.Text = "";
        }

        private void btnResetuj_Click(object sender, EventArgs e)
        {
            cBPortovi.Enabled = true;
            btnKonektuj.Enabled = true;
            cBPortovi.ResetText();
            btnResetuj.Enabled = false;
            daoNaziv = false;
            groupBox2.Enabled = false;
            serialPort.Close();
        }

        private byte send(byte header)
        {
            if (lbNarudzbe.Text == "")
            {
                MessageBox.Show("Niste odabrali naruzbu", "Omaska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 35;
            }
            string num = lbNarudzbe.Text[0].ToString() + lbNarudzbe.Text[1].ToString();
            byte pager = Byte.Parse(num);

            byte[] buffer = { header, pager };
            try
            {
                serialPort.Write(buffer, 0, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return pager;
        }
        private void btnProzovi_Click(object sender, EventArgs e)
        {
            send(42);
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            byte pager = send(35);
            if (pager != 35)
            {
                var ind = Narudzbe.FindIndex(n => n.Pager == pager);
                Narudzbe.RemoveAt(ind);
                lbNarudzbe.DataSource = new List<Narudzba>(Narudzbe);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                lbNarudzbe.DataSource = new List<Narudzba>(Narudzbe);
            }
        }
    }
}
