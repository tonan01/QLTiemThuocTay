using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemBanThuocTay.DAO
{
    public class DAO_InHD
    {
        //kết nối sql
        SqlConnection con;
        //tạo dataset
        DataSet ds_KH = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;
        KetNoiSQL dt = new KetNoiSQL();

        public DAO_InHD()
        {
        }


        //load ct hóa đơn
        public DataTable loadCTHoaDON(int mahd)
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec inHD '" + mahd+"'", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "CTHD_HOADON");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[2];
            key[0] = ds_KH.Tables["CTHD_HOADON"].Columns[0];//chọn columns 0
            key[1] = ds_KH.Tables["CTHD_HOADON"].Columns[1];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["CTHD_HOADON"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_KH.Tables["CTHD_HOADON"];
        }

        //làm mới 
        public void lamMoi()
        { 
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select CT_HOADON.*,thanhTien from CT_HOADON,HOADON where CT_HOADON.maHD=HOADON.maHD", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "CTHD_HOADON");
            //xóa dữ liệu cũ
            ds_KH.Tables["CTHD_HOADON"].Clear();
        }

        

    }
}
