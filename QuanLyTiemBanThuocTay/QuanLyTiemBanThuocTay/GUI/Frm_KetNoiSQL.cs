using QuanLyTiemBanThuocTay.DAO;
using QuanLyTiemBanThuocTay.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTiemBanThuocTay.Properties;
using System.IO;

namespace QuanLyTiemBanThuocTay.GUI
{
    public partial class Frm_KetNoiSQL : Form
    {
        List<Image> images = new List<Image>();
        string[] location = new string[25];
        public Frm_KetNoiSQL()
        {
            InitializeComponent();
            tounage();
        }
        DAO_KetNoiSQL dt = new DAO_KetNoiSQL();
        //hình ảnh vào bitmap
        private void tounage()
        {
            for (int i = 0; i < 24; i++)
            {
                if (i > 0)
                {
                    Bitmap bitmap = new Bitmap(Resources.textbox_user_1);
                    images.Add(bitmap);
                    Bitmap bitmap2 = new Bitmap(Resources.textbox_user_2);
                    images.Add(bitmap2);
                    Bitmap bitmap3 = new Bitmap(Resources.textbox_user_3);
                    images.Add(bitmap3);
                    Bitmap bitmap4 = new Bitmap(Resources.textbox_user_4);
                    images.Add(bitmap4);
                    Bitmap bitmap5 = new Bitmap(Resources.textbox_user_5);
                    images.Add(bitmap5);
                    Bitmap bitmap6 = new Bitmap(Resources.textbox_user_6);
                    images.Add(bitmap6);
                    Bitmap bitmap7 = new Bitmap(Resources.textbox_user_7);
                    images.Add(bitmap7);
                    Bitmap bitmap8 = new Bitmap(Resources.textbox_user_8);
                    images.Add(bitmap8);
                    Bitmap bitmap9 = new Bitmap(Resources.textbox_user_9);
                    images.Add(bitmap9);
                    Bitmap bitmap10 = new Bitmap(Resources.textbox_user_10);
                    images.Add(bitmap10);
                    Bitmap bitmap11 = new Bitmap(Resources.textbox_user_11);
                    images.Add(bitmap11);
                    Bitmap bitmap12 = new Bitmap(Resources.textbox_user_12);
                    images.Add(bitmap12);
                    Bitmap bitmap13 = new Bitmap(Resources.textbox_user_13);
                    images.Add(bitmap13);
                    Bitmap bitmap14 = new Bitmap(Resources.textbox_user_14);
                    images.Add(bitmap14);
                    Bitmap bitmap15 = new Bitmap(Resources.textbox_user_15);
                    images.Add(bitmap15);
                    Bitmap bitmap16 = new Bitmap(Resources.textbox_user_16);
                    images.Add(bitmap16);
                    Bitmap bitmap17 = new Bitmap(Resources.textbox_user_17);
                    images.Add(bitmap17);
                    Bitmap bitmap18 = new Bitmap(Resources.textbox_user_18);
                    images.Add(bitmap18);
                    Bitmap bitmap19 = new Bitmap(Resources.textbox_user_19);
                    images.Add(bitmap19);
                    Bitmap bitmap20 = new Bitmap(Resources.textbox_user_20);
                    images.Add(bitmap20);
                    Bitmap bitmap21 = new Bitmap(Resources.textbox_user_21);
                    images.Add(bitmap21);
                    Bitmap bitmap22 = new Bitmap(Resources.textbox_user_22);
                    images.Add(bitmap22);
                    Bitmap bitmap23 = new Bitmap(Resources.textbox_user_23);
                    images.Add(bitmap23);
                    Bitmap bitmap24 = new Bitmap(Resources.textbox_user_24);
                    images.Add(bitmap24);

                }
            }
            images.Add(Properties.Resources.textbox_password);
        }
       
        private void Frm_KetNoiSQL_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(5000);
            //hiện hình ảnh
            pictureBox1.Image = Properties.Resources.debut;
            //ẩn
            pictureBox1.Visible=lb_tensv.Visible = lb_pass.Visible = txt_tenserver.Visible = txt_pass.Visible = btn_NhapLai.Visible=btn_luu.Visible = false;
        }
        
        private void btn_ketnoi_Click(object sender, EventArgs e)
        {
            //hiện
            pictureBox1.Visible=lb_tensv.Visible = lb_pass.Visible = txt_tenserver.Visible = txt_pass.Visible = btn_NhapLai.Visible = btn_luu.Visible = true;
            //ẩn
            lb_daketnoi.Visible=btn_tieptuc.Visible = false;
            
        }
        //làm mới
        private void btn_NhapLai_Click(object sender, EventArgs e)
        {
           
            txt_tenserver.Clear();
            txt_pass.Clear();
            txt_tenserver.Focus();
        }
        //chuyển form mới
        private void btn_tieptuc_Click(object sender, EventArgs e)
        {
            if (dt.KTKetNoi())//thành công
            {
                MessageBox.Show("Kết nối thành công", "Thông Báo");
                Frm_BanThuoc t = new Frm_BanThuoc();
                this.Hide();
                t.Show();
                return;
            }
            else//thất bại
            {
                MessageBox.Show("Kết nối Thất Bại", "Thông Báo");
                this.Close();
                return;
            }
            
        }
        //lưu connect
        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (dt.KTRong(txt_tenserver.Text, txt_pass.Text) == false)//rỗng
            {
                return;
            }
            //Lưu file
            if (dt.Luufile(txt_tenserver.Text, txt_pass.Text))//thành công
            {
                MessageBox.Show("Lưu Kết nối thành công", "Thông Báo");
                //hiển
                lb_daketnoi.Visible=btn_tieptuc.Visible = true;
                //ẩn
                pictureBox1.Visible = lb_tensv.Visible = lb_pass.Visible = txt_tenserver.Visible = txt_pass.Visible = btn_NhapLai.Visible = btn_luu.Visible = false;
                return;
            }
            else//thất Bại
            {
                MessageBox.Show("Lưu File Thất Bại", "Thông Báo");
                return;
            }
        }

        private void txt_tenserver_TextChanged(object sender, EventArgs e)
        {
            //đổi hình ảnh
            if (txt_tenserver.Text.Length > 0 && txt_tenserver.Text.Length <= 15)
            {
                pictureBox1.Image = images[txt_tenserver.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (txt_tenserver.Text.Length <= 0)//chưa ghi kí tự nào
                pictureBox1.Image = Properties.Resources.debut;
            else//kí tư >15
                pictureBox1.Image = images[22];
        }

        private void txt_pass_Click(object sender, EventArgs e)
        {
            Bitmap bmpass = new Bitmap(Resources.textbox_password);
            //hiển thị hình ảnh
            pictureBox1.Image = bmpass;
        }
    }
}
