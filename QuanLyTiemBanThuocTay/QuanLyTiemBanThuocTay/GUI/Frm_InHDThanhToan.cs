using QuanLyTiemBanThuocTay.BUS;
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
    public partial class Frm_InHDThanhToan : Form
    {
        public Frm_InHDThanhToan()
        {
            InitializeComponent();
        }
        BUS_InHDThanhToan dt = new BUS_InHDThanhToan();
        public static string soHD = "";
        public static string luuTienKhach = "";
        public static string luuTienDu = "";

        //xữ lý rp
        private void Frm_InHDThanhToan_Load(object sender, EventArgs e)
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
            MyReportThanhToan rpt = new MyReportThanhToan();
            crystalReportViewer1.Refresh();
            rpt.SetDataSource(dt.loadCTHD(int.Parse(soHD), int.Parse(luuTienKhach), int.Parse(luuTienDu)));
            crystalReportViewer1.ReportSource = rpt;
            //không cần nhập
            rpt.SetDatabaseLogon("sa", paas, tenserver, "QLTiemThuocTay");

            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.RefreshReport();
        }
    }
}
