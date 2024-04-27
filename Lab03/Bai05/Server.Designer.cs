namespace Bai05
{
    partial class Server
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
            btnXemDSMonAn = new Button();
            btnXemDSNCC = new Button();
            lsvDSMonan = new ListView();
            IDMA = new ColumnHeader();
            TenMonAn = new ColumnHeader();
            HinhAnh = new ColumnHeader();
            IDNCC = new ColumnHeader();
            lsvDSNCC = new ListView();
            ID = new ColumnHeader();
            HoVaTen = new ColumnHeader();
            QuyenHan = new ColumnHeader();
            PictureBox = new PictureBox();
            btnThoat = new Button();
            btnListen = new Button();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // btnXemDSMonAn
            // 
            btnXemDSMonAn.Location = new Point(23, 36);
            btnXemDSMonAn.Name = "btnXemDSMonAn";
            btnXemDSMonAn.Size = new Size(188, 34);
            btnXemDSMonAn.TabIndex = 0;
            btnXemDSMonAn.Text = "Xem DS Món ăn";
            btnXemDSMonAn.UseVisualStyleBackColor = true;
            btnXemDSMonAn.Click += btnXemDSMonAn_Click;
            // 
            // btnXemDSNCC
            // 
            btnXemDSNCC.Location = new Point(558, 36);
            btnXemDSNCC.Name = "btnXemDSNCC";
            btnXemDSNCC.Size = new Size(238, 34);
            btnXemDSNCC.TabIndex = 1;
            btnXemDSNCC.Text = "Xem DS Người Cung cấp";
            btnXemDSNCC.UseVisualStyleBackColor = true;
            btnXemDSNCC.Click += btnXemDSNCC_Click;
            // 
            // lsvDSMonan
            // 
            lsvDSMonan.Columns.AddRange(new ColumnHeader[] { IDMA, TenMonAn, HinhAnh, IDNCC });
            lsvDSMonan.Font = new Font("MS Reference Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lsvDSMonan.FullRowSelect = true;
            lsvDSMonan.Location = new Point(23, 94);
            lsvDSMonan.Name = "lsvDSMonan";
            lsvDSMonan.Size = new Size(500, 463);
            lsvDSMonan.TabIndex = 2;
            lsvDSMonan.UseCompatibleStateImageBehavior = false;
            lsvDSMonan.View = View.Details;
            lsvDSMonan.SelectedIndexChanged += lsvDSMonan_SelectedIndexChanged;
            // 
            // IDMA
            // 
            IDMA.Text = "IDMA";
            IDMA.Width = 70;
            // 
            // TenMonAn
            // 
            TenMonAn.Text = "Tên món ăn";
            TenMonAn.Width = 200;
            // 
            // HinhAnh
            // 
            HinhAnh.Text = "Hình ảnh";
            HinhAnh.Width = 150;
            // 
            // IDNCC
            // 
            IDNCC.Text = "IDNCC";
            IDNCC.Width = 75;
            // 
            // lsvDSNCC
            // 
            lsvDSNCC.Columns.AddRange(new ColumnHeader[] { ID, HoVaTen, QuyenHan });
            lsvDSNCC.Font = new Font("MS Reference Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lsvDSNCC.Location = new Point(558, 94);
            lsvDSNCC.Name = "lsvDSNCC";
            lsvDSNCC.Size = new Size(445, 274);
            lsvDSNCC.TabIndex = 3;
            lsvDSNCC.UseCompatibleStateImageBehavior = false;
            lsvDSNCC.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "IDNCC";
            ID.Width = 80;
            // 
            // HoVaTen
            // 
            HoVaTen.Text = "Họ và tên";
            HoVaTen.Width = 250;
            // 
            // QuyenHan
            // 
            QuyenHan.Text = "Quyền hạn";
            QuyenHan.Width = 110;
            // 
            // PictureBox
            // 
            PictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            PictureBox.Location = new Point(558, 394);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(266, 163);
            PictureBox.TabIndex = 4;
            PictureBox.TabStop = false;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(874, 513);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 44);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(874, 394);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(112, 44);
            btnListen.TabIndex = 6;
            btnListen.Text = "Lắng nghe";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(874, 455);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(112, 44);
            btnStop.TabIndex = 7;
            btnStop.Text = "Dừng lại";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 569);
            Controls.Add(btnStop);
            Controls.Add(btnListen);
            Controls.Add(btnThoat);
            Controls.Add(PictureBox);
            Controls.Add(lsvDSNCC);
            Controls.Add(lsvDSMonan);
            Controls.Add(btnXemDSNCC);
            Controls.Add(btnXemDSMonAn);
            Name = "Server";
            Text = "Server";
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnXemDSMonAn;
        private Button btnXemDSNCC;
        private ListView lsvDSMonan;
        private ListView lsvDSNCC;
        private ColumnHeader IDMA;
        private ColumnHeader TenMonAn;
        private ColumnHeader HinhAnh;
        private ColumnHeader IDNCC;
        private ColumnHeader ID;
        private ColumnHeader HoVaTen;
        private ColumnHeader QuyenHan;
        private PictureBox PictureBox;
        private Button btnThoat;
        private Button btnListen;
        private Button btnStop;
    }
}