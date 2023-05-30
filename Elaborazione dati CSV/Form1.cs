using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Elaborazione_dati_CSV
{
    public partial class Form1 : Form
    {
        public string path = @"../../Arrigoni.csv";
        public int lung = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void textBox18_TextChanged(object sender, EventArgs e)
        {

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
            lung = Lungmax();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lungfissa(lung);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Aggrecord();
            textBox1.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox18.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Viscampi();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ricercarec();
            textBox5.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Modifica();
            textBox6.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Canclog();
            textBox8.Text = "";
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

        public int Lungmax()
        {
            int lung = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                int dim = 0;

                string a = sw.ReadLine();

                string[] campi = a.Split(';');

                int[] arr = new int[(campi.Length) + 1];

                for (int i = 0; i < campi.Length; i++)
                {
                    arr[dim] = campi[i].Length;
                    dim++;
                }
                arr[(arr.Length) - 1] = a.Length;

                while (a != null)
                {
                    dim = 0;

                    string[] campi2 = a.Split(';');


                    for (int i = 0; i < campi2.Length; i++)
                    {
                        if (arr[dim] < campi2[i].Length)
                        {
                            arr[dim] = campi2[i].Length;
                        }

                        dim++;
                    }

                    if (arr[(arr.Length) - 1] < a.Length)
                    {
                        arr[(arr.Length) - 1] = a.Length;
                    }

                    a = sw.ReadLine();

                }

                dim = 0;

                listView1.Clear();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != arr.Length - 1)
                    {
                        listView1.Items.Add("Lunghezza campo " + dim.ToString() + ": " + arr[i]);
                    }
                    else
                    {
                        listView1.Items.Add("Lunghezza record " + dim.ToString() + ": " + (arr[arr.Length - 1] + 1));
                    }
                    dim++;
                }

                lung = arr[arr.Length - 1];
            }

            return lung;
        }

        public void Lungfissa(int lung)
        {
            if (lung == 0)
            {
                listView1.Clear();
                listView1.Items.Add("Calcolare prima lunghezza del record più lungo che compone il file");
            }
            else
            {

                int[] cont = new int[1000];

                string[] cont2 = new string[1000];

                int dim = 0;

                using (StreamReader sw = new StreamReader(path))
                {
                    string a;

                    a = sw.ReadLine();

                    while (a != null)
                    {
                        int b = a.Length;

                        cont[dim] = lung - b;

                        cont2[dim] = a;

                        dim++;

                        a = sw.ReadLine();
                    }

                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    dim = 0;

                    while (cont2[dim] != null)
                    {

                        string a = null;

                        for (int j = 0; j < cont[dim]; j++)
                        {
                            a = a + " ";
                        }

                        sw.WriteLine(cont2[dim] + a);

                        dim++;
                    }
                }
            }
        }

        public void Aggrecord()
        {
            bool[] a = new bool[1000];

            string[] p = new string[1000];

            int dim = 0;

            using(StreamReader sw = new StreamReader(path))
            {
                string b = sw.ReadLine();

                while (b != null)
                {
                    a[dim] = true;

                    p[dim] = b;

                    b = sw.ReadLine();

                    dim++;
                }

                if(b == null)
                {
                    a[dim] = false;
                }

            }

            using(StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                while (dim<1000)
                {                    

                    if (a[dim] == false)
                    {
                        sw.WriteLine(textBox1.Text + ";" + textBox9.Text + ";" + textBox10.Text + ";" + textBox11.Text + ";" + textBox12.Text + ";" + textBox18.Text + ";" + textBox13.Text + ";" + textBox15.Text + ";" + textBox14.Text + ";" + textBox17.Text + ";" + textBox16.Text);
                        break;
                    }

                    sw.WriteLine(p[dim]);

                    dim++;
                }
            }
        }

        public void Viscampi()
        {
            string a = textBox2.Text;
            string b = textBox3.Text;
            string c = textBox4.Text;

            int a1=0;
            int b1=0;
            int c1 = 0;

            bool a2 = false;
            bool b2 = false;
            bool c2 = false;

            string[] pa = new string[1000];
            string[] pb = new string[1000];
            string[] pc = new string[1000];

            using(StreamReader sw  = new StreamReader(path)) 
            {
                string d = sw.ReadLine();

                string[] campi = d.Split(';');

                int dim = 0;

                for(int i = 0; i < campi.Length; i++)
                {
                    if (a == "miovalore")
                    {
                        a1 = 11;
                    }
                    else
                    {
                        if (a == "")
                        {
                            a2 = true;
                        }
                        else
                        {
                            if (campi[dim] == a)
                            {
                                a1 = dim;
                            }
                        }
                    }

                    if (b == "miovalore")
                    {
                        b1 = 11;
                    }
                    else
                    {
                        if (b == "")
                        {
                            b2 = true;
                        }
                        else
                        {
                            if (campi[dim] == b)
                            {
                                b1 = dim;
                            }
                        }
                    }

                    if (c == "miovalore")
                    {
                        c1 = 11;
                    }
                    else
                    {
                        if (c == "")
                        {
                            c2 = true;
                        }
                        else
                        {
                            if (campi[dim] == c)
                            {
                                c1 = dim;
                            }
                        }
                    }

                    dim++;
                }

                listView1.Clear();
                
                while(d != null)
                {                    

                    string[] campi2 = d.Split(';');

                    if(a2 == true)
                    {
                        listView1.Items.Add("Campo 1:");
                    }
                    else
                    {
                        listView1.Items.Add("Campo 1:" + campi2[a1]);
                    }

                    if (b2 == true)
                    {
                        listView1.Items.Add("Campo 2:");
                    }
                    else
                    {
                        listView1.Items.Add("Campo 1:" + campi2[b1]);
                    }

                    if (c2 == true)
                    {
                        listView1.Items.Add("Campo 3:");
                    }
                    else
                    {
                        listView1.Items.Add("Campo 3:" + campi2[c1]);
                    }

                    listView1.Items.Add("");

                    d = sw.ReadLine();
                }

            }

        }

        public void Ricercarec()
        {
            string a = textBox5.Text;

            int cont = 0;

            int dim = 0;

            string[] ele = new string[1000];

            using(StreamReader sw = new StreamReader(path))
            {
                string d = sw.ReadLine();

                string[] campi = d.Split(';');

                dim = 0;

                for (int i = 0; i < campi.Length; i++)
                {
                    if ("miovalore" == a)
                    {
                        cont = 11;
                    }
                    else
                    {
                        if (campi[dim] == a)
                        {
                            cont = dim;
                        }
                    }
                    
                    dim++;
                }

                dim = 0;

                while(d != null)
                {
                    string[] campi2 = d.Split(';');

                    ele[dim] = campi2[cont];

                    d = sw.ReadLine();
                    dim++;
                }
            }

            string b = "";

            int t = 0;

            for(int i  = 0; i < ele.Length; i++)
            {
                if (ele[i+1] != null)
                {
                    if (ele[t].Length >= ele[i+1].Length)
                    {
                        b = ele[t];
                    }
                    else
                    {
                        b = ele[i+1];
                        t = i + 1;
                    }
                }
                else
                {
                    break;
                }
            }

            listView1.Clear();
            listView1.Items.Add("Parola più lunga all'interno del campo " + textBox5.Text + " :");
            listView1.Items.Add(b);
        }

        public void Modifica()
        {
            string a = textBox6.Text;

            string[] ele = new string[1000];

            int dim = 0;

            int control = 0;

            using (StreamReader sw = new StreamReader(path))
            { 
               string b = sw.ReadLine();

               while( b != null) 
               {
                    ele[dim] = b;

                    string[] campi = ele[dim].Split(';');

                    for(int i = 0;i < campi.Length;i++)
                    {
                        if (campi[i] == a)
                        {
                            control = dim;
                        }
                    }
                       
                    dim++;

                    b = sw.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                string r = "";

                while (ele[dim] !=  null)
                {
                    if(dim == control)
                    {
                        string[] campi2 = ele[dim].Split(';');

                        if (textBox1.Text != null)
                        {
                            r = r + textBox1.Text;
                        }
                        else
                        {
                            string[] campi3 = ele[dim].Split(';');
                            r = r + campi3[dim];
                        }

                        if (textBox9.Text != null)
                        {
                            r = r + ";" + textBox9.Text;
                        }
                        else
                        {
                            string[] campi4 = ele[dim].Split(';');
                            r = r + ";" + campi4[dim];
                        }

                        if (textBox10.Text != null)
                        {
                            r = r + ";" + textBox9.Text;
                        }
                        else
                        {
                            string[] campi5 = ele[dim].Split(';');
                            r = r + ";" + campi5[dim];
                        }

                        if (textBox11.Text != null)
                        {                           
                            r = r + ";" + textBox11.Text;
                        }
                        else
                        {
                            string[] campi6 = ele[dim].Split(';');
                            r = r + ";" + campi6[dim];
                        }

                        if (textBox12.Text != null)
                        {
                            r = r + ";" + textBox12.Text;
                        }
                        else
                        {
                            string[] campi7 = ele[dim].Split(';');
                            r = r + ";" + campi7[dim];
                        }

                        if (textBox18.Text != null)
                        {
                            r = r + ";" + textBox18.Text;
                        }
                        else
                        {
                            string[] campi8 = ele[dim].Split(';');
                            r = r + ";" + campi8[dim];
                        }

                        if (textBox13.Text != null)
                        {
                            r = r + ";" + textBox13.Text;
                        }
                        else
                        {
                            string[] campi9 = ele[dim].Split(';');
                            r = r + ";" + campi9[dim];
                        }

                        if (textBox15.Text != null)
                        {
                            r = r + ";" + textBox15.Text;
                        }
                        else
                        {
                            string[] campi10 = ele[dim].Split(';');
                            r = r + ";" + campi10[dim];
                        }

                        if (textBox14.Text != null)
                        {
                            r = r + ";" + textBox14.Text;
                        }
                        else
                        {
                            string[] campi11 = ele[dim].Split(';');
                            r = r + ";" + campi11[dim];
                        }

                        if (textBox17.Text != null)
                        {
                            r = r + ";" + textBox17.Text;
                        }
                        else
                        {
                            string[] campi12 = ele[dim].Split(';');
                            r = r + ";" + ele[dim];
                        }
                        if (textBox16.Text != null)
                        {
                            r = r + ";" + textBox16.Text;
                        }
                        else
                        {
                            string[] campi13 = ele[dim].Split(';');
                            r = r + ";" + ele[dim];
                        }

                        sw.WriteLine(r);
                    }
                    else
                    {
                        sw.WriteLine(ele[dim]);
                    }

                    dim++;
                }
            }
        }

        public void Canclog()
        {
            bool[] a = new bool[1000];

            string[] a2 = new string[1000];

            string c = textBox8.Text;

            int dim = 0;

            using (StreamReader sw = new StreamReader(path))
            {
                string b = sw.ReadLine();

                while(b != null)
                {
                    a2[dim] = b;

                    string[] campi = b.Split(';');

                    if (campi[0] == c)
                    {
                        a[dim] = false;
                    }
                    else
                    {
                        a[dim] = true;
                    }
                    dim++;

                    b = sw.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                dim = 0;

                while (a2[dim] != null)
                {

                    if (a[dim] == true)
                    {
                        sw.WriteLine(a2[dim]);
                    }
                    dim++;
                }
            }
        }

    }
}