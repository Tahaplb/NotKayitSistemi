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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace notkayitsistemiwpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, RoutedEventArgs e)
        {
            DbNotKayıtEntities db = new DbNotKayıtEntities();
            var sorgu = from x in db.Tbl_Users where x.UserName == txtKullaniciAdi.Text && x.UserPassword == txtKullaniciSifre.Text select x;
            if (sorgu.Any())
            {
                FrmOgretmenGiris fr = new FrmOgretmenGiris();
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
