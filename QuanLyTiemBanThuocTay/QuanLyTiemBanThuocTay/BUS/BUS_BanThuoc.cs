using QuanLyTiemBanThuocTay.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyTiemBanThuocTay.DTO;

namespace QuanLyTiemBanThuocTay.BUS
{
    class BUS_BanThuoc
    {
        DAO_BanThuoc dt = new DAO_BanThuoc();

        //kiểm tra kết nối db thành đông
        public bool KTKetNoi()
        {
            return dt.KTKetNoi();
        }

        //load combobox loai hóa đơn bán
        public DataTable getcbbLoaiHDBan()
        {
            return dt.loadcbbLoaiHDBan();
        }

        //load combobox loai thuốc
        public DataTable getcbbLoaiThuoc()
        {
            return dt.loadcbbLoaiThuoc();
        }

        //load combobox nhà cung cấp
        public DataTable getcbbNCC()
        {
            return dt.loadcbbNCC();
        }

        //load danh sách thuốc
        public DataTable getDSThuoc()
        {
            return dt.loadDSThuoc();
        }

        //load tìm kiếm thuốc
        public DataTable loadTimKiemThuoc(string timkiem)
        {
            return dt.loadTimKiemThuoc(timkiem);
        }

        //làm mới tìm kiếm thuốc
        public void lammoiTimKiemThuoc()
        {
            dt.lamMoiTimKiemThuoc();
        }

        //load thông tin khách hàng
        public DataTable getTTKhach(string sdt)
        {
            return dt.loadTTKhach(sdt);
        }

        //Kiểm tra khách hàng tồn tại
        public bool KTKhachHang(string sdt)
        {
            return dt.KTkhach(sdt);
        }

        //Kiểm tra rỗng
        public bool KTrong(string mathuoc,int soluong)
        {
            return dt.KTRong(mathuoc,soluong);
        }

        //làm mới thông tin khách
        public void lammoiKhach()
        {
            dt.lamMoiKhachHang();
        }

        //Lấy thuốc
        public bool LayThuoc(DTO_BanThuoc hd)
        {
           return dt.LayThuoc(hd);
        }

        //cập nhật lại số hóa đơn
        public int CapNhapSoHD()
        {
            return dt.CapNhatSoHD();
        }

        //load chi tiết hóa đơn
        public DataTable loadDSChiTietHD(int mahd)
        {
            return dt.loadDSChiTietHD(mahd);
        }

        //làm mới chi tiết hóa  đơn
        public void lammoiCTHD()
        {
            dt.lamMoiCTHD();
        }

        //thành tiền của hóa đơn
        public double ThanhTien(int mahd)
        {
            return dt.ThanhTien(mahd);
        }

        //Tính tiền dư của khách
        public double tinhTienDu(double TienThuoc, double TienKhach)
        {
            return dt.tinhTienDu(TienThuoc, TienKhach);
        }

        //kiểm tra thuốc còn hạn hoặc hết hạn
        public bool KTThuocHetHan(string mathuoc)
        {
            return dt.KTThuocHetHan(mathuoc);
        }
    }
}
