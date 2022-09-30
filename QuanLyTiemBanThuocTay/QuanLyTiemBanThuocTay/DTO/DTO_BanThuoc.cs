using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemBanThuocTay.DTO
{
   public class DTO_BanThuoc
    {
        private int maHD;
        private string ngayLap;
        private string nguoiLap;
        private string maKH;
        private double thanhTien;
        private string maLHD;
        private Byte[] hinhAnh;
        private string maThuoc;
        private int soLuong;
        private double donGia;

        public int MaHD { get => maHD; set => maHD = value; }
        public string NgayLap { get => ngayLap; set => ngayLap = value; }
        public string NguoiLap { get => nguoiLap; set => nguoiLap = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string MaLHD { get => maLHD; set => maLHD = value; }
        public byte[] HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string MaThuoc { get => maThuoc; set => maThuoc = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }

        public DTO_BanThuoc(int maHD, string ngayLap, string nguoiLap, string maKH, double thanhTien, string maLHD, byte[] hinhAnh, string maThuoc, int soLuong, double donGia)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            NguoiLap = nguoiLap;
            MaKH = maKH;
            ThanhTien = thanhTien;
            MaLHD = maLHD;
            HinhAnh = hinhAnh;
            MaThuoc = maThuoc;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }
}
