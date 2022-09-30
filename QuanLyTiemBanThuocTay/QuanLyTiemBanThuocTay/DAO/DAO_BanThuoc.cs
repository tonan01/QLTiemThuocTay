using QuanLyTiemBanThuocTay.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemBanThuocTay.DAO
{
    class DAO_BanThuoc
    {
        //kết nối sql
        SqlConnection con;
        KetNoiSQL dt = new KetNoiSQL();
        //tạo dataset
        DataSet ds_KH = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;
        
        // Open connection ------------------------------------------------------------
        
        public void openConnection()
        {
            // Mở kết nối đến CSDL
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        // Close connection -----------------------------------------------------------
        public void closeConnection()
        {
            // Kiểm tra kết nối và Đóng CSDL
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public DAO_BanThuoc()
        {
        }


        //kiểm tra kết nối thành công
        public bool KTKetNoi()
        {
            try
            {
                con = dt.conDB();
                openConnection();
                closeConnection();
                return true;//thành công
            }
            catch
            {
                return false;//that bai
            }
        }

        //kiểm tra rỗng
        public bool KTRong(string mathuoc,int soluong)
        {
            
            if (mathuoc.Length == 0)//rỗng
            {
                MessageBox.Show("Chưa chọn thuốc", "Thông Báo");
                return false;
            }
            if (soluong.ToString().Length == 0)//rỗng
            {
                MessageBox.Show("Chưa Nhập Số lượng thuốc", "Thông Báo");
                return false;
            }
            if (soluong == 0)//không được bằng không
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Thông Báo");
                return false;
            }
           
            return true;//đã nhập tất cả
        }

        //load combobox loại thuoc
        public DataTable loadcbbLoaiThuoc()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from LOAITHUOC", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "LOAITHUOC");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["LOAITHUOC"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["LOAITHUOC"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_KH.Tables["LOAITHUOC"];
        }
        
        //load combobox nhà cung cấp
        public DataTable loadcbbNCC()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from NCC", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "NCC");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["NCC"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["NCC"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_KH.Tables["NCC"];
        }

        //load combobox loại hóa đơn bán
        public DataTable loadcbbLoaiHDBan()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from LOAIHD", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "LOAIHD");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["LOAIHD"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["LOAIHD"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_KH.Tables["LOAIHD"];
        }

        //load thông tin thuốc
        public DataTable loadDSThuoc()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from THUOC", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "THUOC");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["THUOC"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["THUOC"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_KH.Tables["THUOC"];
        }

        //load tìm kiếm thuốc
        public DataTable loadTimKiemThuoc(string timkiem)
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from THUOC where (maThuoc like '%"+ timkiem + "%') or (tenThuoc like '%"+ timkiem + "%')", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "THUOC_FIND");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["THUOC_FIND"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["THUOC_FIND"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_KH.Tables["THUOC_FIND"];
        }

        //làm mới thuốc
        public void lamMoiTimKiemThuoc()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select * from THUOC", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "THUOC_FIND");
            //xóa dữ liệu cũ
            ds_KH.Tables["THUOC_FIND"].Clear();
        }

        //load thông tin khách hàng
        public DataTable loadTTKhach(string sdt)
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select maKH,tenKH from KHACHHANG where sDT='" + sdt+"'", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "KHACHHANG");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_KH.Tables["KHACHHANG"].Columns[0];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["KHACHHANG"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_KH.Tables["KHACHHANG"];
        }

        //làm mới khách hàng
        public void lamMoiKhachHang()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select maKH,tenKH from KHACHHANG", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "KHACHHANG");
            //xóa dữ liệu cũ
            ds_KH.Tables["KHACHHANG"].Clear();
        }


        //load ds chi tiết hóa đơn
        public DataTable loadDSChiTietHD(int mahd)
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select CT_HOADON.maHD,CT_HOADON.maThuoc,tenThuoc,CT_HOADON.soLuong,CT_HOADON.donGia,thanhTien from CT_HOADON,THUOC,HOADON where CT_HOADON.maThuoc=THUOC.maThuoc and CT_HOADON.maHD=HOADON.maHD and CT_HOADON.maHD='"+mahd+"'", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "CTHD_THUOC");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[2];
            key[0] = ds_KH.Tables["CTHD_THUOC"].Columns[0];//chọn columns 0
            key[1] = ds_KH.Tables["CTHD_THUOC"].Columns[1];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["CTHD_THUOC"].PrimaryKey = key;
            //trả về ds khách hàng
            return ds_KH.Tables["CTHD_THUOC"];
        }

        //làm mới chi tiết hóa đơn
        public void lamMoiCTHD()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select CT_HOADON.maHD,CT_HOADON.maThuoc,tenThuoc,CT_HOADON.soLuong,CT_HOADON.donGia,thanhTien from CT_HOADON,THUOC,HOADON where CT_HOADON.maThuoc=THUOC.maThuoc and CT_HOADON.maHD=HOADON.maHD", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "CTHD_THUOC");
            //xóa dữ liệu cũ
            ds_KH.Tables["CTHD_THUOC"].Clear();
        }

        //KT khách tồn tại 
        public bool KTkhach(string sdt)
        {
            try
            {
                con = dt.conDB();
                openConnection();//mở kết nối
                string sql = "select count(*) from KHACHHANG where sDT='"+sdt+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int k = (int)cmd.ExecuteScalar();//thực thi câu lệnh trả về 1 số
                closeConnection();//đóng kết nối
                if (k > 0)//có tồn tại khách
                {
                    return true;
                }
                else//chưa có khách
                {
                    return false;
                }

            }
            catch
            {
                return false;//thất bại
            }
        }
        //KT Thuốc hết hạn 
        public bool KTThuocHetHan(string mathuoc)
        {
            try
            {
                con = dt.conDB();
                openConnection();//mở kết nối
                string sql = "select count(*) from THUOC where ngayHH>GETDATE() and maThuoc='"+mathuoc+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int k = (int)cmd.ExecuteScalar();//thực thi câu lệnh trả về 1 số
                closeConnection();//đóng kết nối
                if (k > 0)//thuốc còn hạn
                {
                    return true;
                }
                else//thuốc hết hạn
                {
                    return false;
                }

            }
            catch
            {
                return false;//thất bại
            }
        }
        //Cập nhật số hóa dơn 
        public int CapNhatSoHD()
        {
            try
            {
                con = dt.conDB();
                openConnection();//mở kết nối
                string sql = "select max(maHD) from HOADON";
                SqlCommand cmd = new SqlCommand(sql, con);
                int k = (int)cmd.ExecuteScalar();//thực thi câu lệnh trả về 1 số
                closeConnection();//đóng kết nối
                if(k>0)
                {
                    return k;//lấy số hd thành công
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;//thất bại
            }
        }
        //lẤY THUỐC
        public bool LayThuoc(DTO_BanThuoc hd)
        {
            try
            {
                con = dt.conDB();
                openConnection();//mở kết nối
                string sql = "exec LayThuoc '"+hd.MaHD+"','"+hd.NguoiLap+"','"+hd.MaKH+"','"+hd.MaLHD+"','"+hd.HinhAnh+"','"+hd.MaThuoc+"',"+hd.SoLuong+",'"+hd.DonGia+"' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();//thực thi câu lệnh insert update delete
                closeConnection();//đóng kết nối
                return true;//thành công
            }
            catch
            {
                return false;//thất bại
            }
        }


        //Thành tiền hóa đơn
        public double ThanhTien(int mahd)
        {
            try
            {
                con = dt.conDB();
                openConnection();//mở kết nối
                string sql = "select thanhTien from HOADON where maHD='"+mahd+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                double k = (double)cmd.ExecuteScalar();//thực thi câu lệnh trả về 1 số
                closeConnection();//đóng kết nối
                if (k > 0)//thành tiền
                {
                    return k;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }
        //Tính tiền dư của khách
        public double tinhTienDu(double TienThuoc,double TienKhach)
        {
                return TienKhach - TienThuoc;
        }
    }
}
