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
        public int lmax;
        public string path = @"C:\Users\39370\Source\Repos\Elaborazione-dati-CSV\Elaborazione dati CSV\Arrigoni.csv";

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
        private void button3_Click_1(object sender, EventArgs e)
        {
            lmax = Lunghezzamax(p);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ridimensione(lmax, p);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Aggiuntarec(p);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Visualcampi(p);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
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
            return p[dim].COD_ACQ + ";" + p[dim].ACQUEDOTTO + ";" + p[dim].COMUNE + ";" + p[dim].SIGLA_PROV + ";" + p[dim].CAP + ";" + p[dim].DISTRETTO + ";" + p[dim].COD_PROD + ";" + p[dim].PRODUTTORE + ";" + p[dim].LUOGO_PREL + ";" + p[dim].ETICHETTA + ";" + p[dim].NOTE;
        }

        public void Aggiunta(Elementi[] p)
        {
            
            Random num = new Random();

            StreamWriter sw = new StreamWriter(path);

            int b = 0;
            dim = 0;

            while (p[dim].COD_ACQ != null)
            {
                int a = num.Next(10, 21);

                if(dim == 0)
                {
                    p[dim].Casual = "miovalore";
                }
                else
                {
                    p[dim].Casual = a.ToString();
                }                

                string d = Str(p, dim) + ";" + p[dim].Casual;

                sw.WriteLine(d);
                b++;
                dim++;

            }

            sw.Close();
        }

        public int Lunghezzamax(Elementi[] p)
        {
            StreamReader sr = new StreamReader(path);

            dim = 0;

            string a = sr.ReadLine();

            string q = p[dim].COD_ACQ;
            string w = p[dim].ACQUEDOTTO;
            string e = p[dim].COMUNE;
            string r = p[dim].SIGLA_PROV;
            string t = p[dim].CAP;
            string y = p[dim].DISTRETTO;
            string u = p[dim].PRODUTTORE;
            string i = p[dim].LUOGO_PREL;
            string o = p[dim].ETICHETTA;
            string l = p[dim].NOTE;
            string k = p[dim].Casual;


            while (a != null)
            {
                string b = sr.ReadLine();

                if (b != null)
                {
                    if (a.Length < b.Length)
                    {
                        a = b;
                    }

                    if ((p[dim].COD_ACQ).Length < (p[dim+1].COD_ACQ).Length)
                    {
                        q = p[dim + 1].COD_ACQ;
                    }

                    if ((p[dim].ACQUEDOTTO).Length < (p[dim + 1].ACQUEDOTTO).Length)
                    {
                        w = p[dim + 1].ACQUEDOTTO;
                    }

                    if ((p[dim].COMUNE).Length < (p[dim + 1].COMUNE).Length)
                    {
                        e = p[dim + 1].COMUNE;
                    }

                    if ((p[dim].SIGLA_PROV).Length < (p[dim + 1].SIGLA_PROV).Length)
                    {
                        r = p[dim + 1].SIGLA_PROV;
                    }

                    if ((p[dim].CAP).Length < (p[dim + 1].CAP).Length)
                    {
                        t = p[dim + 1].CAP;
                    }

                    if ((p[dim].DISTRETTO).Length < (p[dim + 1].DISTRETTO).Length)
                    {
                        y = p[dim + 1].DISTRETTO;
                    }

                    if ((p[dim].PRODUTTORE).Length < (p[dim + 1].PRODUTTORE).Length)
                    {
                        u = p[dim + 1].PRODUTTORE;
                    }

                    if ((p[dim].LUOGO_PREL).Length < (p[dim + 1].LUOGO_PREL).Length)
                    {
                        i = p[dim + 1].LUOGO_PREL;
                    }

                    if ((p[dim].ETICHETTA).Length < (p[dim + 1].ETICHETTA).Length)
                    {
                        o = p[dim + 1].ETICHETTA;
                    }

                    if ((p[dim].NOTE).Length < (p[dim + 1].NOTE).Length)
                    {
                        l = p[dim + 1].NOTE;
                    }

                    if (p[dim].Casual == null)
                    {
                        k = "";
                    }
                    else
                    {
                        if ((p[dim].Casual).Length < (p[dim + 1].Casual).Length )
                        {
                            k = p[dim + 1].Casual;
                        }
                    }

                }
                else
                {
                    break;
                }

            }

            sr.Close();

            listView1.Items.Clear();
            listView1.Items.Add("Lunghezza max riga: " + a.Length);
            listView1.Items.Add("Lunghezza max primo campo: " + q.Length);
            listView1.Items.Add("Lunghezza max secondo campo: " + w.Length);
            listView1.Items.Add("Lunghezza max terzo campo: " + e.Length);
            listView1.Items.Add("Lunghezza max quarto campo: " + r.Length);
            listView1.Items.Add("Lunghezza max quinto campo: " + t.Length);
            listView1.Items.Add("Lunghezza max sesto campo: " + y.Length);
            listView1.Items.Add("Lunghezza max settimo campo: " + u.Length);
            listView1.Items.Add("Lunghezza max ottavo campo: " + i.Length);
            listView1.Items.Add("Lunghezza max nono campo: " + o.Length);
            listView1.Items.Add("Lunghezza max decimo campo: " + l.Length);
            listView1.Items.Add("Lunghezza max undicesimo campo: " + k.Length);

            return a.Length;
        }

        public void Ridimensione(int lung, Elementi[] p)
        {
            dim = 0;

            string[] supp = new string[100];

            StreamReader sw = new StreamReader(path);

                    string a = sw.ReadLine();

                    while (a != null)
                    {
                        if (p[dim].COD_ACQ != null)
                        {
                            int d = lung - a.Length;

                            string f = "";

                            for (int i = 0; i < d; i++)
                            {
                                f = f + " ";
                            }

                            supp[dim] = a + f;

                        }

                a = sw.ReadLine();
                dim++;
                    }
                
                 sw.Close();

            StreamWriter sw2 = new StreamWriter(path);

            dim= 0;

            sw2.WriteLine(supp[dim]);

            while (supp[dim] != null)
            {
                dim++;

                sw2.WriteLine(supp[dim]);
            }

            sw2.Close();

        }

        public void Aggiuntarec(Elementi[] p)
        {
                using (StreamReader sw = new StreamReader(path))
                {

                    string b = textBox1.Text;

                    string[] campi = b.Split(';');

                dim = 0;

                    int C = 0;

                    while (C == 0)
                    {
                          string a = sw.ReadLine();

                        if(a != null)
                        {
                            dim++;
                        }
                        else
                        {
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

                            C = 1;
                        }
                    }
                }

                using(StreamWriter sw = new StreamWriter(path,true))
                {
                    sw.WriteLine(Str(p,dim));
                }
            
        }

        public void Visualcampi(Elementi[]p)
        {
            int v = 0;
            int b = 0;
            int c = 0;

            using (StreamReader sw = new StreamReader(path))
            {                

                string s = sw.ReadLine();

                string[] campi = s.Split(';');

                for (int i = 0;i<campi.Length;i++)
                {

                    if (campi[i] == textBox2.Text)
                    {
                        v = i;
                    }
                    if (campi[i] == textBox3.Text)
                    {
                        b = i;
                    }
                    if (campi[i] == textBox4.Text)
                    {
                        c = i;
                    }

                }

            }

            dim = 0;



            using (StreamReader sr = new StreamReader(path))
            {
                  
                string a = sr.ReadLine();

                

                listView1.Clear();

                while (a != null)
                {
                    string[] campi = a.Split(';');

                    listView1.Items.Add("Campo 1: " + campi[v]);
                    listView1.Items.Add("Campo 2: " + campi[b]);
                    listView1.Items.Add("Campo 3: " + campi[c]);
                    listView1.Items.Add("");

                    a = sr.ReadLine();
                }

            }
            
        }

    }
}