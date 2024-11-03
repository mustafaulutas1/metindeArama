using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkbox
{
    public partial class Form1 : Form
    {
        public int metinGirisiSayisi = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private bool kontrol(string arancakmetin, bool checkMetin, bool checkSayi, bool checkSembol)
        {
            bool dogrumu = true;
            foreach (char c in arancakmetin)
            {
                if (char.IsLetter(c) && !checkMetin)
                {
                    dogrumu = false;
                    break;
                }
                if (char.IsNumber(c) && !checkSayi)
                {
                    dogrumu = false;
                    break;
                }
                if (!char.IsLetterOrDigit(c) && !checkSembol)
                {
                    dogrumu = false;
                    break;
                }
            }
            return dogrumu;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string anametin = textBox1.Text;//ana metin kutusu
            string aranacakmetin = textBox2.Text;//aranacak kelime kutusu
            bool checkMetin = checkBox1.Checked; //metin kontrol kutusu
            bool checkSayi = checkBox2.Checked; //sayı kontrol kutusu
            bool checkSembol = checkBox3.Checked; //karakter kontrol kutusu
            metinGirisiSayisi += 1;

            if (!kontrol(aranacakmetin, checkMetin, checkSayi, checkSembol))
            {
                MessageBox.Show("Aranacak Tür Seçimi Yanlış!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int anametinUzunluk = anametin.Length;
            int aranacakmetinUzunluk = aranacakmetin.Length;
            bool keywordExists = anametin.Contains(aranacakmetin);
            int ilkIndex = anametin.IndexOf(aranacakmetin);
            int kackere = anametin.Split(new[] { aranacakmetin }, StringSplitOptions.None).Length - 1;

          
            // Analiz sonuçları
            string analizSonuclari = $"Girilen Metin Uzunluğu: {anametinUzunluk}\r\n";
            analizSonuclari += $"Aranacak İfade Uzunluğu: {aranacakmetinUzunluk}\r\n";
            analizSonuclari += $"Aranacak İfade Metin İçinde {(keywordExists ? "Bulundu (İlk Geçen İndex: " + ilkIndex + ")" : "Bulunamadı")}\r\n";
            analizSonuclari += $"Metin İçinde Aranan İfade {kackere} Kez Geçiyor\r\n";

            // Analiz sonuçlarını TextBox'a ekledik
            textBox3.Text += analizSonuclari + Environment.NewLine;

            //listview oluşturduk ve değerleri ekledik
            string[] row = { "Kaçıncı Metin:", "Aranan İfade:", "Kaç Defa Bulundu:", "Metin Uzunluğu:" };
            string[] data = { metinGirisiSayisi.ToString(), aranacakmetin.ToString(), kackere.ToString() ,anametinUzunluk.ToString() };
            listView1.View = View.Details;

            listView1.Items.Add(new ListViewItem(row));
            listView1.Items.Add(new ListViewItem(data));

        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Kaçıncı Metin",150);
            listView1.Columns.Add("Aranan İfade", 150);
            listView1.Columns.Add("Kaç Defa Bulundu", 150);
            listView1.Columns.Add("Metin Uzunluğu", 150);

            
            //notification icon ekleme
            notifyIcon1.BalloonTipTitle = "New Message";
            notifyIcon1.BalloonTipText = "Nesne Yönelimli Programlama Ödev 1";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.ShowBalloonTip(1000);
            notifyIcon1.Visible = false;
           
            
        }
    }
}
