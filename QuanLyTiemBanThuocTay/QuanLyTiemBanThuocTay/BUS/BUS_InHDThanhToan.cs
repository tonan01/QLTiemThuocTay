using QuanLyTiemBanThuocTay.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemBanThuocTay.BUS
{
   public class BUS_InHDThanhToan
    {
        DAO_InHDThanhToan dt = new DAO_InHDThanhToan();

        //load ct hd
        public DataTable loadCTHD(int mahd, int tienKhach, int tiendu)
        {
            return dt.loadCTHoaDON(mahd,tienKhach,tiendu);
        }

        //làm mới
        public void LamMoi()
        {
            dt.lamMoi();
        }
    }
}
