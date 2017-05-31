namespace PMQL_Luong.UserControl
{
    partial class UcQuanLyTaiKhoan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThemTK = new DevExpress.XtraBars.BarButtonItem();
            this.btnSuaTK = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoaTK = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.cmp_quyentruycap = new System.Windows.Forms.ComboBox();
            this.txt_sodt = new DevExpress.XtraEditors.TextEdit();
            this.txt_tennv = new DevExpress.XtraEditors.TextEdit();
            this.txt_matkhau = new DevExpress.XtraEditors.TextEdit();
            this.txt_nhaplaimk = new DevExpress.XtraEditors.TextEdit();
            this.txt_manv = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grid_taikhoan = new DevExpress.XtraGrid.GridControl();
            this.grv_taikhoan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_nhanvien = new DevExpress.XtraGrid.GridControl();
            this.grv_nhanvien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.errSDT = new System.Windows.Forms.ErrorProvider(this.components);
            this.errMatkhau = new System.Windows.Forms.ErrorProvider(this.components);
            this.errLaylaiMK = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sodt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tennv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matkhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nhaplaimk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_manv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_taikhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_taikhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_nhanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_nhanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMatkhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLaylaiMK)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemTK,
            this.btnSuaTK,
            this.btnXoaTK});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemTK, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSuaTK, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoaTK, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnThemTK
            // 
            this.btnThemTK.Caption = "Thêm tài khoản";
            this.btnThemTK.Glyph = global::PMQL_Luong.Properties.Resources.Add_User_Group_Woman_Man_48px;
            this.btnThemTK.Id = 0;
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemTK_ItemClick);
            // 
            // btnSuaTK
            // 
            this.btnSuaTK.Caption = "Cập nhật thông tin tài khoản";
            this.btnSuaTK.Glyph = global::PMQL_Luong.Properties.Resources.Edit_User_Male_48px;
            this.btnSuaTK.Id = 1;
            this.btnSuaTK.Name = "btnSuaTK";
            this.btnSuaTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSuaTK_ItemClick);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Caption = "Xóa tài khoản";
            this.btnXoaTK.Glyph = global::PMQL_Luong.Properties.Resources.Remove_User_Male_48px;
            this.btnXoaTK.Id = 2;
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoaTK_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(912, 63);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 381);
            this.barDockControlBottom.Size = new System.Drawing.Size(912, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 63);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 318);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(912, 63);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 318);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.xtraScrollableControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 63);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(304, 318);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin tài khoản";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.cmp_quyentruycap);
            this.xtraScrollableControl1.Controls.Add(this.txt_sodt);
            this.xtraScrollableControl1.Controls.Add(this.txt_tennv);
            this.xtraScrollableControl1.Controls.Add(this.txt_matkhau);
            this.xtraScrollableControl1.Controls.Add(this.txt_nhaplaimk);
            this.xtraScrollableControl1.Controls.Add(this.txt_manv);
            this.xtraScrollableControl1.Controls.Add(this.labelControl6);
            this.xtraScrollableControl1.Controls.Add(this.labelControl5);
            this.xtraScrollableControl1.Controls.Add(this.labelControl4);
            this.xtraScrollableControl1.Controls.Add(this.labelControl3);
            this.xtraScrollableControl1.Controls.Add(this.labelControl2);
            this.xtraScrollableControl1.Controls.Add(this.labelControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(2, 20);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(300, 296);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // cmp_quyentruycap
            // 
            this.cmp_quyentruycap.FormattingEnabled = true;
            this.cmp_quyentruycap.Items.AddRange(new object[] {
            "superadmin",
            "admin",
            "user"});
            this.cmp_quyentruycap.Location = new System.Drawing.Point(100, 245);
            this.cmp_quyentruycap.Name = "cmp_quyentruycap";
            this.cmp_quyentruycap.Size = new System.Drawing.Size(177, 21);
            this.cmp_quyentruycap.TabIndex = 6;
            // 
            // txt_sodt
            // 
            this.txt_sodt.Location = new System.Drawing.Point(100, 198);
            this.txt_sodt.MenuManager = this.barManager1;
            this.txt_sodt.Name = "txt_sodt";
            this.txt_sodt.Size = new System.Drawing.Size(177, 20);
            this.txt_sodt.TabIndex = 5;
            this.txt_sodt.EditValueChanged += new System.EventHandler(this.txt_sodt_EditValueChanged);
            // 
            // txt_tennv
            // 
            this.txt_tennv.Location = new System.Drawing.Point(100, 62);
            this.txt_tennv.MenuManager = this.barManager1;
            this.txt_tennv.Name = "txt_tennv";
            this.txt_tennv.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_tennv.Properties.Appearance.Options.UseForeColor = true;
            this.txt_tennv.Size = new System.Drawing.Size(177, 20);
            this.txt_tennv.TabIndex = 2;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Location = new System.Drawing.Point(100, 107);
            this.txt_matkhau.MenuManager = this.barManager1;
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(177, 20);
            this.txt_matkhau.TabIndex = 3;
            this.txt_matkhau.EditValueChanged += new System.EventHandler(this.txt_matkhau_EditValueChanged);
            // 
            // txt_nhaplaimk
            // 
            this.txt_nhaplaimk.Location = new System.Drawing.Point(100, 151);
            this.txt_nhaplaimk.MenuManager = this.barManager1;
            this.txt_nhaplaimk.Name = "txt_nhaplaimk";
            this.txt_nhaplaimk.Size = new System.Drawing.Size(177, 20);
            this.txt_nhaplaimk.TabIndex = 4;
            this.txt_nhaplaimk.EditValueChanged += new System.EventHandler(this.txt_nhaplaimk_EditValueChanged);
            // 
            // txt_manv
            // 
            this.txt_manv.Location = new System.Drawing.Point(100, 18);
            this.txt_manv.MenuManager = this.barManager1;
            this.txt_manv.Name = "txt_manv";
            this.txt_manv.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_manv.Properties.Appearance.Options.UseForeColor = true;
            this.txt_manv.Size = new System.Drawing.Size(177, 20);
            this.txt_manv.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 248);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 13);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "Quyền truy cập";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(8, 201);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 13);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Số điện thoại";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 154);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Nhập lại mật khẩu";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Tên nhân viên";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Mã nhân viên";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.groupControl3);
            this.groupControl2.Controls.Add(this.grid_nhanvien);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(304, 63);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(608, 318);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Danh sách nhân viên";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.grid_taikhoan);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(2, 156);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(604, 160);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Danh sách tài khoản";
            // 
            // grid_taikhoan
            // 
            this.grid_taikhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_taikhoan.Location = new System.Drawing.Point(2, 20);
            this.grid_taikhoan.MainView = this.grv_taikhoan;
            this.grid_taikhoan.MenuManager = this.barManager1;
            this.grid_taikhoan.Name = "grid_taikhoan";
            this.grid_taikhoan.Size = new System.Drawing.Size(600, 138);
            this.grid_taikhoan.TabIndex = 0;
            this.grid_taikhoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_taikhoan});
            // 
            // grv_taikhoan
            // 
            this.grv_taikhoan.GridControl = this.grid_taikhoan;
            this.grv_taikhoan.Name = "grv_taikhoan";
            this.grv_taikhoan.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.grv_taikhoan.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grv_taikhoan_CustomDrawRowIndicator);
            this.grv_taikhoan.Click += new System.EventHandler(this.grv_taikhoan_Click);
            // 
            // grid_nhanvien
            // 
            this.grid_nhanvien.Dock = System.Windows.Forms.DockStyle.Top;
            this.grid_nhanvien.Location = new System.Drawing.Point(2, 20);
            this.grid_nhanvien.MainView = this.grv_nhanvien;
            this.grid_nhanvien.MenuManager = this.barManager1;
            this.grid_nhanvien.Name = "grid_nhanvien";
            this.grid_nhanvien.Size = new System.Drawing.Size(604, 136);
            this.grid_nhanvien.TabIndex = 0;
            this.grid_nhanvien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_nhanvien});
            // 
            // grv_nhanvien
            // 
            this.grv_nhanvien.GridControl = this.grid_nhanvien;
            this.grv_nhanvien.Name = "grv_nhanvien";
            this.grv_nhanvien.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.grv_nhanvien.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grv_nhanvien_CustomDrawRowIndicator);
            this.grv_nhanvien.Click += new System.EventHandler(this.grv_nhanvien_Click);
            // 
            // errSDT
            // 
            this.errSDT.ContainerControl = this;
            // 
            // errMatkhau
            // 
            this.errMatkhau.ContainerControl = this;
            // 
            // errLaylaiMK
            // 
            this.errLaylaiMK.ContainerControl = this;
            // 
            // UcQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UcQuanLyTaiKhoan";
            this.Size = new System.Drawing.Size(912, 381);
            this.Load += new System.EventHandler(this.UcQuanLyTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_sodt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tennv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matkhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nhaplaimk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_manv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_taikhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_taikhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_nhanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_nhanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMatkhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLaylaiMK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnThemTK;
        private DevExpress.XtraBars.BarButtonItem btnSuaTK;
        private DevExpress.XtraBars.BarButtonItem btnXoaTK;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grid_nhanvien;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_nhanvien;
        private DevExpress.XtraGrid.GridControl grid_taikhoan;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_taikhoan;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.ComboBox cmp_quyentruycap;
        private DevExpress.XtraEditors.TextEdit txt_sodt;
        private DevExpress.XtraEditors.TextEdit txt_tennv;
        private DevExpress.XtraEditors.TextEdit txt_matkhau;
        private DevExpress.XtraEditors.TextEdit txt_nhaplaimk;
        private DevExpress.XtraEditors.TextEdit txt_manv;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ErrorProvider errSDT;
        private System.Windows.Forms.ErrorProvider errMatkhau;
        private System.Windows.Forms.ErrorProvider errLaylaiMK;
    }
}
