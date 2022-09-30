using QuanLyTiemBanThuocTay.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyTiemBanThuocTay.BUS
{
   public class BUS_InHD
    {
        DAO_InHD dt = new DAO_InHD();
        
        //load ct hd
        public DataTable loadCTHD(int mahd)
        {
            return dt.loadCTHoaDON(mahd);
        }

        //làm mới
        public void LamMoi()
        {
            dt.lamMoi();
        }

      
    }
}
