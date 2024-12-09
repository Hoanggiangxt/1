using Giang_109.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Giang_109
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QlbanHangContext db
        {
            get; set;
        }
        public MainWindow()
        {
            InitializeComponent();
            db = new QlbanHangContext();
            HienthiCbb();
            Hienthi();
        }
        public void Hienthi()
        {

            var query = from sp in db.SanPhams
                        join lsp in db.LoaiSanPhams
                        on sp.MaLoai equals lsp.MaLoai
                        select new
                        {
                            msp = sp.MaSp,
                            tensp = sp.TenSp,
                            tenlsp = lsp.TenLoai,
                            dongia = sp.DonGia,
                            soluong = sp.SoLuong,
                            thanhtien =  sp.DonGia * sp.SoLuong
                        };
            dgDanhsach.ItemsSource = query.ToList();
        }

        private void HienthiCbb()
        {
            var query = from ma in db.LoaiSanPhams
                        select ma.MaLoai;
            cbmaloai.ItemsSource = query.ToList();
        }

        private bool check()
        {
            var queryspnhap = from Spn in db.SanPhams where txtmasp.Text == Spn.MaSp select Spn;
            SanPham spnhap = queryspnhap.FirstOrDefault();
            if (spnhap != null)
            {
                MessageBox.Show("Sản phẩm không tồn tại!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                txtmasp.Focus();
                return false;
            }
            if (txtmasp.Text == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                txtmasp.Focus();
                return false;
            }
            if (txttensp.Text == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                txttensp.Focus();
                return false;
            }
            if (txtdongia.Text == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập đơn giá!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                txtdongia.Focus();
                return false;
            }
            if (txtsoluong.Text == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập số lượng!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                txtsoluong.Focus();
                return false;
            }
            else
            {
                try
                {
                    int sl = int.Parse(txtsoluong.Text);
                    if (sl <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtsoluong.Focus();
                        return false;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Số lượng phải là số nguyên!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtsoluong.Focus();
                    return false;
                }
            }
            return true;
        }
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                SanPham hd = new SanPham();
                hd.MaSp = txtmasp.Text;
                hd.TenSp = txttensp.Text;
                hd.MaLoai = string.Format(cbmaloai.Text);
                hd.SoLuong = int.Parse(txtsoluong.Text);
                hd.DonGia = int.Parse(txtdongia.Text);
                db.SanPhams.Add(hd);
                db.SaveChanges();
                Hienthi();
                Clear();
            }
        }

        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            var querysua = from spsua in db.SanPhams where txtmasp.Text == spsua.MaSp select spsua;
            SanPham sanphamsua = querysua.FirstOrDefault();
            if (sanphamsua == null)
            {
                MessageBox.Show("Mã sản phẩm không tồn tại!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                txtmasp.Focus();
            }
            else
            {
                sanphamsua.TenSp = txttensp.Text;
                sanphamsua.MaLoai = string.Format(cbmaloai.Text);
                sanphamsua.DonGia = int.Parse(txtdongia.Text);
                sanphamsua.SoLuong = int.Parse(txtsoluong.Text);
                db.SaveChanges();
                Clear();
                Hienthi();

            }
        }

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            var queryspxoa = from spx in db.SanPhams where txtmasp.Text == spx.MaSp select spx;
            SanPham sanphamxoa = queryspxoa.FirstOrDefault();
            if (sanphamxoa == null)
            {
                MessageBox.Show("Mã sản phẩm không tồn tại!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    db.SanPhams.Remove(sanphamxoa);
                    db.SaveChanges();
                    Hienthi();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Lỗi!" + x.Message);
                }
            }
            Clear();
        }

        private void btntim_Click(object sender, RoutedEventArgs e)
        {
            Window1 myw = new Window1();
            myw.ShowDialog();
            Clear();
        }
        private void Clear()
        {
            txtmasp.Clear();
            txttensp.Clear();
            cbmaloai.SelectedIndex = 0;
            txtsoluong.Clear();
            txtdongia.Clear();
        }
        private void dgDanhsach_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object obj = dgDanhsach.SelectedItem;
            if (obj != null)
            {
                try
                {
                    Type t = dgDanhsach.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtmasp.Text = p[0].GetValue(dgDanhsach.SelectedItem).ToString();
                    txttensp.Text = p[1].GetValue(dgDanhsach.SelectedItem).ToString();
                    cbmaloai.SelectedValue = p[2].GetValue(dgDanhsach.SelectedItem).ToString();
                    txtdongia.Text = p[3].GetValue(dgDanhsach.SelectedItem).ToString();
                    txtsoluong.Text = p[4].GetValue(dgDanhsach.SelectedItem).ToString();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Lỗi!" + x.Message);
                }
            }
        }

        private void dgDanhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
