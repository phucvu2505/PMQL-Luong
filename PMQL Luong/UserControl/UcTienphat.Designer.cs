namespace PMQL_Luong.UserControl
{
    partial class UcTienphat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcTienphat));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gcmucphat = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gBmucphat = new System.Windows.Forms.GroupBox();
            this.txtten = new DevExpress.XtraEditors.TextEdit();
            this.txtgiatri = new DevExpress.XtraEditors.TextEdit();
            this.txtma = new DevExpress.XtraEditors.TextEdit();
            this.btn_XoaPhat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SuaPhat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_LuuPhat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ThemPhat = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gctienphat = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gbNguoiphat = new System.Windows.Forms.GroupBox();
            this.btn_luungphat = new DevExpress.XtraEditors.SimpleButton();
            this.txtnguoighi = new DevExpress.XtraEditors.TextEdit();
            this.btn_xoangphat = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_suangphat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_themngphat = new DevExpress.XtraEditors.SimpleButton();
            this.cbntenmuc = new System.Windows.Forms.ComboBox();
            this.cbntenngbiphat = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_timkiem = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcmucphat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.gBmucphat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgiatri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtma.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctienphat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.gbNguoiphat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnguoighi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_timkiem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_timkiem);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.gcmucphat);
            this.groupBox1.Controls.Add(this.gBmucphat);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin mức phạt";
            // 
            // gcmucphat
            // 
            this.gcmucphat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcmucphat.Location = new System.Drawing.Point(289, 17);
            this.gcmucphat.MainView = this.gridView1;
            this.gcmucphat.Name = "gcmucphat";
            this.gcmucphat.Size = new System.Drawing.Size(567, 216);
            this.gcmucphat.TabIndex = 2;
            this.gcmucphat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcmucphat.Click += new System.EventHandler(this.gcmucphat_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcmucphat;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gBmucphat
            // 
            this.gBmucphat.Controls.Add(this.txtten);
            this.gBmucphat.Controls.Add(this.txtgiatri);
            this.gBmucphat.Controls.Add(this.txtma);
            this.gBmucphat.Controls.Add(this.btn_XoaPhat);
            this.gBmucphat.Controls.Add(this.btn_SuaPhat);
            this.gBmucphat.Controls.Add(this.btn_LuuPhat);
            this.gBmucphat.Controls.Add(this.btn_ThemPhat);
            this.gBmucphat.Controls.Add(this.label3);
            this.gBmucphat.Controls.Add(this.label2);
            this.gBmucphat.Controls.Add(this.label1);
            this.gBmucphat.Dock = System.Windows.Forms.DockStyle.Left;
            this.gBmucphat.Location = new System.Drawing.Point(3, 17);
            this.gBmucphat.Name = "gBmucphat";
            this.gBmucphat.Size = new System.Drawing.Size(286, 216);
            this.gBmucphat.TabIndex = 1;
            this.gBmucphat.TabStop = false;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(104, 96);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(176, 20);
            this.txtten.TabIndex = 3;
            // 
            // txtgiatri
            // 
            this.txtgiatri.Location = new System.Drawing.Point(104, 141);
            this.txtgiatri.Name = "txtgiatri";
            this.txtgiatri.Size = new System.Drawing.Size(176, 20);
            this.txtgiatri.TabIndex = 3;
            this.txtgiatri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgiatri_KeyPress);
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(104, 57);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(176, 20);
            this.txtma.TabIndex = 4;
            // 
            // btn_XoaPhat
            // 
            this.btn_XoaPhat.Image = global::PMQL_Luong.Properties.Resources.close_delete_2;
            this.btn_XoaPhat.Location = new System.Drawing.Point(177, 13);
            this.btn_XoaPhat.Name = "btn_XoaPhat";
            this.btn_XoaPhat.Size = new System.Drawing.Size(83, 37);
            this.btn_XoaPhat.TabIndex = 3;
            this.btn_XoaPhat.Text = "Xóa";
            this.btn_XoaPhat.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btn_SuaPhat
            // 
            this.btn_SuaPhat.Image = global::PMQL_Luong.Properties.Resources.pencil_edit;
            this.btn_SuaPhat.Location = new System.Drawing.Point(96, 13);
            this.btn_SuaPhat.Name = "btn_SuaPhat";
            this.btn_SuaPhat.Size = new System.Drawing.Size(83, 37);
            this.btn_SuaPhat.TabIndex = 3;
            this.btn_SuaPhat.Text = "Sửa";
            this.btn_SuaPhat.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btn_LuuPhat
            // 
            this.btn_LuuPhat.Image = ((System.Drawing.Image)(resources.GetObject("btn_LuuPhat.Image")));
            this.btn_LuuPhat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_LuuPhat.Location = new System.Drawing.Point(195, 168);
            this.btn_LuuPhat.Name = "btn_LuuPhat";
            this.btn_LuuPhat.Size = new System.Drawing.Size(75, 32);
            this.btn_LuuPhat.TabIndex = 3;
            this.btn_LuuPhat.Text = "Lưu";
            this.btn_LuuPhat.Click += new System.EventHandler(this.btn_luuphat_Click);
            // 
            // btn_ThemPhat
            // 
            this.btn_ThemPhat.Image = global::PMQL_Luong.Properties.Resources.plus;
            this.btn_ThemPhat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_ThemPhat.Location = new System.Drawing.Point(9, 13);
            this.btn_ThemPhat.Name = "btn_ThemPhat";
            this.btn_ThemPhat.Size = new System.Drawing.Size(89, 37);
            this.btn_ThemPhat.TabIndex = 3;
            this.btn_ThemPhat.Text = "Thêm";
            this.btn_ThemPhat.Click += new System.EventHandler(this.btn__Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá trị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên mức phạt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã mức phạt";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gctienphat);
            this.groupBox2.Controls.Add(this.gbNguoiphat);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(859, 264);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phạt";
            // 
            // gctienphat
            // 
            this.gctienphat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctienphat.Location = new System.Drawing.Point(289, 17);
            this.gctienphat.MainView = this.gridView2;
            this.gctienphat.Name = "gctienphat";
            this.gctienphat.Size = new System.Drawing.Size(567, 244);
            this.gctienphat.TabIndex = 3;
            this.gctienphat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gctienphat.Click += new System.EventHandler(this.gctienphat_Click);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gctienphat;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView2_CustomDrawRowIndicator);
            // 
            // gbNguoiphat
            // 
            this.gbNguoiphat.Controls.Add(this.btn_luungphat);
            this.gbNguoiphat.Controls.Add(this.txtnguoighi);
            this.gbNguoiphat.Controls.Add(this.btn_xoangphat);
            this.gbNguoiphat.Controls.Add(this.dateTimePicker1);
            this.gbNguoiphat.Controls.Add(this.btn_suangphat);
            this.gbNguoiphat.Controls.Add(this.btn_themngphat);
            this.gbNguoiphat.Controls.Add(this.cbntenmuc);
            this.gbNguoiphat.Controls.Add(this.cbntenngbiphat);
            this.gbNguoiphat.Controls.Add(this.label8);
            this.gbNguoiphat.Controls.Add(this.label6);
            this.gbNguoiphat.Controls.Add(this.label4);
            this.gbNguoiphat.Controls.Add(this.label5);
            this.gbNguoiphat.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbNguoiphat.Location = new System.Drawing.Point(3, 17);
            this.gbNguoiphat.Name = "gbNguoiphat";
            this.gbNguoiphat.Size = new System.Drawing.Size(286, 244);
            this.gbNguoiphat.TabIndex = 2;
            this.gbNguoiphat.TabStop = false;
            // 
            // btn_luungphat
            // 
            this.btn_luungphat.Image = ((System.Drawing.Image)(resources.GetObject("btn_luungphat.Image")));
            this.btn_luungphat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_luungphat.Location = new System.Drawing.Point(195, 201);
            this.btn_luungphat.Name = "btn_luungphat";
            this.btn_luungphat.Size = new System.Drawing.Size(75, 37);
            this.btn_luungphat.TabIndex = 6;
            this.btn_luungphat.Text = "Lưu";
            this.btn_luungphat.Click += new System.EventHandler(this.btn_luungphat_Click);
            // 
            // txtnguoighi
            // 
            this.txtnguoighi.Location = new System.Drawing.Point(104, 159);
            this.txtnguoighi.Name = "txtnguoighi";
            this.txtnguoighi.Size = new System.Drawing.Size(176, 20);
            this.txtnguoighi.TabIndex = 3;
            // 
            // btn_xoangphat
            // 
            this.btn_xoangphat.Image = global::PMQL_Luong.Properties.Resources.close_delete_2;
            this.btn_xoangphat.Location = new System.Drawing.Point(185, 12);
            this.btn_xoangphat.Name = "btn_xoangphat";
            this.btn_xoangphat.Size = new System.Drawing.Size(75, 42);
            this.btn_xoangphat.TabIndex = 3;
            this.btn_xoangphat.Text = "Xóa";
            this.btn_xoangphat.Click += new System.EventHandler(this.button6_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 68);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // btn_suangphat
            // 
            this.btn_suangphat.Image = global::PMQL_Luong.Properties.Resources.pencil_edit;
            this.btn_suangphat.Location = new System.Drawing.Point(96, 12);
            this.btn_suangphat.Name = "btn_suangphat";
            this.btn_suangphat.Size = new System.Drawing.Size(92, 42);
            this.btn_suangphat.TabIndex = 3;
            this.btn_suangphat.Text = "Sửa";
            this.btn_suangphat.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_themngphat
            // 
            this.btn_themngphat.Image = global::PMQL_Luong.Properties.Resources.plus;
            this.btn_themngphat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_themngphat.Location = new System.Drawing.Point(9, 12);
            this.btn_themngphat.Name = "btn_themngphat";
            this.btn_themngphat.Size = new System.Drawing.Size(88, 42);
            this.btn_themngphat.TabIndex = 3;
            this.btn_themngphat.Text = "Thêm";
            this.btn_themngphat.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbntenmuc
            // 
            this.cbntenmuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbntenmuc.FormattingEnabled = true;
            this.cbntenmuc.Location = new System.Drawing.Point(104, 126);
            this.cbntenmuc.Name = "cbntenmuc";
            this.cbntenmuc.Size = new System.Drawing.Size(176, 21);
            this.cbntenmuc.TabIndex = 3;
            // 
            // cbntenngbiphat
            // 
            this.cbntenngbiphat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbntenngbiphat.FormattingEnabled = true;
            this.cbntenngbiphat.Location = new System.Drawing.Point(104, 98);
            this.cbntenngbiphat.Name = "cbntenngbiphat";
            this.cbntenngbiphat.Size = new System.Drawing.Size(176, 21);
            this.cbntenngbiphat.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Người ghi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "tên mức phạt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày phạt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên người bị phạt";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(585, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Tìm kiếm";
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_timkiem.Location = new System.Drawing.Point(646, 24);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(200, 20);
            this.txt_timkiem.TabIndex = 4;
            this.txt_timkiem.EditValueChanged += new System.EventHandler(this.txt_timkiem_EditValueChanged);
            // 
            // UcTienphat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UcTienphat";
            this.Size = new System.Drawing.Size(859, 500);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcmucphat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.gBmucphat.ResumeLayout(false);
            this.gBmucphat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtgiatri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtma.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctienphat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.gbNguoiphat.ResumeLayout(false);
            this.gbNguoiphat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnguoighi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_timkiem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gcmucphat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gctienphat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.GroupBox gbNguoiphat;
        private System.Windows.Forms.ComboBox cbntenmuc;
        private System.Windows.Forms.ComboBox cbntenngbiphat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gBmucphat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SimpleButton btn_XoaPhat;
        private DevExpress.XtraEditors.SimpleButton btn_SuaPhat;
        private DevExpress.XtraEditors.SimpleButton btn_ThemPhat;
        private DevExpress.XtraEditors.SimpleButton btn_LuuPhat;
        private DevExpress.XtraEditors.SimpleButton btn_xoangphat;
        private DevExpress.XtraEditors.SimpleButton btn_suangphat;
        private DevExpress.XtraEditors.SimpleButton btn_themngphat;
        private DevExpress.XtraEditors.SimpleButton btn_luungphat;
        private DevExpress.XtraEditors.TextEdit txtten;
        private DevExpress.XtraEditors.TextEdit txtma;
        private DevExpress.XtraEditors.TextEdit txtnguoighi;
        private DevExpress.XtraEditors.TextEdit txtgiatri;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.TextEdit txt_timkiem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
