namespace Bai05
{
    partial class Client
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
            label6 = new Label();
            label3 = new Label();
            label1 = new Label();
            btnGuiDuLieu = new Button();
            txtTenMonAn = new TextBox();
            txtTenNguoiDung = new TextBox();
            btnAnh = new Button();
            txtHinhAnhName = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btnRanDom = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 136);
            label6.Name = "label6";
            label6.Size = new Size(70, 25);
            label6.TabIndex = 29;
            label6.Text = "Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 192);
            label3.Name = "label3";
            label3.Size = new Size(44, 25);
            label3.TabIndex = 20;
            label3.Text = "Ảnh";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 76);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 18;
            label1.Text = "Nhập món ăn";
            // 
            // btnGuiDuLieu
            // 
            btnGuiDuLieu.Location = new Point(181, 249);
            btnGuiDuLieu.Name = "btnGuiDuLieu";
            btnGuiDuLieu.Size = new Size(112, 34);
            btnGuiDuLieu.TabIndex = 30;
            btnGuiDuLieu.Text = "Gửi dữ liệu";
            btnGuiDuLieu.UseVisualStyleBackColor = true;
            btnGuiDuLieu.Click += btnGuiDuLieu_Click;
            // 
            // txtTenMonAn
            // 
            txtTenMonAn.Location = new Point(181, 73);
            txtTenMonAn.Name = "txtTenMonAn";
            txtTenMonAn.Size = new Size(150, 31);
            txtTenMonAn.TabIndex = 31;
            // 
            // txtTenNguoiDung
            // 
            txtTenNguoiDung.Location = new Point(181, 130);
            txtTenNguoiDung.Name = "txtTenNguoiDung";
            txtTenNguoiDung.Size = new Size(150, 31);
            txtTenNguoiDung.TabIndex = 32;
            // 
            // btnAnh
            // 
            btnAnh.Location = new Point(181, 187);
            btnAnh.Name = "btnAnh";
            btnAnh.Size = new Size(112, 34);
            btnAnh.TabIndex = 34;
            btnAnh.Text = "Chọn ảnh";
            btnAnh.UseVisualStyleBackColor = true;
            btnAnh.Click += btnAnh_Click;
            // 
            // txtHinhAnhName
            // 
            txtHinhAnhName.AutoSize = true;
            txtHinhAnhName.Location = new Point(121, 192);
            txtHinhAnhName.Name = "txtHinhAnhName";
            txtHinhAnhName.Size = new Size(85, 25);
            txtHinhAnhName.TabIndex = 35;
            txtHinhAnhName.Text = "path Ảnh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 25);
            label2.Name = "label2";
            label2.Size = new Size(195, 25);
            label2.TabIndex = 36;
            label2.Text = "Cập nhật thêm món ăn";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(398, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(390, 263);
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            // 
            // btnRanDom
            // 
            btnRanDom.Location = new Point(498, 357);
            btnRanDom.Name = "btnRanDom";
            btnRanDom.Size = new Size(150, 48);
            btnRanDom.TabIndex = 38;
            btnRanDom.Text = "Chọn món";
            btnRanDom.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(398, 302);
            label4.Name = "label4";
            label4.Size = new Size(343, 25);
            label4.TabIndex = 39;
            label4.Text = "Hiện tên món ăn dới tên người đóng góp";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(btnRanDom);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(txtHinhAnhName);
            Controls.Add(btnAnh);
            Controls.Add(txtTenNguoiDung);
            Controls.Add(txtTenMonAn);
            Controls.Add(btnGuiDuLieu);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Client";
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private Label label3;
        private Label label1;
        private Button btnGuiDuLieu;
        private TextBox txtTenMonAn;
        private TextBox txtTenNguoiDung;
        private Button btnAnh;
        private Label txtHinhAnhName;
        private Label label2;
        private PictureBox pictureBox1;
        private Button btnRanDom;
        private Label label4;
    }
}