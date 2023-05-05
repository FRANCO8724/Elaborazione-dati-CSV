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
        public string path = @"Arrigoni.csv";

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
            Random num = new Random();

            StreamReader sw = new StreamReader(path);

            int a = num.Next(10, 21);

            p[dim].Casual = a.ToString();


            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        //Funzioni di servizio

        public void Riemp(Elementi[] p)
        {

            for(int i = 0; i < p.Length; i++)
            {
                StreamReader sw = new StreamReader(path);

                string a = sw.ReadLine();
                
               string []campi = a.Split(';');

                p[i].COD_ACQ = campi[0];
                p[i].ACQUEDOTTO = campi[1];
                p[i]. COMUNE = campi[2];
                p[i].SIGLA_PROV = campi[3];
                p[i].CAP = campi[4];
                p[i].DISTRETTO = campi[5];
                p[i].COD_PROD = campi[6];
                p[i].PRODUTTORE = campi[7];
                p[i].LUOGO_PREL = campi[8];
                p[i].ETICHETTA = campi[9];
                p[i].NOTE= campi[10];
               
    }

        }
    }
}
