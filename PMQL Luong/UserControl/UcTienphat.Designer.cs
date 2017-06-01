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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gcmucphat = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.gBmucphat = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtgiatri = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txtma = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gctienphat = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gbNguoiphat = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbntenmuc = new System.Windows.Forms.ComboBox();
            this.cbntenngbiphat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbnnguoighi = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcmucphat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.gBmucphat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctienphat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.gbNguoiphat.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcmucphat);
            this.groupBox1.Controls.Add(this.gBmucphat);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin mức phạt";
            // 
            // gcmucphat
            // 
            this.gcmucphat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcmucphat.Location = new System.Drawing.Point(289, 17);
            this.gcmucphat.MainView = this.gridView1;
            this.gcmucphat.MenuManager = this.barManager1;
            this.gcmucphat.Name = "gcmucphat";
            this.gcmucphat.Size = new System.Drawing.Size(534, 170);
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
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(826, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 410);
            this.barDockControlBottom.Size = new System.Drawing.Size(826, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 410);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(826, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 410);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // gBmucphat
            // 
            this.gBmucphat.Controls.Add(this.button3);
            this.gBmucphat.Controls.Add(this.button5);
            this.gBmucphat.Controls.Add(this.txtgiatri);
            this.gBmucphat.Controls.Add(this.button4);
            this.gBmucphat.Controls.Add(this.txtten);
            this.gBmucphat.Controls.Add(this.txtma);
            this.gBmucphat.Controls.Add(this.label3);
            this.gBmucphat.Controls.Add(this.label2);
            this.gBmucphat.Controls.Add(this.label1);
            this.gBmucphat.Dock = System.Windows.Forms.DockStyle.Left;
            this.gBmucphat.Location = new System.Drawing.Point(3, 17);
            this.gBmucphat.Name = "gBmucphat";
            this.gBmucphat.Size = new System.Drawing.Size(286, 170);
            this.gBmucphat.TabIndex = 1;
            this.gBmucphat.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(210, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "XÓA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(113, 135);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(56, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "SỬA";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtgiatri
            // 
            this.txtgiatri.Location = new System.Drawing.Point(104, 98);
            this.txtgiatri.Name = "txtgiatri";
            this.txtgiatri.Size = new System.Drawing.Size(176, 21);
            this.txtgiatri.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 135);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "THÊM";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(104, 53);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(176, 21);
            this.txtten.TabIndex = 3;
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(104, 17);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(176, 21);
            this.txtma.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá trị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên mức phạt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
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
            this.groupBox2.Location = new System.Drawing.Point(0, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 220);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phạt";
            // 
            // gctienphat
            // 
            this.gctienphat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctienphat.Location = new System.Drawing.Point(289, 17);
            this.gctienphat.MainView = this.gridView2;
            this.gctienphat.MenuManager = this.barManager1;
            this.gctienphat.Name = "gctienphat";
            this.gctienphat.Size = new System.Drawing.Size(534, 200);
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
            // 
            // gbNguoiphat
            // 
            this.gbNguoiphat.Controls.Add(this.dateTimePicker1);
            this.gbNguoiphat.Controls.Add(this.cbnnguoighi);
            this.gbNguoiphat.Controls.Add(this.button6);
            this.gbNguoiphat.Controls.Add(this.button2);
            this.gbNguoiphat.Controls.Add(this.button1);
            this.gbNguoiphat.Controls.Add(this.cbntenmuc);
            this.gbNguoiphat.Controls.Add(this.cbntenngbiphat);
            this.gbNguoiphat.Controls.Add(this.label8);
            this.gbNguoiphat.Controls.Add(this.label6);
            this.gbNguoiphat.Controls.Add(this.label4);
            this.gbNguoiphat.Controls.Add(this.label5);
            this.gbNguoiphat.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbNguoiphat.Location = new System.Drawing.Point(3, 17);
            this.gbNguoiphat.Name = "gbNguoiphat";
            this.gbNguoiphat.Size = new System.Drawing.Size(286, 200);
            this.gbNguoiphat.TabIndex = 2;
            this.gbNguoiphat.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(210, 146);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(56, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "XÓA";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "SỬA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "THÊM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbntenmuc
            // 
            this.cbntenmuc.FormattingEnabled = true;
            this.cbntenmuc.Location = new System.Drawing.Point(104, 69);
            this.cbntenmuc.Name = "cbntenmuc";
            this.cbntenmuc.Size = new System.Drawing.Size(176, 21);
            this.cbntenmuc.TabIndex = 3;
            // 
            // cbntenngbiphat
            // 
            this.cbntenngbiphat.FormattingEnabled = true;
            this.cbntenngbiphat.Location = new System.Drawing.Point(104, 41);
            this.cbntenngbiphat.Name = "cbntenngbiphat";
            this.cbntenngbiphat.Size = new System.Drawing.Size(176, 21);
            this.cbntenngbiphat.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "tên mức phạt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày phạt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên người bị phạt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Người ghi";
            // 
            // cbnnguoighi
            // 
            this.cbnnguoighi.FormattingEnabled = true;
            this.cbnnguoighi.Location = new System.Drawing.Point(104, 102);
            this.cbnnguoighi.Name = "cbnnguoighi";
            this.cbnnguoighi.Size = new System.Drawing.Size(176, 21);
            this.cbnnguoighi.TabIndex = 3;
            // 
            // UcTienphat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UcTienphat";
            this.Size = new System.Drawing.Size(826, 410);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcmucphat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.gBmucphat.ResumeLayout(false);
            this.gBmucphat.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctienphat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.gbNguoiphat.ResumeLayout(false);
            this.gbNguoiphat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gcmucphat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gctienphat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.GroupBox gbNguoiphat;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbntenmuc;
        private System.Windows.Forms.ComboBox cbntenngbiphat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private System.Windows.Forms.GroupBox gBmucphat;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtgiatri;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbnnguoighi;
        private System.Windows.Forms.Label label8;
    }
}
