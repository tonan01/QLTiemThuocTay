using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemBanThuocTay.DTO
{
    class DTO_InHD
    {
        private  int maHD;
        private string maThuoc;
        private string soLuong;
        private string donGia;
        private double thanhTien;

        public int MaHD { get => maHD; set => maHD = value; }
        public string MaThuoc { get => maThuoc; set => maThuoc = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string DonGia { get => donGia; set => donGia = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }

        public DTO_InHD()
        { }

        public DTO_InHD(int maHD, string maThuoc, string soLuong, string donGia, double thanhTien)
        {
            MaHD = maHD;
            MaThuoc = maThuoc;
            SoLuong = soLuong;
            DonGia = donGia;
            ThanhTien = thanhTien;
        }
    }
}
