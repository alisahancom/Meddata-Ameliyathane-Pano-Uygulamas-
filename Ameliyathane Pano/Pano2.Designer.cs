namespace Ameliyathane_Pano
{
    partial class Pano2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pano2));
            this.g_hasta_listesi = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Baslat_Durdur = new System.Windows.Forms.Timer(this.components);
            this.reklami_durumu = new System.Windows.Forms.Timer(this.components);
            this.g_sol_menu = new DevExpress.XtraEditors.GroupControl();
            this.g_reklam = new DevExpress.XtraEditors.GroupControl();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.g_duyurular = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.h_adi = new DevExpress.XtraEditors.SimpleButton();
            this.h_servisi = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.h_durumu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.g_hasta_listesi)).BeginInit();
            this.g_hasta_listesi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_sol_menu)).BeginInit();
            this.g_sol_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_reklam)).BeginInit();
            this.g_reklam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_duyurular)).BeginInit();
            this.g_duyurular.SuspendLayout();
            this.SuspendLayout();
            // 
            // g_hasta_listesi
            // 
            this.g_hasta_listesi.Appearance.BackColor = System.Drawing.Color.Red;
            this.g_hasta_listesi.Appearance.Options.UseBackColor = true;
            this.g_hasta_listesi.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.g_hasta_listesi.Controls.Add(this.gridControl1);
            this.g_hasta_listesi.Dock = System.Windows.Forms.DockStyle.Right;
            this.g_hasta_listesi.Location = new System.Drawing.Point(532, 0);
            this.g_hasta_listesi.Name = "g_hasta_listesi";
            this.g_hasta_listesi.ShowCaption = false;
            this.g_hasta_listesi.Size = new System.Drawing.Size(716, 756);
            this.g_hasta_listesi.TabIndex = 0;
            this.g_hasta_listesi.Text = "groupControl1";
            this.g_hasta_listesi.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gridControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(650, 3, 3, 3);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Padding = new System.Windows.Forms.Padding(640, 0, 0, 0);
            this.gridControl1.Size = new System.Drawing.Size(716, 756);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2});
            this.gridView1.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 20F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "HASTA";
            this.gridColumn1.FieldName = "HASTA";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 359;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 20F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 30F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "SERVIS";
            this.gridColumn3.FieldName = "SERVIS";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 295;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 20F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 30F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "DURUMU";
            this.gridColumn4.FieldName = "DURUMU";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 344;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "KODU";
            this.gridColumn2.FieldName = "KODU";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // Baslat_Durdur
            // 
            this.Baslat_Durdur.Enabled = true;
            this.Baslat_Durdur.Interval = 1000;
            this.Baslat_Durdur.Tick += new System.EventHandler(this.Baslat_Durdur_Tick);
            // 
            // reklami_durumu
            // 
            this.reklami_durumu.Interval = 1000;
            this.reklami_durumu.Tick += new System.EventHandler(this.reklami_durumu_Tick);
            // 
            // g_sol_menu
            // 
            this.g_sol_menu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.g_sol_menu.Appearance.Options.UseBackColor = true;
            this.g_sol_menu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.g_sol_menu.Controls.Add(this.g_duyurular);
            this.g_sol_menu.Controls.Add(this.g_reklam);
            this.g_sol_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.g_sol_menu.Location = new System.Drawing.Point(0, 0);
            this.g_sol_menu.Name = "g_sol_menu";
            this.g_sol_menu.ShowCaption = false;
            this.g_sol_menu.Size = new System.Drawing.Size(590, 756);
            this.g_sol_menu.TabIndex = 0;
            this.g_sol_menu.Text = "groupControl2";
            // 
            // g_reklam
            // 
            this.g_reklam.Appearance.BackColor = System.Drawing.Color.Aqua;
            this.g_reklam.Appearance.Options.UseBackColor = true;
            this.g_reklam.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.g_reklam.Controls.Add(this.axWindowsMediaPlayer1);
            this.g_reklam.Location = new System.Drawing.Point(3, 3);
            this.g_reklam.Name = "g_reklam";
            this.g_reklam.ShowCaption = false;
            this.g_reklam.Size = new System.Drawing.Size(584, 340);
            this.g_reklam.TabIndex = 1;
            this.g_reklam.Text = "groupControl3";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(2, 2);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(580, 336);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            // 
            // g_duyurular
            // 
            this.g_duyurular.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.g_duyurular.Appearance.Options.UseBackColor = true;
            this.g_duyurular.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.g_duyurular.Controls.Add(this.h_durumu);
            this.g_duyurular.Controls.Add(this.simpleButton6);
            this.g_duyurular.Controls.Add(this.h_servisi);
            this.g_duyurular.Controls.Add(this.simpleButton4);
            this.g_duyurular.Controls.Add(this.h_adi);
            this.g_duyurular.Controls.Add(this.simpleButton1);
            this.g_duyurular.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.g_duyurular.Location = new System.Drawing.Point(0, 314);
            this.g_duyurular.Name = "g_duyurular";
            this.g_duyurular.ShowCaption = false;
            this.g_duyurular.Size = new System.Drawing.Size(590, 442);
            this.g_duyurular.TabIndex = 2;
            this.g_duyurular.Text = "groupControl4";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton1.Location = new System.Drawing.Point(2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(586, 54);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "HASTA ADI";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // h_adi
            // 
            this.h_adi.Appearance.BackColor = System.Drawing.Color.Red;
            this.h_adi.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.h_adi.Appearance.ForeColor = System.Drawing.Color.White;
            this.h_adi.Appearance.Options.UseBackColor = true;
            this.h_adi.Appearance.Options.UseFont = true;
            this.h_adi.Appearance.Options.UseForeColor = true;
            this.h_adi.Dock = System.Windows.Forms.DockStyle.Top;
            this.h_adi.Location = new System.Drawing.Point(2, 56);
            this.h_adi.Name = "h_adi";
            this.h_adi.Size = new System.Drawing.Size(586, 54);
            this.h_adi.TabIndex = 7;
            // 
            // h_servisi
            // 
            this.h_servisi.Appearance.BackColor = System.Drawing.Color.White;
            this.h_servisi.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.h_servisi.Appearance.ForeColor = System.Drawing.Color.Red;
            this.h_servisi.Appearance.Options.UseBackColor = true;
            this.h_servisi.Appearance.Options.UseFont = true;
            this.h_servisi.Appearance.Options.UseForeColor = true;
            this.h_servisi.Dock = System.Windows.Forms.DockStyle.Top;
            this.h_servisi.Location = new System.Drawing.Point(2, 164);
            this.h_servisi.Name = "h_servisi";
            this.h_servisi.Size = new System.Drawing.Size(586, 54);
            this.h_servisi.TabIndex = 9;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton4.Appearance.Options.UseBackColor = true;
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Appearance.Options.UseForeColor = true;
            this.simpleButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton4.Location = new System.Drawing.Point(2, 110);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(586, 54);
            this.simpleButton4.TabIndex = 8;
            this.simpleButton4.Text = "SERVISI";
            // 
            // simpleButton6
            // 
            this.simpleButton6.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton6.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton6.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton6.Appearance.Options.UseBackColor = true;
            this.simpleButton6.Appearance.Options.UseFont = true;
            this.simpleButton6.Appearance.Options.UseForeColor = true;
            this.simpleButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton6.Location = new System.Drawing.Point(2, 218);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(586, 54);
            this.simpleButton6.TabIndex = 10;
            this.simpleButton6.Text = "DURUMU";
            // 
            // h_durumu
            // 
            this.h_durumu.Appearance.BackColor = System.Drawing.Color.Red;
            this.h_durumu.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.h_durumu.Appearance.ForeColor = System.Drawing.Color.White;
            this.h_durumu.Appearance.Options.UseBackColor = true;
            this.h_durumu.Appearance.Options.UseFont = true;
            this.h_durumu.Appearance.Options.UseForeColor = true;
            this.h_durumu.Dock = System.Windows.Forms.DockStyle.Top;
            this.h_durumu.Location = new System.Drawing.Point(2, 272);
            this.h_durumu.Name = "h_durumu";
            this.h_durumu.Size = new System.Drawing.Size(586, 54);
            this.h_durumu.TabIndex = 12;
            this.h_durumu.Click += new System.EventHandler(this.h_durumu_Click);
            // 
            // Pano2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 756);
            this.Controls.Add(this.g_sol_menu);
            this.Controls.Add(this.g_hasta_listesi);
            this.Name = "Pano2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pano2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pano2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.g_hasta_listesi)).EndInit();
            this.g_hasta_listesi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_sol_menu)).EndInit();
            this.g_sol_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g_reklam)).EndInit();
            this.g_reklam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_duyurular)).EndInit();
            this.g_duyurular.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl g_hasta_listesi;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Timer Baslat_Durdur;
        private System.Windows.Forms.Timer reklami_durumu;
        private DevExpress.XtraEditors.GroupControl g_sol_menu;
        private DevExpress.XtraEditors.GroupControl g_reklam;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private DevExpress.XtraEditors.GroupControl g_duyurular;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraEditors.SimpleButton h_servisi;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton h_adi;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton h_durumu;
    }
}