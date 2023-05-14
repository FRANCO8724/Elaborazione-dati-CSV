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

namespace Elaborazione_dati_CSV
{
    public partial class Form1 : Form
    {
        //Nella struct dichiaro tutti i campi 
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
            public bool a;
        }

        //Rendo gli elementi richiamabili in ogni parte del codice
        public Elementi[] p;
        public int dim;
        public int lmax;
        public string path = @"Arrigoni.csv";

        public Form1()
        {
            InitializeComponent();

            //Dichiaro dimensioni della struct e di dim
            p = new Elementi[100];
            dim = 0;

            //Riempio la struct con gli elementi presenti nel file suddividendo gli elementi del fil nei rispettivi array della struct
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
            //Funzione che mi permette di aggiungere alla fine di ogni record un campo contenente un numero casuale tra 10 e 20
            Aggiunta(p);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Funzione che mi permette di ricavare la quantità di campi contenuti in ogni record
            Numcampi(p);
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            //Funzione che restituisce il il record con lunghezza massima e il campo con lunghezza massima per tutte le categorie di campo presenti nel file
            lmax = Lunghezzamax(p);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Funzione che mi permette data la lunghezza massima di aggiungere ad ogni record degli spazi vuoti fino ad arrivare alla lunghezza massima in modo da avere tutti i record di lunghezza uguale
            Ridimensione(lmax, p);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Funzione che mi permette di aggiungere un nuovo record
            Aggiuntarec(p);

            //Finita la funzione ripulisco la box 1
            textBox1.Text = "";
            textBox1.Focus();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Funzione che mi permette di mostrare 3 campi scelti dall'utente di ogni singolo record
            Visualcampi(p);

            //Finita la funzione ripulisco la box 2,3,4
            textBox2.Text = "";
            textBox2.Focus();
            textBox3.Text = "";
            textBox3.Focus();
            textBox4.Text = "";
            textBox4.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Permette di ricercare un array attraverso un campo chiave
            Ricerca(p);

            //Finita la funzione ripulisco la box 5
            textBox5.Text = "";
            textBox5.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Richiamo la funzione
            Modifica(p);

            //Finita la funzione ripulisco la box 6,7
            textBox6.Text = "";
            textBox6.Focus();
            textBox7.Text = "";
            textBox7.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Cancelalog(p);

            //Finita la funzione ripulisco la box 8
            textBox8.Text = "";
            textBox8.Focus();
        }

        //Funzioni di servizio

        public void Riemp(Elementi[] p)
        {
            //Leggo i dati del file
            using (StreamReader sw = new StreamReader(path))
            {

                //Salvo il primo record in una stringa
                string a = sw.ReadLine();

                //Imposto dim a 0
                dim = 0;

                //Ripetere tutto quello che c'è nel while finchè a ovvero una riga del file risulti vuota
                while (a != null)
                {
                    //Creo un array di stringa temporaneo dove prendo tutti i dati di a ovvero della riga del file, prende un dato e ad ogni punto virgola salva i dati letti nell'array in posizioni diverse
                    string[] campi = a.Split(';');

                    //Salvo gli elementi in modo sequenziale
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
                    p[dim].Casual = "";
                    p[dim].a = true;


                    //Leggo la riga successiva e ripeto il procedimento while fino a una riga vuota
                    a = sw.ReadLine();

                    //Aumento dim di uno per spostarmi di posizione dell'array
                    dim++;
                }

            }//Chiusura file

        }

        //Funzione che ricompone gli elementi della struct della stessa posizione dei rispettivi array in un unica stringa
        public string Str(Elementi[] p, int dim)
        {
            return p[dim].COD_ACQ + ";" + p[dim].ACQUEDOTTO + ";" + p[dim].COMUNE + ";" + p[dim].SIGLA_PROV + ";" + p[dim].CAP + ";" + p[dim].DISTRETTO + ";" + p[dim].COD_PROD + ";" + p[dim].PRODUTTORE + ";" + p[dim].LUOGO_PREL + ";" + p[dim].ETICHETTA + ";" + p[dim].NOTE;
        }

