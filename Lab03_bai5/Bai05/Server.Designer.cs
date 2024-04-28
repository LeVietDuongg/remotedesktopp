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
            btnrandom = new Button();
            monduocchon = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // btnXemDSMonAn
            // 
            btnXemDSMonAn.Location = new Point(18, 29);
            btnXemDSMonAn.Margin = new Padding(2);
            btnXemDSMonAn.Name = "btnXemDSMonAn";
            btnXemDSMonAn.Size = new Size(150, 27);
            btnXemDSMonAn.TabIndex = 0;
            btnXemDSMonAn.Text = "Xem DS Món ăn";
            btnXemDSMonAn.UseVisualStyleBackColor = true;
            btnXemDSMonAn.Click += btnXemDSMonAn_Click;
            // 
            // btnXemDSNCC
            // 
            btnXemDSNCC.Location = new Point(446, 29);
            btnXemDSNCC.Margin = new Padding(2);
            btnXemDSNCC.Name = "btnXemDSNCC";
            btnXemDSNCC.Size = new Size(190, 27);
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
            lsvDSMonan.Location = new Point(18, 75);
            lsvDSMonan.Margin = new Padding(2);
            lsvDSMonan.Name = "lsvDSMonan";
            lsvDSMonan.Size = new Size(401, 371);
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
            lsvDSNCC.Location = new Point(446, 75);
            lsvDSNCC.Margin = new Padding(2);
            lsvDSNCC.Name = "lsvDSNCC";
            lsvDSNCC.Size = new Size(357, 220);
            lsvDSNCC.TabIndex = 3;
            lsvDSNCC.UseCompatibleStateImageBehavior = false;
            lsvDSNCC.View = View.Details;
            lsvDSNCC.SelectedIndexChanged += lsvDSNCC_SelectedIndexChanged;
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
            PictureBox.Location = new Point(446, 315);
            PictureBox.Margin = new Padding(2);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(213, 130);
            PictureBox.TabIndex = 4;
            PictureBox.TabStop = false;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(699, 410);
            btnThoat.Margin = new Padding(2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(90, 35);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(699, 315);
            btnListen.Margin = new Padding(2);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(90, 35);
            btnListen.TabIndex = 6;
            btnListen.Text = "Lắng nghe";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // btnrandom
            // 
            btnrandom.Location = new Point(695, 367);
            btnrandom.Name = "btnrandom";
            btnrandom.Size = new Size(94, 29);
            btnrandom.TabIndex = 7;
            btnrandom.Text = "Random";
            btnrandom.UseVisualStyleBackColor = true;
            btnrandom.Click += btnrandom_Click;
            // 
            // monduocchon
            // 
            monduocchon.Location = new Point(99, 514);
            monduocchon.Multiline = true;
            monduocchon.Name = "monduocchon";
            monduocchon.Size = new Size(643, 105);
            monduocchon.TabIndex = 8;
            monduocchon.TextChanged += textBox1_TextChanged;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 631);
            Controls.Add(monduocchon);
            Controls.Add(btnrandom);
            Controls.Add(btnListen);
            Controls.Add(btnThoat);
            Controls.Add(PictureBox);
            Controls.Add(lsvDSNCC);
            Controls.Add(lsvDSMonan);
            Controls.Add(btnXemDSNCC);
            Controls.Add(btnXemDSMonAn);
            Margin = new Padding(2);
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Button btnrandom;
        private TextBox monduocchon;
    }
}