using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;


namespace DEMO
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        DateTime data_startu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        [Category("Okres czasu")]
        [Description("Poczatek zadania")]
        public DateTime DataStartu
        {
            get { return data_startu; }
            set { data_startu = value; }
        }
        DateTime data_konca = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        [Category("Okres czasu")]
        [Description("Koniec zadania")]


        public DateTime DataKonca
        {
            get { return data_konca; }
            set { data_konca = value; }
        }

        string nazwaOperacji = "Nazwa operacji";
        public string NazwaOperacji
        {
            get { return nazwaOperacji; }
            set { nazwaOperacji = value; }

        }
        int szerokoscTytulu = 0;
        public int SzerokoscTytulu
        {
            get { return szerokoscTytulu; }
            set { szerokoscTytulu = value; }
        }

        public int DlugoscTrwania
        {

            get { TimeSpan przedzial = data_konca - data_startu; return przedzial.Days; }
        }
        int przedzialSzerokosc = 30;
        int przedzialWysokosc = 30;
        int przedzialX = 10; //poziomo;
        int przedzialY = 10; //pionowo

        public void PrzedzialRysowania()
        {
            int pozycjaTeraz = przedzialX;
            this.Controls.Clear();
            Label dynamicznaEtykieta = new Label();
            dynamicznaEtykieta.Name = "tytuloperacji";
            dynamicznaEtykieta.Text = nazwaOperacji;
            dynamicznaEtykieta.Location = new Point(przedzialX, przedzialY);
            dynamicznaEtykieta.BackColor = Color.AntiqueWhite;
            dynamicznaEtykieta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dynamicznaEtykieta.TextAlign = ContentAlignment.MiddleCenter;
            dynamicznaEtykieta.Height = przedzialWysokosc;
            if (przedzialSzerokosc != 0)
            {
                dynamicznaEtykieta.Width = przedzialSzerokosc;
            }
            this.Controls.Add(dynamicznaEtykieta);
            pozycjaTeraz += przedzialSzerokosc;
            TimeSpan przedzial = data_konca - data_startu;
            DateTime dataTeraz = new DateTime(data_startu.Year, data_startu.Month, data_startu.Day);
            for (int i = 0; i <= przedzial.Days; i++)
            {

                Label etyk = new Label();
                etyk.Name = String.Format("etyk{0}", i);
                etyk.Text = dataTeraz.Day.ToString();
                etyk.Location = new Point(przedzialX, przedzialY);
                etyk.AutoSize = false;
                etyk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                etyk.TextAlign = ContentAlignment.MiddleCenter;
                if ((dataTeraz.DayOfWeek == DayOfWeek.Saturday) || (dataTeraz.DayOfWeek == DayOfWeek.Sunday))
                {
                    etyk.BackColor = Color.Silver;
                }
                this.Controls.Add(etyk);
                przedzialX += przedzialSzerokosc;
                dataTeraz = dataTeraz.AddDays(1);

            }


        }


        public void DodajZadanie(Zadanie zadanie)
        {
            DateTime data_teraz = data_startu;
            int zadSzerokosc = 0;
            int pozycjaTerazX = przedzialX + przedzialSzerokosc;

            for (int i = 0; i <= DlugoscTrwania; i++)
            {
                if (data_teraz == zadanie.DataStartu)
                {
                    przedzialX += i * przedzialSzerokosc;
                }
                if (data_teraz >= zadanie.DataStartu)
                { zadSzerokosc += przedzialSzerokosc; }
                if (data_teraz == zadanie.DataKonca) { break; }
                data_teraz = data_teraz.AddDays(1);
            }

            Label etyk = new Label();
            etyk.AutoSize = false;
            etyk.Text = zadanie.NazwaZadania;


            etyk.Width = zadSzerokosc;


            etyk.Height = przedzialWysokosc;
            etyk.BorderStyle = zadanie.stylRamki;
            etyk.TextAlign = ContentAlignment.MiddleCenter;
            etyk.Location = new Point(pozycjaTerazX,
                (przedzialWysokosc * zadanie.Wiersz) + przedzialY);
            etyk.BackColor = zadanie.kolorTla;
            etyk.ForeColor = zadanie.kolorPplanu;


            ToolTip dymek = new ToolTip();
            if (dymek != null)
            {
                dymek.SetToolTip(etyk, zadanie.Dymek);
            }

            this.Controls.Add(etyk);
        }
        public void DodajZadanieNaglowek(ZadanieNaglowek zadanieNaglowek)
        {

            Label etyk = new Label();
            etyk.BorderStyle = zadanieNaglowek.stylRamki;
            etyk.TextAlign = ContentAlignment.MiddleCenter;
            etyk.Location = new Point(przedzialX, (przedzialWysokosc * zadanieNaglowek.Wiersz) + przedzialY);
            etyk.BackColor = zadanieNaglowek.kolorTla;
            etyk.ForeColor = zadanieNaglowek.kolorPplanu;

            ToolTip dymek = new ToolTip();
            if (dymek != null)
            {
                dymek.SetToolTip(etyk, zadanieNaglowek.Dymek);
            }
            this.Controls.Add(etyk);

        }


    }
    public class Zadanie
    {
        public Zadanie() { }
        int wiersz = 0;
        public int Wiersz
        {
            get { return wiersz; }
            set { wiersz = value; }

        }

        DateTime data_startu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime DataStartu
        {
            get { return data_startu; }
            set { data_startu = value; }
        }

        DateTime data_konca = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

        public DateTime DataKonca
        {
            get { return data_konca; }
            set { data_konca = value; }
        }

        string nazwaZadania = "Zadanie";
        public string NazwaZadania
        {
            get { return nazwaZadania; }
            set { nazwaZadania = value; }
        }
        Color kolor_tla = Form.DefaultBackColor;
        public Color kolorTla
        {
            get { return kolor_tla; }
            set { kolor_tla = value; }
        }

        Color kolor_pplanu = Form.DefaultForeColor;
        public Color kolorPplanu
        {
            get { return kolor_pplanu; }
            set { kolor_pplanu = value; }
        }

        BorderStyle styl_ramki = BorderStyle.None;
        public BorderStyle stylRamki
        {
            get { return styl_ramki; }
            set { styl_ramki = value; }
        }

        public int DlugoscTrwania
        {
            get { TimeSpan przedzial = data_konca - data_startu; return przedzial.Days; }
        }

        String dymek = "";
        public String Dymek
        {
            get { return dymek; }
            set { dymek = value; }
        }

    }
    public class ZadanieNaglowek
    {
        public ZadanieNaglowek() { }


        int wiersz = 0;
        public int Wiersz
        {
            get { return wiersz; }
            set { wiersz = value; }
        }

        string tytul = "Zadanie";
        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }

        Color kolor_tla = Form.DefaultBackColor;
        public Color kolorTla
        {
            get { return kolor_tla; }
            set { kolor_tla = value; }
        }
        Color kolor_pplanu = Form.DefaultForeColor;
        public Color kolorPplanu
        {
            get { return kolor_pplanu; }
            set { kolor_pplanu = value; }
        }
        BorderStyle styl_ramki = BorderStyle.None;
        public BorderStyle stylRamki
        {
            get { return styl_ramki; }
            set { styl_ramki = value; }

        }
        String dymek = "";
        public String Dymek
        {
            get { return dymek; }
            set { dymek = value; }
        }

    }


}


