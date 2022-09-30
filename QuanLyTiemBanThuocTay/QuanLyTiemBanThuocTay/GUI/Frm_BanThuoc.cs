using QuanLyTiemBanThuocTay.BUS;
using QuanLyTiemBanThuocTay.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemBanThuocTay.GUI
{
    public partial class Frm_BanThuoc : Form
    {
        public Frm_BanThuoc()
        {
            InitializeComponent();
            DefaultImage = ImgHinhAnh.Image;//ảnh mặc định
        }
        public static string soHD = "";
        public static string luuTienKhach = "";
        public static string luuTienDu = "";
        BUS_BanThuoc dt = new BUS_BanThuoc();
        String DuongDanFile = "";//đường dẫn file
        Image DefaultImage;// ảnh mặc định khi chạy code
        Byte[] ImageByteArray;// mã hóa ảnh thành mảng băm
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_BanThuoc_Load(object sender, EventArgs e)
        {
           
            if (dt.KTKetNoi() == false)//kết nối thất bại sai tên server hoặc pass
            {
                MessageBox.Show("Kết nối thất Bại, Kiểm tra lại tên server và password (Liên hệ Bảo đẹp trai để giải quyết)");
                this.Close();
            }
            else
            {
                //load cbb loại hóa đơn bán
                cbb_chonloaiban.DataSource = dt.getcbbLoaiHDBan();
                cbb_chonloaiban.DisplayMember = "tenLHD";//hiển thị
                cbb_chonloaiban.ValueMember = "maLHD";//giá trị

                //load cbb loại thuốc
                cbb_loaiThuoc.DataSource = dt.getcbbLoaiThuoc();
                cbb_loaiThuoc.DisplayMember = "tenLoai";//hiển thị
                cbb_loaiThuoc.ValueMember = "maLoai";//giá trị

                //load cbb nhà cung cấp
                cbb_nhaCungCap.DataSource = dt.getcbbNCC();
                cbb_nhaCungCap.DisplayMember = "tenNCC";//hiển thị
                cbb_nhaCungCap.ValueMember = "maNCC";//giá trị

                //load danh sách thuốc
                dtgiview_Thuoc.DataSource = dt.getDSThuoc();

                //vô hiệu hóa btn
                btn_inhd.Enabled = txt_khachthanhtoan.Enabled = txt_mathuoc.Enabled = txt_donGia.Enabled = btn_layThuoc.Enabled = btn_thanhtoan.Enabled = btn_browse.Enabled = false;
                //giá trị hiển thị mạc định
                txt_donGia.Text = txt_khachthanhtoan.Text = txt_soLuong.Text = "0";
                //ẩn btn
                lb_luuanh.Visible = btn_browse.Visible = ImgHinhAnh.Visible = false;
            }

        }

        private void cbb_chonloaiban_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //chọn loại hd
        private void cbb_chonloaiban_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbb_chonloaiban.SelectedValue.ToString() == "BTD")
            {
                //ẩn btn
                lb_luuanh.Visible = btn_browse.Visible = ImgHinhAnh.Visible = false;
            }
            else
            {
                //hiện
                lb_luuanh.Visible = btn_browse.Visible = ImgHinhAnh.Visible = true;
            }
        }

        private void btn_KiemtraKhach_Click(object sender, EventArgs e)
        {
            
            if (dt.KTKhachHang(txt_kiemtrakhach.Text) == false)//khách không tồn tại
            {
                MessageBox.Show("Không tìm thấy", "Thông Báo");
                return;
            }
            else
            {
                //vô hiệu hóa 
                btn_KiemtraKhach.Enabled = txt_kiemtrakhach.Enabled = false;
                // hiển thị btn
                btn_browse.Enabled = btn_layThuoc.Enabled = btn_thanhtoan.Enabled = txt_khachthanhtoan.Enabled = true;
                //làm mới khách
                dt.lammoiKhach();
                //hiển thị khách
                dtgriview_khach.DataSource = dt.getTTKhach(txt_kiemtrakhach.Text);
                MessageBox.Show("Tìm Thấy", "Thông Báo");
                return;
            }


        }

        private void dtgiview_Thuoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgiview_Thuoc.CurrentRow != null)
            {
                txt_mathuoc.Text = dtgiview_Thuoc.CurrentRow.Cells[0].Value.ToString();
                txt_tenThuoc.Text = dtgiview_Thuoc.CurrentRow.Cells[1].Value.ToString();
                cbb_loaiThuoc.SelectedValue = dtgiview_Thuoc.CurrentRow.Cells[2].Value.ToString().Trim();
                cbb_nhaCungCap.SelectedValue = dtgiview_Thuoc.CurrentRow.Cells[3].Value.ToString().Trim();
                txt_donvi.Text = dtgiview_Thuoc.CurrentRow.Cells[7].Value.ToString();
                txt_donGia.Text = dtgiview_Thuoc.CurrentRow.Cells[8].Value.ToString();

            }
        }

        //tìm kiếm
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            //làm mới tìm kiếm
            dt.lammoiTimKiemThuoc();
            //tìm kiếm
            dtgiview_Thuoc.DataSource = dt.loadTimKiemThuoc(txt_timKiem.Text);
        }
        //lấy thuốc
        private void btn_layThuoc_Click(object sender, EventArgs e)
        {
            //kiem tra so luong
            if (int.Parse(txt_soLuong.Text) > int.Parse(dtgiview_Thuoc.CurrentRow.Cells[6].Value.ToString()))
            {
                MessageBox.Show("Số lượng thuốc không dap ung", "Thông báo");
                return;
            }
            //kiểm tra thuốc hết hạn sử dụng
            if (dt.KTThuocHetHan(txt_mathuoc.Text) == false)//hết hạn
            {
                MessageBox.Show("Thuốc hết hạn sử dụng", "Thông báo");
                return;
            }
            //kiểm tra rỗng
            if (dt.KTrong(txt_mathuoc.Text, int.Parse(txt_soLuong.Text)) == false)//rỗng
            {
                return;
            }
            //lấy mã của khách hàng
            string laymaKH = dtgriview_khach.CurrentRow.Cells[0].Value.ToString();
            //chưa có hóa đơn và là bán theo toa
            if (lb_sohoadon.Text == "0" && cbb_chonloaiban.SelectedValue.ToString() == "BTT")
            {
                //kiểm tra chọn ảnh
                if (DuongDanFile == "")
                {
                    MessageBox.Show("Bạn Chưa chọn Ảnh", "Thông Báo");
                    return;
                }
                else
                {
                    Image temp = new Bitmap(DuongDanFile);// ánh xạ đường dẫn ảnh
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);//Lưu ảnh
                    ImageByteArray = strm.ToArray();// mã hóa ảnh thành mãng băm
                }
            }
            //tạo DTO
            DTO_BanThuoc hd = new DTO_BanThuoc(int.Parse(lb_sohoadon.Text), "", "NV001", laymaKH, double.Parse("0"), cbb_chonloaiban.SelectedValue.ToString(), ImageByteArray, txt_mathuoc.Text, int.Parse(txt_soLuong.Text), double.Parse(txt_donGia.Text));

            //lấy thuốc
            if (dt.LayThuoc(hd))//thành  công đặt tour này thêm vào ct hóa đơn
            {
                txt_soLuong.Text = "0";
                //cập nhậ số hóa đơn
                lb_sohoadon.Text = dt.CapNhapSoHD().ToString();
                //vô hiện hóa btn
                cbb_chonloaiban.Enabled = false;
                //hiện btn
                btn_inhd.Enabled = true;
                //ẩn btn
                lb_luuanh.Visible = btn_browse.Visible = ImgHinhAnh.Visible = false;

                //làm mới bảng ct hóa đơn
                dt.lammoiCTHD();
                //hiển thị bảng chi tiết hóa đơn
                dt_griviewHoaDon.DataSource = dt.loadDSChiTietHD(int.Parse(lb_sohoadon.Text));

                //load lại bảng thuốc
                dtgiview_Thuoc.DataSource = dt.getDSThuoc();

                //cập nhật thành tiền của hóa đơn lên lable
                //lb_Tongtienthuoc.Text = dt.ThanhTien(int.Parse(lb_sohoadon.Text)).ToString();
                if (dt_griviewHoaDon.CurrentRow != null)
                {
                    lb_Tongtienthuoc.Text = dt_griviewHoaDon.CurrentRow.Cells[5].Value.ToString();
                }

                MessageBox.Show("Thành công", "Thông Báo");
                return;
            }
            else//thất bại
            {
                MessageBox.Show("Thành công", "Thông Báo");
                return;
            }


        }
        //không cho nhập chữ txt số lượng
        private void txt_soLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')//không phải là số và không nhập dấu trừ
            {
                e.Handled = true;
            }
        }
        //không cho nhập chữ txt tìm kiếm khách
        private void txt_kiemtrakhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')//không phải là số và không nhập dấu trừ
            {
                e.Handled = true;
            }
        }
        //không cho nhập chữ txt khách thanh toán
        private void txt_khachthanhtoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')//không phải là số và không nhập dấu trừ
            {
                e.Handled = true;
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            //mở cửa sổ chọn ảnh
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg"; //chọn các file có duôi là png và jpg
            if (ofd.ShowDialog() == DialogResult.OK)//nếu chọn oke
            {
                DuongDanFile = ofd.FileName;//đường dẫn ảnh bằng đường dẫn đã chọn
                ImgHinhAnh.Image = new Bitmap(DuongDanFile);// ảnh mặc định dc thay bằng đường dẫn ảnh dòng trên
            }
        }
        //tính tiền thừa của khách
        private void txt_khachthanhtoan_Leave(object sender, EventArgs e)
        {
            //leble=tieen du
            lb_tienthua.Text = dt.tinhTienDu(double.Parse(lb_Tongtienthuoc.Text), double.Parse(txt_khachthanhtoan.Text)).ToString();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if(int.Parse(lb_tienthua.Text)<0)//kiem tra tien thua cua khach
            {
                MessageBox.Show("Số Tiền Còn Thiếu là " + Math.Abs(int.Parse(lb_tienthua.Text)).ToString(),"Thiếu Tiền Kìa bro");
                return;
            }
            if (txt_khachthanhtoan.Text == "0")
            {
                MessageBox.Show("Chua Nhap Tien", "Thong Bao");
                return;
            }
            //+Hiển thị thông báo xác nhận
            if (MessageBox.Show("Bạn có muốn Thanh Toán Hóa đơn này không", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                MessageBox.Show("Thanh toán Thành công", "Thông Báo");
                //vô hiệu hóa btn
                btn_layThuoc.Enabled = btn_thanhtoan.Enabled = btn_browse.Enabled = btn_inhd.Enabled = false;
                //hiển thị btn
                txt_kiemtrakhach.Enabled = btn_KiemtraKhach.Enabled = cbb_chonloaiban.Enabled = true;

                //giá trị hiển thị mạc định
                Frm_InHDThanhToan.soHD = lb_sohoadon.Text;
                Frm_InHDThanhToan.luuTienKhach = txt_khachthanhtoan.Text;
                Frm_InHDThanhToan.luuTienDu = lb_tienthua.Text;

                Frm_InHDThanhToan hd = new Frm_InHDThanhToan();
                //this.Hide();
                hd.Show();

                txt_donGia.Text = txt_khachthanhtoan.Text = txt_soLuong.Text = lb_sohoadon.Text = lb_tienthua.Text = lb_Tongtienthuoc.Text = "0";
                //ẩn btn
                lb_luuanh.Visible = btn_browse.Visible = ImgHinhAnh.Visible = false;
                //làm mới txt
                txt_kiemtrakhach.Clear();
                txt_kiemtrakhach.Focus();
                ImgHinhAnh.Image = DefaultImage;
                DuongDanFile = "";//reset lai duong dan file

                //làm mới bảng khách
                dt.lammoiKhach();
                dtgriview_khach.DataSource = dt.getTTKhach("");

                //làm mới hóa đơn
                dt.lammoiCTHD();
                dt_griviewHoaDon.DataSource = dt.loadDSChiTietHD(0);

            }
        }

        private void btn_inhd_Click(object sender, EventArgs e)
        {
            Frm_InHD.soHD = lb_sohoadon.Text;
            Frm_InHD hd = new Frm_InHD();
            //this.Hide();
            hd.Show();
        }

        private void dt_griviewHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dt_griviewHoaDon.CurrentRow != null)
            {
                lb_Tongtienthuoc.Text = dt_griviewHoaDon.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void lb_Tongtienthuoc_Click(object sender, EventArgs e)
        {
            //tinh tien thua
        }

        private void txt_khachthanhtoan_TextChanged(object sender, EventArgs e)
        {
            if (txt_khachthanhtoan.Text != "")
            {
                //leble=tieen du
                lb_tienthua.Text = dt.tinhTienDu(double.Parse(lb_Tongtienthuoc.Text), double.Parse(txt_khachthanhtoan.Text)).ToString();
            }
        }
    }
}
