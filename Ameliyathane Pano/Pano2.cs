using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ameliyathane_Pano
{
    public partial class Pano2 : DevExpress.XtraEditors.XtraForm
    {
        public Pano2()
        {
            InitializeComponent();
        }

        private OracleConnection con = new OracleConnection();
        private OracleCommand sql = new OracleCommand();
        private OracleDataAdapter da = new OracleDataAdapter();
        public Ameliyathane_Pano.Home f_home;
        public string con_sql;
        private string dosya_adi, reklam_durumu;
        private int reklam_girme_suresi;

        public void v_pano_guncelle()
        {
            if (hasta_ismi == "T")
            {
                sql = new OracleCommand(
                    "select rpad(upper(substr(k.adi, 0, 3)), length(k.adi), '*') || ' ' ||rpad(upper(substr(k.soyadi, 0, 3)), length(k.soyadi), '*') HASTA,k.soyadi, a.HASTA, a.SERVIS, a.DURUMU, a.KODU " +
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

            int kodu;
            kodu = 0;
            if (hasta_ismi == "T")
            {
                sql = new OracleCommand(
                    "select rpad(upper(substr(k.adi, 0, 3)), length(k.adi), '*') || ' ' ||rpad(upper(substr(k.soyadi, 0, 3)), length(k.soyadi), '*') HASTA,k.soyadi, a.HASTA, a.SERVIS, a.DURUMU, a.KODU " +
                    " from hastane.asahan_pano a, hastane.protokol p, hastane.kimlik k where a.protokol = p.protokol_no and p.dosya_no = k.dosya_no and a.yeni='T' ORDER BY ID DESC", con);
            }
            else
            {
                sql = new OracleCommand("select HASTA,SERVIS,DURUMU,KODU from hastane.asahan_pano  where yeni='T' ORDER BY ID DESC ", con);
            }

            OracleDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                h_adi.Text = dr["hasta"].ToString();
                h_servisi.Text = dr["servis"].ToString();
                h_durumu.Text = dr["durumu"].ToString();
                kodu =Convert.ToInt32( dr["kodu"].ToString());
            }
            if (kodu == 1)
            {
                h_durumu.Appearance.BackColor = Color.Black ;
                h_durumu.ForeColor = Color.Gray;


            }
            if (kodu == 2)
            {
                h_durumu.Appearance.BackColor = Color.Black;
                h_durumu.ForeColor = Color.White;
            }
            if (kodu == 3)
            {
                h_durumu.Appearance.BackColor = Color.Black;
                h_durumu.ForeColor = Color.Yellow;
            }

            if (kodu == 4)
            {
                h_durumu.Appearance.BackColor = Color.Black;
                h_durumu.ForeColor = Color.Green;
            }
            if (kodu == 5)
            {
                h_durumu.Appearance.BackColor = Color.Black;
                h_durumu.ForeColor = Color.HotPink;
            }
            if (kodu == 6)
            {
                h_durumu.Appearance.BackColor = Color.Black;
                h_durumu.ForeColor = Color.HotPink;
            }

            sql = new OracleCommand("update hastane.asahan_pano set yeni='F'", con);
            sql.ExecuteNonQuery();
        }


        private void Pano2_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;

            //MessageBox.Show(Screen.PrimaryScreen.Bounds.Width.ToString() + " x " +
            //   Screen.PrimaryScreen.Bounds.Height.ToString());

            axWindowsMediaPlayer1.uiMode = "None";
            //axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            axWindowsMediaPlayer1.Width = 640;
            axWindowsMediaPlayer1.Height = 360;
            axWindowsMediaPlayer1.stretchToFit = true;
            g_reklam.Height = 330;

            ekran_w = Screen.PrimaryScreen.Bounds.Width;
            ekran_h = Screen.PrimaryScreen.Bounds.Height;
            //groupControl2.Width = 60;
            g_hasta_listesi.Width = ekran_w - g_sol_menu.Width;
            g_duyurular.Height = ekran_h - g_reklam.Height;
            ekran_h = 0;
            reklam_girme_suresi = 0;
            dosya_adi = "";
            reklam_durumu = "";
            tama_ekran_mi = "F";
            try
            {
                con.ConnectionString = con_sql;
                //con.ConnectionString = "User Id=hastane;Password=hastane; Data Source=orcl";
                con.Open();
                sql = new OracleCommand("select * from hastane.ASAHAN_PANO_AYARLAR", con);
                OracleDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    dosya_adi = dr["DOSYA_ADI"].ToString();
                    reklam_girme_suresi = Convert.ToInt32(dr["TIME"].ToString()) * 60;
                    reklam_durumu = dr["DURUMU"].ToString();

                    if (dr["HASTA_ISMI"].ToString() == "T")
                    {
                        hasta_ismi = "T";
                    }
                    else
                    {
                        hasta_ismi = "F";
                    }
                }

                v_pano_guncelle();

                axWindowsMediaPlayer1.URL = dosya_adi;
                axWindowsMediaPlayer1.settings.autoStart = true;
                axWindowsMediaPlayer1.settings.setMode("loop", true);


            }
            catch (Exception hata)
            {
                MessageBox.Show("Pano Ayarları Okunamadı/r Lütfen Bilgi işlem birimi ile görüşünüz");
                return;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
        }

        private int ekran_w, ekran_h;

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = dosya_adi;

            reklami_durumu.Enabled = true;
            tama_ekran_mi = "F";
            hasta_ismi = "F";
            Baslat_Durdur.Enabled = false;
            gridView1.BestFitColumns();
        }

        private int sayac;

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

                reklami_durumu.Enabled = false;
                Baslat_Durdur.Enabled = true;
            }
        }

        private void Baslat_Durdur_Tick(object sender, EventArgs e)
        {
           

                
            
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
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

        private void h_durumu_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private string tama_ekran_mi, hasta_ismi;

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}