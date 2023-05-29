using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Elaborazione_dati_CSV
{
    public partial class Form1 : Form
    {
        public string path = @"../../Arrigoni.csv";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numcasual();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Contacampi();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        //Funzioni di servizio
        public void numcasual()
        {
            Random num = new Random();

            string[] arr = new string[1000];

            int dim = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                string a = sw.ReadLine();

                while (a != null)
                {
                    if (dim == 0)
                    {
                        arr[dim] = a + ";miovalore";
                    }
                    else
                    {
                        string b = (num.Next(10, 21)).ToString();
                        arr[dim] = a + ";" + b;
                    }
                    dim++;
                    a = sw.ReadLine();
                }


            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                while (arr[dim] != null)
                {
                    sw.WriteLine(arr[dim]);
                    dim++;
                }
            }
        }

        public void Contacampi()
        {
            using (StreamReader sw = new StreamReader(path))
            {
                string a = sw.ReadLine();

                string[] campi = a.Split(';');

                int lun = campi.Length;

                listView1.Clear();
                listView1.Items.Add("Ogni record è composto da: " + lun + " campi.");
            }
        }
    }
}