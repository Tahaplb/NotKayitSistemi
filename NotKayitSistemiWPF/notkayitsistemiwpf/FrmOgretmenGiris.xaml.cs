using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace notkayitsistemiwpf
{
    /// <summary>
    /// Interaction logic for FrmOgretmenGiris.xaml
    /// </summary>
    public partial class FrmOgretmenGiris : Window
    {
        public FrmOgretmenGiris()
        {
            InitializeComponent();
            Listele();
        }
        DbNotKayıtEntities db = new DbNotKayıtEntities();

        private void ogrKaydet_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Ders t = new Tbl_Ders();
            t.OGRNUMARA = txtOgrNumara.Text;
            t.OGRAD = txtOgrAd.Text;
            t.OGRSOYAD = txtOgrSoyad.Text;            
            db.Tbl_Ders.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Sisteme Eklendi.");
            Listele();
            Temizle();
        }

        void Listele()
        {
            int gecenSayisi, kalanSayisi = 0;
            dgGoster.ItemsSource = db.Tbl_Ders.ToList();                    
            lblGecenSayisi.Content = db.Tbl_Ders.Count(x => x.DURUM == true).ToString();
            lblKalanSayisi.Content = db.Tbl_Ders.Count(x => x.DURUM == false).ToString();
            gecenSayisi = Convert.ToInt32(lblGecenSayisi.Content);
            kalanSayisi = Convert.ToInt32(lblKalanSayisi.Content);
            var deger = db.Tbl_Ders.Sum(y => y.ORTALAMA / (gecenSayisi + kalanSayisi));
            lblAgno.Content = decimal.Round(deger.Value, 2);
        }

        void Temizle()
        {
            txtOgrAd.Text = "";
            txtOgrNumara.Text = "";
            txtOgrSoyad.Text = "";
            txtSinav1.Text = "";
            txtSinav2.Text = "";
            txtSinav3.Text = "";
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            decimal ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDecimal(txtSinav1.Text);
            s2 = Convert.ToDecimal(txtSinav2.Text);
            s3 = Convert.ToDecimal(txtSinav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblOrtalama.Content = decimal.Round(ortalama,2).ToString();

            if (ortalama >= 50) durum = "true";
            else durum = "false";

            int x = Convert.ToInt32(txtOgrID.Text);
            var ogr = db.Tbl_Ders.Find(x);
            //ogr.OGRAD = txtOgrAd.Text;
            //ogr.OGRSOYAD = txtOgrSoyad.Text;
            //ogr.OGRNUMARA = txtOgrNumara.Text;
            ogr.OGRS1 = byte.Parse(txtSinav1.Text);
            ogr.OGRS2 = byte.Parse(txtSinav2.Text);
            ogr.OGRS3 = byte.Parse(txtSinav3.Text);
            ogr.DURUM = bool.Parse(durum);
            ogr.ORTALAMA = decimal.Parse(ortalama.ToString());
            db.SaveChanges();
            MessageBox.Show("Öğrenci güncellendi.");
            Listele();
            Temizle();

        }

        private void dgGoster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = (DataGrid)sender;
            DataRowView dataRow = data.SelectedItems as DataRowView;

            if (dataRow != null)
            {
                txtOgrNumara.Text = dataRow["OGRNUMARA"].ToString();
                txtOgrAd.Text = dataRow["URUNAD"].ToString();
                txtOgrSoyad.Text = dataRow["OGRSOYAD"].ToString();
                txtSinav1.Text = dataRow["OGRS1"].ToString();
                txtSinav2.Text = dataRow["OGRS2"].ToString();
                txtSinav3.Text = dataRow["OGRS3"].ToString();                
            }
        }

        private void ogrSil_Click(object sender, RoutedEventArgs e)
        {
            int x = Convert.ToInt32(txtOgrID.Text);
            var ogr = db.Tbl_Ders.Find(x);
            db.Tbl_Ders.Remove(ogr);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Silindi.");
            Listele();
            Temizle();
        }
    }
}
