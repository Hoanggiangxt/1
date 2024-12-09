using Giang_109.Models;
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

namespace Giang_109
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Tim();
        }

        QlbanHangContext db = new QlbanHangContext();

        private void Tim()
        {
            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSanPhams
                        on sp.MaLoai equals lsp.MaLoai
                        where sp.MaSp == "SP01"
                        select new
                        {
                            msp = sp.MaSp,
                            tensp = sp.TenSp,
                            tenlsp = lsp.TenLoai,
                            dongia = sp.DonGia,
                            soluong = sp.SoLuong,
                            thanhtien = sp.DonGia * sp.SoLuong
                        };
            dgWindow1.ItemsSource = query.ToList();
        }
    }
}
