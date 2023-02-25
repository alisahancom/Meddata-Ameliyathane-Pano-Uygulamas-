using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ameliyathane_Pano
{
    public partial class pano : DevExpress.XtraEditors.XtraForm
    {
        public pano()
        {
            InitializeComponent();
        }

        private OracleConnection con = new OracleConnection();
        private OracleCommand sql = new OracleCommand();
        private OracleDataAdapter da = new OracleDataAdapter();
        public Ameliyathane_Pano.Home f_home;
        public string con_sql;

        //public Screen GetSecondaryScreen()
        //{
        //    if (Screen.AllScreens.Length == 1)
        //    {
        //        return null;
        //    }
        //    foreach (Screen screen in Screen.AllScreens)
        //    {
        //        if (screen.Primary == false)
        //        {
        //            return screen;
        //        }
        //    }
        //    return null;
        //}

        private string dosya_adi, reklam_durumu;
        private int reklam_girme_suresi;

        private void pano_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            axWindowsMediaPlayer1.uiMode = "None";
            reklam_girme_suresi = 0;
            dosya_adi = "";
            reklam_durumu = "";
            tama_ekran_mi = "F";
            try
            {
                con.ConnectionString = con_sql;

                con.Open();
                sql = new OracleCommand("select * from hastane.ASAHAN_PANO_AYARLAR", con);
                OracleDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    dosya_adi = dr["DOSYA_ADI"].ToString();
                    reklam_girme_suresi = Convert.ToInt32(dr["TIME"].ToString()) * 60;
                    reklam_durumu = dr["DURUMU"].ToString();
                    
                    if (dr["HASTA_ISMI"].ToString()=="T")
                    {
                        hasta_ismi ="T" ;
                    }
                    else
                    {
                        hasta_ismi ="F" ;
                    }
                }
                v_pano_guncelle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Pano Ayarları Okunamadı/r Lütfen Bilgi işlem birimi ile görüşünüz");
                return;
            }
            this.WindowState = FormWindowState.Maximized;
            tabPane1.SelectedPage = tabNavigationPage1;
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            (gridControl1.KeyboardFocusView as DevExpress.XtraGrid.Views.Grid.GridView).BestFitColumns();
        }

        public void v_pano_guncelle()
        {
            if (hasta_ismi=="T")
            {
                sql = new OracleCommand(
                    "select rpad(upper(substr(k.adi, 0, 3)), length(k.adi), '*') || ' ' ||rpad(upper(substr(k.soyadi, 0, 3)), length(k.soyadi), '*') HASTA,k.soyadi, a.HASTA, a.SERVIS, a.DURUMU, a.KODU "+
                    " from hastane.asahan_pano a, hastane.protokol p, hastane.kimlik k where a.protokol = p.protokol_no and p.dosya_no = k.dosya_no ORDER BY ID DESC", con);
            }
            else
            {
                sql = new OracleCommand("select HASTA,SERVIS,DURUMU,KODU from hastane.asahan_pano ORDER BY ID DESC ", con);
            }
            
            da = new OracleDataAdapter(sql);
            DataTable dt_pano = new DataTable();
            da.Fill(dt_pano);
            gridControl1.MainView = gridView1;
            gridControl1.DataSource = dt_pano;
        }

        private void gridControl1_StyleChanged(object sender, EventArgs e)
        {
        }

        private void tabNavigationPage2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void gridView1_RowStyle_1(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                //1  Hazırlık
                //2  Ameliyatta
                //3  Ameliyat Sonlandı
                //4  Servise Gönderildi
                //5  Doğumda
                //6  Doğum Sonlandı

                int kodu = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["KODU"]));
                if (kodu == 1)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.Gray;
                }
                if (kodu == 2)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White;
                }
                if (kodu == 3)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.Yellow;
                }

                if (kodu == 4)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.Green;
                }
                if (kodu == 5)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.HotPink;
                }
                if (kodu == 6)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.HotPink;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private int sayac;

        private void Baslat_Durdur_Tick(object sender, EventArgs e)
        {
            sayac = sayac + 1;
            //pano.ActiveForm.Text = "Pano >>" + sayac.ToString();
            if (sayac == reklam_girme_suresi)
            {
                tabPane1.SelectedPage = tabNavigationPage2;
                axWindowsMediaPlayer1.URL = dosya_adi;
                reklami_durumu.Enabled = true;
                tama_ekran_mi = "F";
                hasta_ismi = "F";
                Baslat_Durdur.Enabled = false;
            }
        }

        private string tama_ekran_mi,hasta_ismi;

        private void reklami_durumu_Tick(object sender, EventArgs e)
        {
            if (tama_ekran_mi == "F")
            {
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    axWindowsMediaPlayer1.fullScreen = true;
                    tama_ekran_mi = "T";
                }
            }

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)

            {
                sayac = 0;
                tama_ekran_mi = "T";
                tabPane1.SelectedPage = tabNavigationPage1;
                reklami_durumu.Enabled = false;
                Baslat_Durdur.Enabled = true;
            }
        }
    }
}