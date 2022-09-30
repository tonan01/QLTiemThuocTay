namespace QuanLyTiemBanThuocTay.GUI
{
    partial class Frm_KetNoiSQL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_KetNoiSQL));
            this.btn_ketnoi = new System.Windows.Forms.Button();
            this.btn_NhapLai = new System.Windows.Forms.Button();
            this.lb_tensv = new System.Windows.Forms.Label();
            this.txt_tenserver = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.lb_pass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_tieptuc = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_luu = new System.Windows.Forms.Button();
            this.lb_daketnoi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ketnoi
            // 
            this.btn_ketnoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.btn_ketnoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_ketnoi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ketnoi.Location = new System.Drawing.Point(15, 46);
            this.btn_ketnoi.Name = "btn_ketnoi";
            this.btn_ketnoi.Size = new System.Drawing.Size(126, 33);
            this.btn_ketnoi.TabIndex = 0;
            this.btn_ketnoi.Text = "Kết Nối...";
            this.btn_ketnoi.UseVisualStyleBackColor = false;
            this.btn_ketnoi.Click += new System.EventHandler(this.btn_ketnoi_Click);
            // 
            // btn_NhapLai
            // 
            this.btn_NhapLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.btn_NhapLai.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_NhapLai.Location = new System.Drawing.Point(130, 263);
            this.btn_NhapLai.Name = "btn_NhapLai";
            this.btn_NhapLai.Size = new System.Drawing.Size(126, 33);
            this.btn_NhapLai.TabIndex = 1;
            this.btn_NhapLai.Text = "Nhập lại";
            this.btn_NhapLai.UseVisualStyleBackColor = false;
            this.btn_NhapLai.Click += new System.EventHandler(this.btn_NhapLai_Click);
            // 
            // lb_tensv
            // 
            this.lb_tensv.AutoSize = true;
            this.lb_tensv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_tensv.Location = new System.Drawing.Point(163, 169);
            this.lb_tensv.Name = "lb_tensv";
            this.lb_tensv.Size = new System.Drawing.Size(81, 17);
            this.lb_tensv.TabIndex = 2;
            this.lb_tensv.Text = "Tên server:";
            // 
            // txt_tenserver
            // 
            this.txt_tenserver.Location = new System.Drawing.Point(269, 169);
            this.txt_tenserver.Name = "txt_tenserver";
            this.txt_tenserver.Size = new System.Drawing.Size(233, 22);
            this.txt_tenserver.TabIndex = 3;
            this.txt_tenserver.TextChanged += new System.EventHandler(this.txt_tenserver_TextChanged);
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(269, 224);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(233, 22);
            this.txt_pass.TabIndex = 5;
            this.txt_pass.Click += new System.EventHandler(this.txt_pass_Click);
            // 
            // lb_pass
            // 
            this.lb_pass.AutoSize = true;
            this.lb_pass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_pass.Location = new System.Drawing.Point(170, 229);
            this.lb_pass.Name = "lb_pass";
            this.lb_pass.Size = new System.Drawing.Size(43, 17);
            this.lb_pass.TabIndex = 4;
            this.lb_pass.Text = "Pass:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(517, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kết Nối";
            // 
            // btn_tieptuc
            // 
            this.btn_tieptuc.BackColor = System.Drawing.Color.Black;
            this.btn_tieptuc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_tieptuc.Location = new System.Drawing.Point(537, 263);
            this.btn_tieptuc.Name = "btn_tieptuc";
            this.btn_tieptuc.Size = new System.Drawing.Size(126, 33);
            this.btn_tieptuc.TabIndex = 7;
            this.btn_tieptuc.Text = "Tiếp tục =>";
            this.btn_tieptuc.UseVisualStyleBackColor = false;
            this.btn_tieptuc.Click += new System.EventHandler(this.btn_tieptuc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Chưa Kết nối Server:";
            // 
            // btn_luu
            // 
            this.btn_luu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.btn_luu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_luu.Location = new System.Drawing.Point(333, 263);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(126, 33);
            this.btn_luu.TabIndex = 9;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = false;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // lb_daketnoi
            // 
            this.lb_daketnoi.AutoSize = true;
            this.lb_daketnoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_daketnoi.Location = new System.Drawing.Point(553, 234);
            this.lb_daketnoi.Name = "lb_daketnoi";
            this.lb_daketnoi.Size = new System.Drawing.Size(95, 17);
            this.lb_daketnoi.TabIndex = 10;
            this.lb_daketnoi.Text = "Đã có kết nối:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(293, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "App da mo";
            this.notifyIcon1.BalloonTipTitle = "Thong Bao";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Frm_KetNoiSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(675, 308);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_daketnoi);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_tieptuc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.lb_pass);
            this.Controls.Add(this.txt_tenserver);
            this.Controls.Add(this.lb_tensv);
            this.Controls.Add(this.btn_NhapLai);
            this.Controls.Add(this.btn_ketnoi);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Frm_KetNoiSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối";
            this.Load += new System.EventHandler(this.Frm_KetNoiSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ketnoi;
        private System.Windows.Forms.Button btn_NhapLai;
        private System.Windows.Forms.Label lb_tensv;
        private System.Windows.Forms.TextBox txt_tenserver;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Label lb_pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_tieptuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Label lb_daketnoi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}