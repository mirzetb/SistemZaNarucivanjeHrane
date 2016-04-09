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
                    serialPort.Write("Pocetak");
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
            txtPodatak.Text = serialPort.ReadExisting();

            serialPort.Write("*");
            serialPort.Write("A");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            serialPort.Write("#");
            /*
            if (txtPodatak.Text == "")
            {
                MessageBox.Show("Pager nije detektovan", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (cBNarudzba.Text == "")
            {
                MessageBox.Show("Niste odabrali narudžbu", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                Narudzbe.Add(new Narudzba(cBNarudzba.Text, "Cekanje", txtPodatak.Text));
                txtPodatak.ResetText();
                cBNarudzba.Text = "";
                MessageBox.Show("Naručivanje uspješno obavljeno", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }

        private void txtPodatak_TextChanged(object sender, EventArgs e)
        {

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

        private void btnProzovi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
       
            serialPort.Write("a");
        }
    }
}
