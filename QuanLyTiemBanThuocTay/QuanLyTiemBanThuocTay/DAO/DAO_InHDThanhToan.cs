using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemBanThuocTay.DAO
{
    public class DAO_InHDThanhToan
    {
        //kết nối sql
        SqlConnection con;
        //tạo dataset
        DataSet ds_KH = new DataSet();
        //tạo đối tượng SqlDataAdapter
        SqlDataAdapter da;
        KetNoiSQL dt = new KetNoiSQL();

        public DAO_InHDThanhToan()
        {
        }


        //load ct hóa đơn
        public DataTable loadCTHoaDON(int mahd,int tienKhach, int tiendu)
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("exec inHDThanhToan "+mahd+","+tienKhach+","+tiendu+"", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "CTHD_HOADON_ThanhToan");
            //truoc khi them xoa sua can dat khoa chinh cho table khach hang
            DataColumn[] key = new DataColumn[2];
            key[0] = ds_KH.Tables["CTHD_HOADON_ThanhToan"].Columns[0];//chọn columns 0
            key[1] = ds_KH.Tables["CTHD_HOADON_ThanhToan"].Columns[1];//chọn columns 0
            //đặt làm khóa chính
            ds_KH.Tables["CTHD_HOADON_ThanhToan"].PrimaryKey = key;
            //trả về ds địa chỉ
            return ds_KH.Tables["CTHD_HOADON_ThanhToan"];
        }

        //làm mới 
        public void lamMoi()
        {
            con = dt.conDB();
            //tao doi tuong sqldataadapter
            da = new SqlDataAdapter("select CT_HOADON.*,thanhTien from CT_HOADON,HOADON where CT_HOADON.maHD=HOADON.maHD", con);
            //dien du lieu vao dataSet hoac goi anh xa bang khoa len dataset
            da.Fill(ds_KH, "CTHD_HOADON_ThanhToan");
            //xóa dữ liệu cũ
            ds_KH.Tables["CTHD_HOADON_ThanhToan"].Clear();
        }
    }
}