        public void Aggiunta(Elementi[] p)
        {
            //Dichiaro la variabil per i numeri random
            Random num = new Random();

            //Apro il file in scrittura
            using (StreamWriter sw = new StreamWriter(path))
            {
                //Setto le variabili dim e b a 0
                int b = 0;
                dim = 0;

                //Mentre il campo uno è diverso dal valore nullo esegui
                while (p[dim].COD_ACQ != null)
                {
                    //Estraggo un numero casuale tra 10 e 20
                    int a = num.Next(10, 21);

                    //Stampo nella prima riga del file il nome del campo 
                    if (dim == 0)
                    {
                        p[dim].Casual = "miovalore";
                    }
                    else
                    {
                        //Nelle righe successive del file scrivo il numero estratto casualmente
                        p[dim].Casual = a.ToString();
                    }

                    //Richiamo la funzione Str salvando il numero casuale nella struct
                    string d = Str(p, dim) + ";" + p[dim].Casual;

                    //Scrivo la stringa nel file sostituendo quella vecchia
                    sw.WriteLine(d);
                    b++;
                    dim++;

                }

            }
        }

        public void Numcampi(Elementi[] p)
        {
            //Pulisco la listView1
            listView1.Items.Clear();

            //Imposto dimensione a 0
            dim = 0;

            //Ciclo che scorre tutta la struct
            for (int i = 0; i < p.Length; i++)
            {
                int a = 0;
                
                //per ogni array appartenente alla struct i quali hanno impostato la stessa posizione conto quanti di questi non sono vuoti
                if (p[dim].COD_ACQ != null)
                {
                    a++;
                }

                if (p[dim].ACQUEDOTTO != null)
                {
                    a++;
                }

                if (p[dim].COMUNE != null)
                {
                    a++;
                }

                if (p[dim].SIGLA_PROV != null)
                {
                    a++;
                }

                if (p[dim].CAP != null)
                {
                    a++;
                }

                if (p[dim].DISTRETTO != null)
                {
                    a++;
                }

                if (p[dim].PRODUTTORE != null)
                {
                    a++;
                }

                if (p[dim].LUOGO_PREL != null)
                {
                    a++;
                }

                if (p[dim].ETICHETTA != null)
                {
                    a++;
                }

                if (p[dim].NOTE != null)
                {
                    a++;
                }

                if (p[dim].Casual != null)
                {
                    a++;
                }

                //Scrivo il numero di campi totali di un record
                listView1.Items.Add("Campi riga: " + a);
                dim++;

            }
        }

