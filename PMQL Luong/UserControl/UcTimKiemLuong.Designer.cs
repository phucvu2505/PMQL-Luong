namespace PMQL_Luong.UserControl
{
    partial class UcTimKiemLuong
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmp_truongtimkiem = new System.Windows.Forms.ComboBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmp_danhmuc = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_timkiem = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grid_timkiem = new DevExpress.XtraGrid.GridControl();
            this.grv_timkiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_timkiem = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_timkiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_timkiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_timkiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txt_timkiem);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cmp_truongtimkiem);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cmp_danhmuc);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(230, 381);
            this.groupControl1.TabIndex = 0;
            // 
            // cmp_truongtimkiem
            // 
            this.cmp_truongtimkiem.FormattingEnabled = true;
            this.cmp_truongtimkiem.Location = new System.Drawing.Point(20, 234);
            this.cmp_truongtimkiem.Name = "cmp_truongtimkiem";
            this.cmp_truongtimkiem.Size = new System.Drawing.Size(192, 21);
            this.cmp_truongtimkiem.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 199);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Trường tìm kiếm";
            // 
            // cmp_danhmuc
            // 
            this.cmp_danhmuc.FormattingEnabled = true;
            this.cmp_danhmuc.Location = new System.Drawing.Point(20, 159);
            this.cmp_danhmuc.Name = "cmp_danhmuc";
            this.cmp_danhmuc.Size = new System.Drawing.Size(192, 21);
            this.cmp_danhmuc.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 122);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Danh mục tìm kiếm";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_timkiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 74);
            this.panel1.TabIndex = 0;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Appearance.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.Appearance.Options.UseFont = true;
            this.btn_timkiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_timkiem.Image = global::PMQL_Luong.Properties.Resources.Search_32px;
            this.btn_timkiem.Location = new System.Drawing.Point(0, 0);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(226, 74);
            this.btn_timkiem.TabIndex = 0;
            this.btn_timkiem.Text = "Tìm kiếm";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grid_timkiem);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(230, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(682, 381);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Kết quả tìm kiếm";
            // 
            // grid_timkiem
            // 
            this.grid_timkiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_timkiem.Location = new System.Drawing.Point(2, 20);
            this.grid_timkiem.MainView = this.grv_timkiem;
            this.grid_timkiem.Name = "grid_timkiem";
            this.grid_timkiem.Size = new System.Drawing.Size(678, 359);
            this.grid_timkiem.TabIndex = 0;
            this.grid_timkiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_timkiem});
            // 
            // grv_timkiem
            // 
            this.grv_timkiem.GridControl = this.grid_timkiem;
            this.grv_timkiem.Name = "grv_timkiem";
            this.grv_timkiem.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.grv_timkiem.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grv_timkiem_CustomDrawRowIndicator);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 284);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Thông tin tìm kiếm";
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(22, 322);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(190, 20);
            this.txt_timkiem.TabIndex = 6;
            // 
            // UcTimKiemLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "UcTimKiemLuong";
            this.Size = new System.Drawing.Size(912, 381);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_timkiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_timkiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_timkiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btn_timkiem;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ComboBox cmp_truongtimkiem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cmp_danhmuc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grid_timkiem;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_timkiem;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_timkiem;
    }
}
