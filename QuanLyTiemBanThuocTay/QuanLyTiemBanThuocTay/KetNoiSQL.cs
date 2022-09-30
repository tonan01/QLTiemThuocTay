using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
namespace QuanLyTiemBanThuocTay
{
   public class KetNoiSQL
    {
        //Đọc file             //đường dẫn
        public  string Docfile()
        {
            string tenserver = "";
            string paas = "";
            string line = "";
            //đường dẫn
            string path = System.Windows.Forms.Application.StartupPath + "\\ServerName.txt";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            //đọc file
            while ((line = sr.ReadLine()) != null)
            {
                tenserver = line;
                line = sr.ReadLine();//qua dòng mới
                paas = line;
            }
            return "Data Source=" + tenserver + ";Initial Catalog=QLTiemThuocTay;Persist Security Info=True;User ID=sa;Password=" + paas + "";//giá trị của file

        }
        public SqlConnection conDB()
        {
            SqlConnection con = new SqlConnection(Docfile());
            return con;
        }
    }
}
