using QuanLyTiemBanThuocTay.DTO;
using QuanLyTiemBanThuocTay.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace QuanLyTiemBanThuocTay.DAO
{
   public class DAO_KetNoiSQL
    {

        SqlConnection con;
        KetNoiSQL dt = new KetNoiSQL();
        public DAO_KetNoiSQL()
        {
        }

        //lưu File           //dữ liệu lưu           path là đường dẫng
        public   bool Luufile(string tenserver,string pass)
        {
            try
            {
                string[] luu = new string[] { tenserver, pass };
                ////đường dẫn
                string path = Application.StartupPath + "\\ServerName.txt";
                //false là không ghi đè,  true là ghi đè
                StreamWriter ws = new StreamWriter(path, false, Encoding.UTF8);//lưu đường dẫn
                //ghi dữ liệu vào
                //ws.WriteLine("Data Source = " + tenserver + "; Initial Catalog = QLTiemThuocTay; User ID = sa; Password = " + pass + "");
                
                //lưu từng dòng
                foreach(string s in luu)
                {
                    ws.WriteLine(s);//add vào file txt
                }
                //đóng file
                ws.Close();
                //thành công
                return true;
            }
            catch
            {
                return false;//thất Bại
            }
        }

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
            public bool KTRong(string tenserver, string pass)
        {
            if (tenserver.Length == 0)//rỗng
            {
                MessageBox.Show("Chưa nhập tên server", "Thông Báo");
                return false;
            }
            if (pass.Length == 0)//rỗng
            {
                MessageBox.Show("Chưa Nhập pass", "Thông Báo");
                return false;
            }
            return true;//đã nhập tất cả
        }

     
    }
}
