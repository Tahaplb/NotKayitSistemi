using System;
using System.Collections.Generic;
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
    /// Interaction logic for FrmOgrenciGiris.xaml
    /// </summary>
    public partial class FrmOgrenciGiris : Window
    {
        public FrmOgrenciGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, RoutedEventArgs e)
        {
            DbNotKayıtEntities db = new DbNotKayıtEntities();
            
            var sorgu = from x in db.Tbl_Ders where x.OGRNUMARA == txtKullaniciAdi.Text select x;
            if (sorgu.Any())
            {
                FrmOgrenciDetay fr = new FrmOgrenciDetay();
                fr.numara = txtKullaniciAdi.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
            }           
        }
    }
}
