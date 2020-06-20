using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserControl1 wykres = new UserControl1();
            this.Controls.Add(wykres);
            wykres.DataStartu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            wykres.DataKonca = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            wykres.SzerokoscTytulu = 200;
            wykres.PrzedzialRysowania();

            //naglowek
            ZadanieNaglowek zadNag = new ZadanieNaglowek();
            zadNag.Wiersz = 1;
            zadNag.Tytul = "Operacja A";
            zadNag.kolorTla = Color.Lime;
            zadNag.Dymek = "dupa";
            wykres.DodajZadanieNaglowek(zadNag);

            //dodaj zadanie
            Zadanie op = new Zadanie();
            op.Wiersz = 1;
            op.NazwaZadania = "zdac semestrXD";
            op.DataStartu = new DateTime(2020, 06, 22);
            op.DataKonca = new DateTime(2020, 06, 28);
            op.kolorTla = Color.Green;
            op.kolorPplanu = Color.White;
            op.Dymek = "dupatescik123dupa";
            wykres.DodajZadanie(op);

            Zadanie op1 = new Zadanie();
            op1.Wiersz = 1;
            op1.NazwaZadania = "zdac semestrXD";
            op1.DataStartu = new DateTime(2020, 06, 28);
            op1.DataKonca = new DateTime(2020, 06, 30);
            op1.kolorTla = Color.Orange;
            op1.kolorPplanu = Color.White;
            op1.Dymek = "dupatescik123dupa";
            wykres.DodajZadanie(op1);
        }
        
        
    }
}
