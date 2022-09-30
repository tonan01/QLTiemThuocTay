using QuanLyTiemBanThuocTay.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemBanThuocTay.GUI
{
    public partial class Frm_InHD : Form
    {
        public Frm_InHD()
        {
            InitializeComponent();
        }
        BUS_InHD dt = new BUS_InHD();
        public static string soHD = "";

        private void Frm_InHD_Load(object sender, EventArgs e)
        {
          
            //đọc file lấy tenesserver và pass
            string tenserver = "";
            string paas = "";
            string line = "";
            //đường dẫn
            string path = System.Windows.Forms.Application.StartupPath + "\\ServerName.txt";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            //đọc file
            while ((line = sr.ReadLine()) != null)
            {
                tenserver = line;//ten sv
                line = sr.ReadLine();//qua dòng mới
                paas = line;//pass
            }

            //thêm dữ liệu vào rp
            dt.LamMoi();
            MyRePort rpt = new MyRePort();
            crystalReportViewer1.Refresh();
            rpt.SetDataSource(dt.loadCTHD(int.Parse(soHD)));
            //rpt.SetParameterValue
            crystalReportViewer1.ReportSource = rpt;
            //không cần nhập
            rpt.SetDatabaseLogon("sa", paas, tenserver, "QLTiemThuocTay");

            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.RefreshReport();




           
            



        }
    }
}