        public int Lunghezzamax(Elementi[] p)
        {
            //Apro il file in lettura
            using (StreamReader sr = new StreamReader(path))
            {
                //Imposto dim a 0
                dim = 0;

                //Leggo la prima riga e la salvo nella variabile a
                string a = sr.ReadLine();

                //Salvo i primi elementi degli array appartenenti alla struct in stringhe
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

                //Mentre la riga del file non è vuota esegui il while
                while (a != null)
                {
                    //Leggo la riga e salvo i dati nella variabile b
                    string b = sr.ReadLine();

                    //Mentre la riga del file non è vuota esegui l' if
                    if (b != null)
                    {
                        //Se la lunghezza della riga b è maggiore di a, sostituisco a con il valore di b
                        if (a.Length < b.Length)
                        {
                            a = b;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].COD_ACQ).Length < (p[dim + 1].COD_ACQ).Length)
                        {
                            q = p[dim + 1].COD_ACQ;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].ACQUEDOTTO).Length < (p[dim + 1].ACQUEDOTTO).Length)
                        {
                            w = p[dim + 1].ACQUEDOTTO;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].COMUNE).Length < (p[dim + 1].COMUNE).Length)
                        {
                            e = p[dim + 1].COMUNE;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].SIGLA_PROV).Length < (p[dim + 1].SIGLA_PROV).Length)
                        {
                            r = p[dim + 1].SIGLA_PROV;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].CAP).Length < (p[dim + 1].CAP).Length)
                        {
                            t = p[dim + 1].CAP;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].DISTRETTO).Length < (p[dim + 1].DISTRETTO).Length)
                        {
                            y = p[dim + 1].DISTRETTO;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].PRODUTTORE).Length < (p[dim + 1].PRODUTTORE).Length)
                        {
                            u = p[dim + 1].PRODUTTORE;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].LUOGO_PREL).Length < (p[dim + 1].LUOGO_PREL).Length)
                        {
                            i = p[dim + 1].LUOGO_PREL;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].ETICHETTA).Length < (p[dim + 1].ETICHETTA).Length)
                        {
                            o = p[dim + 1].ETICHETTA;
                        }

                        //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                        if ((p[dim].NOTE).Length < (p[dim + 1].NOTE).Length)
                        {
                            l = p[dim + 1].NOTE;
                        }

                        //In caso l'utente non abbia aggiunto il campo di mio valore con i numeri casuali da 10 a 20 non aggiungo nessun carattere
                        if (p[dim].Casual == null)
                        {
                            k = "";
                        }
                        else
                        {

                            //Se la lunghezza dell'array primo è minore di quella del secondo il valore della stringa verra sostituito con il valore dell'array più lungo in caso contrario la stringa rimane invariata
                            if ((p[dim].Casual).Length < (p[dim + 1].Casual).Length)
                            {
                                k = p[dim + 1].Casual;
                            }
                        }

                    }
                    else
                    {
                        //In caso b ovvero la riga del file è vuoto termino
                        break;
                    }



                }

                //Pulisco la listView1
                listView1.Items.Clear();

                //Scrivo nella lsitView1 il record più lungo nel file e anche la lunghezza massima dei campi del file
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

                //Restituisco la lunghezza massima del record in modo da utilizzarla nella funzione ridimensione
                return a.Length;

            }//Chiusura file
        }

        public void Ridimensione(int lung, Elementi[] p)
        {
            //Imposto dim a 0
            dim = 0;

            //Array di supporto
            string[] supp = new string[100];

            //Apro il file in lettura
            using (StreamReader sw = new StreamReader(path))
            {
                //Salvo la prima riga nella variabile a 
                string a = sw.ReadLine();

                //Se a ovvero la riga non è vuota ripeto il while
                while (a != null)
                {
                    //Se il primo campo non è nullo allora eseguo l'if
                    if (p[dim].COD_ACQ != null)
                    {
                        //Dichiaro la lunghezza di differenza tra un record e quello di lunghezza massima
                        int d = lung - a.Length;

                        string f = "";

                        //Costruisco una stringa di spazi vuoti di lunghezza d ovvero di quanto differisce il record con quello di lunghezza massima
                        for (int i = 0; i < d; i++)
                        {
                            f = f + " ";
                        }

                        //Salvo nell array di supporto la riga del file + la stringa di spazi vuoti
                        supp[dim] = a + f;

                    }

                    //Proseguo alla linea successiva del file
                    a = sw.ReadLine();
                    dim++;
                }

            }//Chiusura file

            using (StreamWriter sw2 = new StreamWriter(path))
            {
                //Rimposto dim a 0
                dim = 0;

                //Riscrivo l'intero file
                sw2.WriteLine(supp[dim]);

                while (supp[dim] != null)
                {
                    dim++;

                    sw2.WriteLine(supp[dim]);
                }
            }//Chiusura file

        }

        

        public void Aggiuntarec(Elementi[] p)
        {
            //Variabile di supporto impostata a 0
            int r = 0;

            //Apro il file in lettura
            using (StreamReader sw = new StreamReader(path))
            {
                //Salvo la stringa inserita dall'utente nella stringa b
                string b = textBox1.Text;

                //Creo un array di stringa temporaneo dove prendo tutti i dati di b ovvero del record inserito dall'utente, prende un dato e ad ogni punto virgola salva i dati letti nell'array in posizioni diverse
                string[] campi = b.Split(';');

                //Imposto dim a 0
                dim = 0;

                //Variabile di supporto impostata a 0
                int C = 0;

                if (textBox1.Text != "")
                {
                    //Eseguo il ciclo while finchè C è diverso da 0
                    while (C == 0)
                    {
                        if (dim != 100)
                        {
                            //Leggo la riga del file
                            string a = sw.ReadLine();

                            //Se la riga del file non  è vuota esegui if
                            if (a != null)
                            {
                                //Aumenta dim di uno
                                dim++;
                            }
                            else
                            {
                                //In caso la riga del file sia vuota salvo gli elementi negli array della struct nelle rispettive posizioni
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

                                //Imposto C a 1 per rompere il while;
                                C = 1;
                            }

                        }
                        else
                        {
                            //In caso dim arrivi a 100 ovvero grandezza massima del file imposto r a 1 e rompo il while
                            r = 1;
                            break;
                        }

                    }
                }
                else
                {
                    listView1.Clear();
                    listView1.Items.Add("Inserire un valore valido");
                }
            }//Chiusura file

            //Apro il file in scrittura
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                //In caso r sia uguale a 1 ovvero il file ha raggiunto il massimo stampo su listView1 che il file è pieno e quindi non si può aggiungere un ulteriore record
                if (r == 1)
                {
                    listView1.Clear();
                    listView1.Items.Add("Impossibile aggiungere un record il file è pieno");
                }
                else
                {
                    //In caso il file non sia pieno ricompongo gli elementi degli array della struct impostati nella stessa posizione e gli scrivo nel file
                    sw.WriteLine(Str(p, dim));

                }
                
            }//Chiusura file

        }


        public void Visualcampi(Elementi[]p)
        {
            //Variabili di supporto
            int v = 0;
            int b = 0;
            int c = 0;

            //Apro il file in lettura
            using (StreamReader sw = new StreamReader(path))
            {                
                //Salvo la riga in una stringa
                string s = sw.ReadLine();

                //Creo un array di stringa temporaneo dove prendo tutti i dati di s ovvero della riga del file, prende un dato e ad ogni punto virgola salva i dati letti nell'array in posizioni diverse
                string[] campi = s.Split(';');

                //Ripeto in base alla quantità di campi dei record
                for (int i = 0;i<campi.Length;i++)
                {
                    //In questo modo posso ricavare a che array della struct appartengono i campi inseriti dall'utente
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

            }//Chiusura file

            //Setto dim a 0
            dim = 0;


            //Apro il file in lettura
            using (StreamReader sr = new StreamReader(path))
            {
                 //Leggo la riga del file
                string a = sr.ReadLine();
               
                //Pulisco la listView1
                listView1.Clear();

                //Se la riga del file non è vuota continua ad eseguire il while
                while (a != null)
                {
                    //Creo un array di stringa temporaneo dove prendo tutti i dati di a ovvero della riga del file, prende un dato e ad ogni punto virgola salva i dati letti nell'array in posizioni diverse
                    string[] campi = a.Split(';');

                    //Se l'elemento è nullo lo scrivo
                        if (campi[v] == null)
                        {
                            listView1.Items.Add("Campo 1: ");
                        }
                        else
                        {

                        if (textBox2.Text != "miovalore")
                        {
                            //Stampo sulla listView il campo
                            if (textBox2.Text != "")
                            {
                                listView1.Items.Add("Campo 1: " + campi[v]);
                            }
                            else
                            {
                                //altrimenti Se l'utente non ha inserito niente in una delle tre box scrivo semplicemente campo senza elemento
                                listView1.Items.Add("Campo 1: ");
                            }
                        }
                        else
                        {
                            listView1.Items.Add("Campo 1: " + campi[v]);
                        }

                        }

                    //Se l'elemento è nullo lo scrivo
                        if (campi[b] == null)
                        {
                            listView1.Items.Add("Campo 2: ");
                        }
                        else
                        {
                        if (textBox3.Text != "miovalore")
                        {
                            //Stampo sulla listView il campo
                            if (textBox3.Text != "")
                            {

                                listView1.Items.Add("Campo 2: " + campi[b]);

                            }
                            else
                            {
                                //altrimenti Se l'utente non ha inserito niente in una delle tre box scrivo semplicemente campo senza elemento
                                listView1.Items.Add("Campo 2: ");
                            }
                        }
                        else
                        {
                            listView1.Items.Add("Campo 2: " + campi[b]);
                        }
                        }


                    //Se l'elemento è nullo lo scrivo
                    if (campi[c] == null)
                    {
                        listView1.Items.Add("Campo 3: ");
                    }
                    else
                    {
                        if (textBox4.Text != "miovalore")
                        {
                            //Stampo sulla listView il campo
                            if (textBox4.Text != "")
                            {

                                listView1.Items.Add("Campo 3: " + campi[c]);

                            }
                            else
                            {
                                //altrimenti Se l'utente non ha inserito niente in una delle tre box scrivo semplicemente campo senza elemento
                                listView1.Items.Add("Campo 3: ");
                            }
                        }
                        else
                        {
                            listView1.Items.Add("Campo 3: " + campi[c]);
                        }
                    }
                    

                    //Spazio per dividere i campi di ogni struct sulla listView1
                    listView1.Items.Add("");

                    //Leggo la riga successiva
                    a = sr.ReadLine();
                }

            }//Chiusura file
            
        }

        public void Ricerca(Elementi[] p)
        {
            //Imposto dim a 0
            dim = 0;

            //Variabile di supporto impostata a 0
            int v = 0;

            int a = 0;

            //Apro il file in lettura
            using (StreamReader sw = new StreamReader(path))
            {
                    //Leggo la riga del file
                    string s = sw.ReadLine();
                if (textBox5.Text != "")
                {
                    while (s != null)
                    {
                        //Creo un array di stringa temporaneo dove prendo tutti i dati di s ovvero della riga del file, prende un dato e ad ogni punto virgola salva i dati letti nell'array in posizioni diverse
                        string[] campi = s.Split(';');

                        //Funzione che mi permette di ricavare la posizione del campo appartenente al record che l'utente vuole ricavare
                        for (int i = 0; i < campi.Length; i++)
                        {

                            if (campi[i] == textBox5.Text)
                            {
                                a = 1;
                                break;
                            }

                        }

                        if (a == 1)
                        {
                            break;
                        }

                        dim++;

                        s = sw.ReadLine();
                    }

                    listView1.Clear();
                    listView1.Items.Add(Str(p, dim));
                }
                else
                {
                    listView1.Clear();
                    listView1.Items.Add("Dato inserito non valido");
                }

                

            }//Chiusura file

        }

        public void Modifica(Elementi[] p)
        {
            //Salvo il datio inserito dall'utente contenente il record da modificare
            string a = textBox6.Text;

            if (a != "")
            {
                //Imposto dim a 0
                dim = 0;

                //Apro il file in lettura
                using (StreamReader sw = new StreamReader(path))
                {
                    //Leggo la riga
                    string b = sw.ReadLine();

                    //Se la riga non è vuota eseguo continuamente il while
                    while (b != null)
                    {
                        //Creo un array di stringa temporaneo dove prendo tutti i dati di b ovvero della riga del file, prende un dato e ad ogni punto virgola salva i dati letti nell'array in posizioni diverse
                        string[] campi2 = b.Split(';');

                        //Se il valore dell'elemento del campo campo in posizione 0 è uguale ad a rompi il while
                        if (campi2[0] == a)
                        {
                            break;
                        }
                        //In caso contrario aumenta dim di 1
                        else
                        {
                            dim++;
                        }

                        //Leggi riga successiva
                        b = sw.ReadLine();
                    }

                    //Creo un array di stringa temporaneo dove prendo tutti i dati di b ovvero del record inserito dall'utente, prende un dato e ad ogni punto virgola salva i dati letti nell'array in posizioni diverse
                    string[] campi = (textBox7.Text).Split(';');

                    //Salvo gli elementi nelle rispettive posizioni degli array appartenente alla struct
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

                }//Chiusura file

                //Apertura file in scrittura
                using (StreamWriter sw2 = new StreamWriter(path))
                {
                    //Imposto dim a 0
                    dim = 0;

                    //Ripeto per tutta la lunghezza della struct
                    for (int y = 0; y < p.Length; y++)
                    {
                        //Ricompongo il record
                        string t = Str(p, dim);

                        //Se il record non contiene campi vuoti stampa sul file la stringa t e aumenta dim di uno
                        if (t != ";;;;;;;;;;")
                        {
                            sw2.WriteLine(t);

                            dim++;
                        }
                        //Altrimenti rompi il for
                        else
                        {
                            break;
                        }
                    }
                }//Chiusura file
            }
            else
            {
                listView1.Clear();
                listView1.Items.Add("Inserire un dato valido");
            }
        }

        public void Cancelalog(Elementi[] p)
        {
            //Imposto dim a 0
            dim = 0;

            if (textBox8.Text != "")
            {
                //Ciclo che scorre tutta la struct e in caso il COD_ACQ corrisponde al dato che l'utente vuole eliminare cambio l'elemento dell'array della struct da true a false e aumento dim
                for (int y = 0; y < p.Length; y++)
                {

                    if (p[y].COD_ACQ == textBox8.Text)
                    {
                        p[dim].a = false;
                    }

                    dim++;

                }

                //Imposto dim a 0
                dim = 0;

                //Variabile di supporto
                int e = 0;

                using (StreamWriter sw = new StreamWriter(path))
                {
                    //Mentre e = 0 ricomponi il record della struct in caso non sia vuota e in caso l'utlimo array dell astruct contenga il valore true scrivi record su file altrimenti se il record è vuoto rompi while
                    while (e == 0)
                    {
                        string h = Str(p, dim);

                        if (h != ";;;;;;;;;;")
                        {
                            if (p[dim].a == true)
                            {
                                sw.WriteLine(h);
                            }
                        }
                        else
                        {
                            break;
                        }
                        //Aumento dim
                        dim++;

                    }
                }
            }
            else
            {
                listView1.Clear();
                listView1.Items.Add("Inserire un dato valido");
            }
        }
        
    }
}