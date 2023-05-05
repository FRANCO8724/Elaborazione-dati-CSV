using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elaborazione_dati_CSV
{
    public partial class Form1 : Form
    {
        public struct Elementi
        {
            public string COD_ACQ;
            public string ACQUEDOTTO;
            public string COMUNE;
            public string SIGLA_PROV;
            public string CAP;
            public string DISTRETTO;
            public string COD_PROD;
            public string PRODUTTORE;
            public string LUOGO_PREL;
            public string ETICHETTA;
            public string NOTE;
            public string Casual;
        }

        public Elementi[] p;
        public int dim;
        public string path = @"C:\Users\39370\Desktop\Elaborazione-dati-CSV-master\Elaborazione dati CSV\Arrigoni.csv";

        public Form1()
        {
            InitializeComponent();
            p = new Elementi[100];
            dim = 0;
            Riemp(p);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aggiunta(p);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //Funzioni di servizio

        public void Riemp(Elementi[] p)
        {
            StreamReader sw = new StreamReader(path);

            string a = sw.ReadLine();

            while (a != null)
            {

                string[] campi = a.Split(';');

                p[dim].COD_ACQ = campi[0];
                p[dim].ACQUEDOTTO = campi[1];
                p[dim].COMUNE = campi[2];
                p[dim].SIGLA_PROV = campi[3];
                p[dim].CAP = campi[4];
                p[dim].DISTRETTO = campi[5];
                p[dim].COD_PROD = campi[6];
                p[dim].PRODUTTORE = campi[7];
                p[dim].LUOGO_PREL = campi[8];
                p[dim].ETICHETTA = campi[9];
                p[dim].NOTE = campi[10];

                a = sw.ReadLine();

                dim++;
            }

            sw.Close();

        }

        public string Str(Elementi[] p, int dim)
        {
            return p[dim].COD_ACQ + ";" + p[dim].ACQUEDOTTO + ";" + p[dim].COMUNE + ";" + p[dim].SIGLA_PROV + ";" + p[dim].CAP + ";" + p[dim].DISTRETTO + ";" + p[dim].COD_PROD + ";" + p[dim].PRODUTTORE + ";" + p[dim].LUOGO_PREL + ";" + p[dim].ETICHETTA + ";" + p[dim].NOTE + ";" + p[dim].Casual;
        }

        public void Aggiunta(Elementi[] p)
        {

            Random num = new Random();

            StreamWriter sw = new StreamWriter(path);

            int b = 0;
            dim = 0;

            while (b < 76)
            {
                int a = num.Next(10, 21);

                p[dim].Casual = a.ToString();

                string d = Str(p, dim);

                listView1.Items.Add(d);

                sw.WriteLine(d);
                b++;
                dim++;

            }

            sw.Close();
        }


    }
}

