namespace PMQL_Luong.UserControl
{
    partial class UcPhongBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPhongBan));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btn_them = new DevExpress.XtraBars.BarButtonItem();
            this.btn_sua = new DevExpress.XtraBars.BarButtonItem();
            this.btn_xoa = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_tennv = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.cmp_diadiem = new System.Windows.Forms.ComboBox();
            this.txt_tenpb = new DevExpress.XtraEditors.TextEdit();
            this.txt_mapb = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grid_phongban = new DevExpress.XtraGrid.GridControl();
            this.grv_phongban = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tennv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tenpb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mapb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_phongban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_phongban)).BeginInit();
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
            this.btn_them,
            this.btn_sua,
            this.btn_xoa});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_them, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_sua, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_xoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btn_them
            // 
            this.btn_them.Caption = "Thêm mới phòng ban";
            this.btn_them.Glyph = global::PMQL_Luong.Properties.Resources.plus;
            this.btn_them.Id = 1;
            this.btn_them.Name = "btn_them";
            this.btn_them.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_them_ItemClick);
            // 
            // btn_sua
            // 
            this.btn_sua.Caption = "Sửa thông tin phòng ban";
            this.btn_sua.Glyph = global::PMQL_Luong.Properties.Resources.pencil_edit;
            this.btn_sua.Id = 2;
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_sua_ItemClick);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Caption = "Xóa thông tin phòng ban";
            this.btn_xoa.Glyph = global::PMQL_Luong.Properties.Resources.close_delete_2;
            this.btn_xoa.Id = 3;
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_xoa_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(912, 47);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 334);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(912, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 334);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txt_tennv);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btn_huy);
            this.groupControl1.Controls.Add(this.btn_luu);
            this.groupControl1.Controls.Add(this.cmp_diadiem);
            this.groupControl1.Controls.Add(this.txt_tenpb);
            this.groupControl1.Controls.Add(this.txt_mapb);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 47);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(237, 334);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin phòng ban";
            // 
            // txt_tennv
            // 
            this.txt_tennv.Location = new System.Drawing.Point(18, 255);
            this.txt_tennv.MenuManager = this.barManager1;
            this.txt_tennv.Name = "txt_tennv";
            this.txt_tennv.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_tennv.Properties.Appearance.Options.UseForeColor = true;
            this.txt_tennv.Size = new System.Drawing.Size(200, 20);
            this.txt_tennv.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 227);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Nhân viên";
            // 
            // btn_huy
            // 
            this.btn_huy.Image = ((System.Drawing.Image)(resources.GetObject("btn_huy.Image")));
            this.btn_huy.Location = new System.Drawing.Point(119, 281);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(99, 48);
            this.btn_huy.TabIndex = 7;
            this.btn_huy.Text = "Hủy bỏ";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_luu.Image")));
            this.btn_luu.Location = new System.Drawing.Point(18, 281);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(95, 48);
            this.btn_luu.TabIndex = 6;
            this.btn_luu.Text = "Lưu lại";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // cmp_diadiem
            // 
            this.cmp_diadiem.FormattingEnabled = true;
            this.cmp_diadiem.Location = new System.Drawing.Point(18, 183);
            this.cmp_diadiem.Name = "cmp_diadiem";
            this.cmp_diadiem.Size = new System.Drawing.Size(200, 21);
            this.cmp_diadiem.TabIndex = 5;
            // 
            // txt_tenpb
            // 
            this.txt_tenpb.Location = new System.Drawing.Point(18, 121);
            this.txt_tenpb.MenuManager = this.barManager1;
            this.txt_tenpb.Name = "txt_tenpb";
            this.txt_tenpb.Size = new System.Drawing.Size(200, 20);
            this.txt_tenpb.TabIndex = 4;
            // 
            // txt_mapb
            // 
            this.txt_mapb.Location = new System.Drawing.Point(18, 58);
            this.txt_mapb.MenuManager = this.barManager1;
            this.txt_mapb.Name = "txt_mapb";
            this.txt_mapb.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_mapb.Properties.Appearance.Options.UseForeColor = true;
            this.txt_mapb.Size = new System.Drawing.Size(200, 20);
            this.txt_mapb.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 156);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(95, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Địa điểm phòng ban";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên phòng ban";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã phòng ban";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grid_phongban);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(237, 47);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(675, 334);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Danh sách phòng ban";
            // 
            // grid_phongban
            // 
            this.grid_phongban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_phongban.Location = new System.Drawing.Point(2, 20);
            this.grid_phongban.MainView = this.grv_phongban;
            this.grid_phongban.MenuManager = this.barManager1;
            this.grid_phongban.Name = "grid_phongban";
            this.grid_phongban.Size = new System.Drawing.Size(671, 312);
            this.grid_phongban.TabIndex = 0;
            this.grid_phongban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_phongban});
            // 
            // grv_phongban
            // 
            this.grv_phongban.GridControl = this.grid_phongban;
            this.grv_phongban.Name = "grv_phongban";
            this.grv_phongban.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.grv_phongban.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grv_phongban_CustomDrawRowIndicator);
            this.grv_phongban.Click += new System.EventHandler(this.grv_phongban_Click);
            // 
            // UcPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UcPhongBan";
            this.Size = new System.Drawing.Size(912, 381);
            this.Load += new System.EventHandler(this.UcPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tennv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tenpb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mapb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_phongban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_phongban)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btn_them;
        private DevExpress.XtraBars.BarButtonItem btn_sua;
        private DevExpress.XtraBars.BarButtonItem btn_xoa;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grid_phongban;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_phongban;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private System.Windows.Forms.ComboBox cmp_diadiem;
        private DevExpress.XtraEditors.TextEdit txt_tenpb;
        private DevExpress.XtraEditors.TextEdit txt_mapb;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_tennv;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
