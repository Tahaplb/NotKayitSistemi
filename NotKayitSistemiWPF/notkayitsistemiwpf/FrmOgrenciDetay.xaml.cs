using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for FrmOgrenciDetay.xaml
    /// </summary>
    public partial class FrmOgrenciDetay : Window
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
            //Listele();
            Loaded += MyWindow_Loaded;
        }
        public string numara;        

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DbNotKayıtEntities db = new DbNotKayıtEntities();
            LblNumara.Content = numara;
            var deger = db.Tbl_Ders.FirstOrDefault(x => x.OGRNUMARA == numara);
            LblAdSoyad.Content = deger.OGRAD + " " + deger.OGRSOYAD;
            LblSınav1.Content = deger.OGRS1;
            LblSınav2.Content = deger.OGRS2;
            LblSınav3.Content = deger.OGRS3;
            LblOrtalama.Content = deger.ORTALAMA;
            LblDurum.Content = deger.DURUM;
        }
    }
}
