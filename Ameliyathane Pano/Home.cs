using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Ameliyathane_Pano
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private OracleConnection con = new OracleConnection();
        private OracleCommand sql = new OracleCommand();
        private OracleDataAdapter da = new OracleDataAdapter();

        public login f_login;
        public Ameliyathane_Pano.pano f_pano;
        public Ameliyathane_Pano.Pano2 f_pano2;

        public MySqlConnection conx = new MySqlConnection();

        public MySqlCommand sqlx = new MySqlCommand();
        public MySqlDataAdapter dax = new MySqlDataAdapter();
        public string ip_adresi;
        public string pcadi;
        public int video_izlenme_suresi;
        public int gunde_kac_izle;
        public int gunde_kac_izle_local;

        public string con_sql;

        private void Home_Load(object sender, EventArgs e)
        {
            gridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView2.OptionsSelection.EnableAppearanceHideSelection = false;
            gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;

            hasta_ismi = "F";


            try
            {
                // con_sql = "User Id=hastane;Password=hastane; Data Source=srket";
                con.ConnectionString = con_sql;
                // con.ConnectionString = "User Id=hastane;Password=hastane; Data Source=srket";
                con.Open();
                database_list();
                v_reklam_oku();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

                con.Close();
            }
            v_video_izle();
        }
        string demo,  tesis_kodu;
        private void v_video_izle()
        {
            demo = "T";
            tesis_kodu = "0";
            v_lutfen_bekleyiniz();
            Thread.Sleep(500);

            sql = new OracleCommand("select GSS_TESIS_KODU  from hastane.hastane", con);
            OracleDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                tesis_kodu = dr["GSS_TESIS_KODU"].ToString();
            }
            if (tesis_kodu== "12060012")           
            { 
                demo = "F";
                bekleme_paneli_islem = "alisahan.com Yardımcı Uygulamalar";

                SplashScreenManager.Default.SetWaitFormCaption(bekleme_paneli_islem);
                SplashScreenManager.Default.SetWaitFormDescription("Durum Bilgisi:    Lütfen Bekleyin");
                Thread.Sleep(1500);
                SplashScreenManager.CloseForm(false);
            
            }
            

            if (demo == "F")
            {

            }
            else
            {


                bekleme_paneli_islem = "Demo Sürüm ile Devam Ediliyor";

                SplashScreenManager.Default.SetWaitFormCaption(bekleme_paneli_islem);
                SplashScreenManager.Default.SetWaitFormDescription("Durum Bilgisi:    Lütfen Bekleyin");
                Thread.Sleep(3000);
                SplashScreenManager.CloseForm(false);
            }
        }

        private void database_list()
        {
            try
            {
                sql = new OracleCommand(
               "select  " +

               "kk.adi || ' ' || kk.soyadi hasta,  " +
               "kk.dosya_no dosya,  " +
               "pp.protokol_no protokol,  " +
               "(select adi_soyadi from hastane.dradi where dr_kodu = pp.dr_kodu) Doktor,   " +
               "BB.BOLUM_ADI Bolum,  " +
               "SS.SERVIS_ADI,  " +
               "YY.ODA_NO,  " +
               "YY.YATAK_NO  " +

               "from hastane.yatan yy, hastane.protokol pp, hastane.bolum bb, hastane.servisler ss, hastane.kimlik kk where yy.durum = 'Y' and  " +
               "YY.PROTOKOL_NO(+) = pp.protokol_no  " +
               "and YY.SERVIS_NO = SS.SERVIS_NO  " +
               "and pp.bolum = bb.bolum  " +
               "and pp.dosya_no = kk.dosya_no", con);
                da = new OracleDataAdapter(sql);
                DataTable dt_liste = new DataTable();
                da.Fill(dt_liste);
                gridControl1.MainView = gridView1;
                gridControl1.DataSource = dt_liste;
                gridView1.OptionsView.ShowFooter = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length > 1)
            {
                if (pano_tipi ==1)
                {

               
                f_pano = new Ameliyathane_Pano.pano();
                f_pano.f_home = this;
                f_pano.con_sql = con_sql;

                // Important !
                f_pano.StartPosition = FormStartPosition.Manual;

                // Get the second monitor screen
                Screen screen = GetSecondaryScreen();

                // set the location to the top left of the second screen
                f_pano.Location = screen.WorkingArea.Location;

                // set it fullscreen
                f_pano.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);

                // Show the form
                f_pano.Show();

                }
                if (pano_tipi == 2)
                {


                    f_pano2 = new Ameliyathane_Pano.Pano2();
                    f_pano2.f_home = this;
                    f_pano2.con_sql = con_sql;

                    // Important !
                    f_pano2.StartPosition = FormStartPosition.Manual;

                    // Get the second monitor screen
                    Screen screen = GetSecondaryScreen();

                    // set the location to the top left of the second screen
                    f_pano2.Location = screen.WorkingArea.Location;

                    // set it fullscreen
                    f_pano2.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);

                    // Show the form
                    f_pano2.Show();

                }
            }
            else
            {
                if (pano_tipi == 1)
                {
                    f_pano = new Ameliyathane_Pano.pano();
                    f_pano.f_home = this;
                    f_pano.con_sql = con_sql;
                    f_pano.Show();
                }
                if (pano_tipi == 2)
                {
                    f_pano2 = new Ameliyathane_Pano.Pano2();
                    f_pano2.f_home = this;
                    f_pano2.con_sql = con_sql;
                    f_pano2.Show();
                }
            }
        }

        public Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }
            return null;
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ((DataTable)gridControl1.DataSource).DefaultView.RowFilter = "HASTA like '%" + textEdit1.Text.Trim() + "%'";
            if (gridView2.RowCount > 0)
            {
                ((DataTable)gridControl2.DataSource).DefaultView.RowFilter = "HASTA like '%" + textEdit1.Text.Trim() + "%'";
            }

            label8.Text = "#" + gridView1.RowCount.ToString();
            Update();
        }

        public string hasta, dosya, protokol, doktor, bolum, servis, oda, yatak;

        private void tabPane2_Click(object sender, EventArgs e)
        {
            database_list();

            v_pano_hastalari_getir();
        }

        private void v_pano_hastalari_getir()
        {
            sql = new OracleCommand("select HASTA,PROTOKOL,SERVIS,DURUMU,KODU from hastane.ASAHAN_PANO ", con);
            da = new OracleDataAdapter(sql);
            DataTable dt_pano = new DataTable();
            da.Fill(dt_pano);
            gridControl2.MainView = gridView2;
            gridControl2.DataSource = dt_pano;
        }

        private void tabPane1_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pana_veri_gonder();
        }

        private void pana_veri_gonder()
        {
            try
            {
                if (comboBoxEdit1.Text == "Durum Seç")
                {
                    MessageBox.Show("Durum Bilgisi  Seçilmeden Panoya Hasta Gönderilemez");
                    return;
                }

                sql = new OracleCommand("select nvl(count(*),0) alan from hastane.asahan_pano where protokol=" + protokol, con);

                if (sql.ExecuteScalar().ToString() != "0")
                {
                    MessageBox.Show("Hasta Zaten Panoda Durum Bilgisini Güncelleyiniz.");
                    tabPane2.SelectedPage = tabNavigationPage4;
                    return;
                }

                //1  Hazırlık
                //2  Ameliyatta
                //3  Ameliyat Sonlandı
                //4  Servise Gönderildi
                //5  Doğumda
                //6  Doğum Sonlandı
                int durumu;
                durumu = 0;
                switch (comboBoxEdit1.Text)
                {
                    case "Hazırlık": durumu = 1; break;
                    case "Ameliyatta": durumu = 2; break;
                    case "Ameliyat Sonlandı": durumu = 3; break;
                    case "Servise Gönderildi": durumu = 4; break;

                    case "Doğumda": durumu = 5; break;
                    case "Doğum Sonlandı": durumu = 6; break;
                }
               
                
                sql = new OracleCommand(
                    "  insert into  hastane.asahan_pano (id, hasta, protokol, servis, durumu, kodu) values " +
                    "(asahan_pano_id.nextval, '" + hasta.ToUpper() + "', '" + protokol + "', '" + servis.ToUpper() + "', '" + comboBoxEdit1.Text + "', " + durumu.ToString() + ")", con);
                sql.ExecuteNonQuery();

                tabPane2.SelectedPage = tabNavigationPage4;
                v_bildirim_gonder();
                v_pano_bilgileri_guncelle();
                v_pano_hastalari_getir();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void v_bildirim_gonder()
        {
            yeni_durum f_yeni_durum = new yeni_durum();
            try
            {
                Screen screen = GetSecondaryScreen();
                f_yeni_durum.Location = screen.WorkingArea.Location;
            }
            catch (Exception)
            {
                MessageBox.Show("2.Monitör Tespit Edilemdi");
            }

            v_lutfen_bekleyiniz();
            Thread.Sleep(500);
            bekleme_paneli_islem = hasta.ToUpper();
            bekleme_paneli_durum = comboBoxEdit1.Text.ToUpper();
            SplashScreenManager.Default.SetWaitFormCaption("Hasta Güncelleme :" + bekleme_paneli_islem);
            SplashScreenManager.Default.SetWaitFormDescription("Durum Bilgisi:" + bekleme_paneli_durum);
            Thread.Sleep(500);
            SplashScreenManager.CloseForm(false);
        }

        public string bekleme_paneli_islem, bekleme_paneli_durum;

        private void v_lutfen_bekleyiniz()
        {
            Thread thread = new Thread(new ThreadStart(v_bekleme_paneli_ac));
            thread.Start();
        }

        private void v_bekleme_paneli_ac()
        {
            SplashScreenManager.ShowForm(this, typeof(yeni_durum), true, true, false);
        }

        public int protokol_guncelle;

        private void hazırlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                protokol_guncelle = Convert.ToInt32(gridView2.GetFocusedRowCellValue("PROTOKOL").ToString());
                
                sql = new OracleCommand("update hastane.asahan_pano set durumu='HAZIRLIK', kodu=1,yeni='T' where protokol=" + protokol_guncelle, con);
                sql.ExecuteNonQuery();

                v_pano_tablosu_guncelle();
                v_pano_bilgileri_guncelle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void ameliyattaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                protokol_guncelle = Convert.ToInt32(gridView2.GetFocusedRowCellValue("PROTOKOL").ToString());

                sql = new OracleCommand("update hastane.asahan_pano set durumu='AMELIYATTA', kodu=2, yeni='T' where protokol=" + protokol_guncelle, con);
                sql.ExecuteNonQuery();

                v_pano_tablosu_guncelle();
                v_pano_bilgileri_guncelle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void ameliyatSonlandıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                protokol_guncelle = Convert.ToInt32(gridView2.GetFocusedRowCellValue("PROTOKOL").ToString());

                sql = new OracleCommand("update hastane.asahan_pano set durumu='AMELIYAT SONLANDI', kodu=3, yeni='T' where protokol=" + protokol_guncelle, con);
                sql.ExecuteNonQuery();
                v_pano_tablosu_guncelle();
                v_pano_bilgileri_guncelle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void serviseGönderildiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                protokol_guncelle = Convert.ToInt32(gridView2.GetFocusedRowCellValue("PROTOKOL").ToString());

                sql = new OracleCommand("update hastane.asahan_pano set durumu='SERVISE GONDERILDI', kodu=4 , yeni='T' where protokol=" + protokol_guncelle, con);
                sql.ExecuteNonQuery();

                v_pano_tablosu_guncelle();
                v_pano_bilgileri_guncelle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                protokol_guncelle = Convert.ToInt32(gridView2.GetFocusedRowCellValue("PROTOKOL").ToString());

                sql = new OracleCommand("delete from hastane.asahan_pano where protokol=" + protokol_guncelle, con);
                sql.ExecuteNonQuery();
                v_pano_tablosu_guncelle();
                v_pano_bilgileri_guncelle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void v_pano_bilgileri_guncelle()
        {
            if (Application.OpenForms["pano"] != null)
            {
                f_pano.v_pano_guncelle();
                
            }
            if (Application.OpenForms["Pano2"] != null)
            {
                
                f_pano2.v_pano_guncelle();
            }
            else
            {
            }
        }
        public string hasta_ismi;
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string  aktif;
            int tur;
            tur = 1;
            
            try
            {
                tur = comboBox1.SelectedIndex + 1 ;
                   
                if (checkBox2.Checked==true)
                {
                    hasta_ismi="T";
                }
                else
                {
                    hasta_ismi = "F";
                }
                if (checkBox1.Checked == true)
                {
                    aktif = "A";
                }
                else
                {
                    aktif = "P";
                }

                sql = new OracleCommand("update hastane.asahan_pano_ayarlar set tur='" + tur + "',dosya_adi='" + textEdit2.Text + "',time=" + numericUpDown2.Text + ",durumu='" + aktif + "',hasta_ismi='"+hasta_ismi+"' where id=1", con);
                sql.ExecuteNonQuery();
            }
            catch (Exception)
            {
                sql = new OracleCommand("insert into hastane.asahan_pano_ayarlar (id) values(1)", con);
                sql.ExecuteNonQuery();
            }
        }
        int pano_tipi;
        private void v_reklam_oku()
        {
            pano_tipi = 0;
            sql = new OracleCommand("select * from hastane.asahan_pano_ayarlar where id=1", con);
            OracleDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                
                textEdit2.Text = dr["DOSYA_ADI"].ToString();
                numericUpDown2.Text = dr["TIME"].ToString();
                if (dr["HASTA_ISMI"].ToString()=="T")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }

                if (dr["DURUMU"].ToString() == "A")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                pano_tipi= Convert.ToInt32(dr["tur"].ToString());
                comboBox1.SelectedIndex = pano_tipi - 1;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
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

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/wwwalisahancom/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youtube.com/channel/UCbLk8TxXkFJOXQyaitPMIrg");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alisahan.com");
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/alisahancom");
        }

        private string[] link_listesi = new string[100];
        private int saniye;
        private string link;
        private int video_izleme_araligi, video_izleme_araligi2;

        private void video_izle_Tick(object sender, EventArgs e)
        {
            this.Text = "Ameliyathane Pano Uygulaması >>alisahan.com..>" + video_izleme_araligi.ToString();
            video_izleme_araligi = video_izleme_araligi + 1;
            label13.Text = "Reklama Kalan Süre :" + (1200 - video_izleme_araligi).ToString();

            //reklamlar kapatıldı
            //Site Açma Zorlandı
            //video_izle.Enabled = false;

            if (video_izleme_araligi == 12)
            {
                try
                {
                    var webClient = new WebClient();

                    string dnsString = webClient.DownloadString("http://checkip.dyndns.org");
                    dnsString = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(dnsString).Value;

                    webClient.Dispose();
                    ip_adresi = dnsString;
                    pcadi = Dns.GetHostName();

                    // MessageBox.Show(Dns.GetHostName());
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
                try
                {
                    conx = new MySqlConnection("server=188.121.44.183;database=youtube;user id=UserYoutube;password=Yo01012020*-%&;port=3306;SslMode=none");
                    conx.Open();
                    //MessageBox.Show("Ok");
                    sqlx = new MySqlCommand("select video_izle_durumu from setting where id=1", conx);

                    sqlx = new MySqlCommand("select * from video where aktif='A'", conx);
                    MySqlDataReader dr = sqlx.ExecuteReader();

                    int link_say;
                    int video_sayisi_web;
                    link_say = 0;
                    while (dr.Read())
                    {
                        link_listesi[link_say] = dr["link"].ToString();
                        link_say = +link_say + 1;
                    }
                    dr.Close();
                    Random rasgele = new Random();
                    int oku = rasgele.Next(link_say);
                    //MessageBox.Show(link_listesi[oku].ToString());
                    link = link_listesi[oku].ToString();
                    string html = "<html><head>";
                    html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
                    html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}?autoplay=1&mute=1' width='600' height='300' frameborder='0' allowfullscreen></iframe>";
                    html += "</body></html>";

                    sqlx = new MySqlCommand("select * from setting where id=1", conx);
                    MySqlDataReader dr_setting = sqlx.ExecuteReader();
                    while (dr_setting.Read())
                    {
                        video_izlenme_suresi = Convert.ToInt32(dr_setting["video_izlenme_suresi"].ToString());
                        gunde_kac_izle = Convert.ToInt32(dr_setting["gunde_kac_izle"].ToString());
                    }
                    groupControl3.Visible = true;
                    this.webBrowser1.DocumentText = string.Format(html, link.Split('=')[1]);
                    webBrowser1.ScriptErrorsSuppressed = true;
                    conx.Close();
                    v_kimizledi();
                    //  MessageBox.Show("siste çalışıyor");
                }
                catch (Exception hata)
                {
                    conx.Close();
                    return;
                    // MessageBox.Show(hata.Message);
                }
                video_izleme_araligi = 0;
            }


        }

        private void v_kimizledi()
        {
            try
            {
                conx.Open();
                sqlx = new MySqlCommand("update link set izlendi=izlendi+1 where link='" + link + "' ", conx);
                sqlx.ExecuteNonQuery();
                sqlx = new MySqlCommand("INSERT INTO `kimlerizledi` ( `pc`, `ip`, `lnk`,`tarih`) VALUES ( '" + pcadi + "', '" + ip_adresi + "', '" + link + "','" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "')", conx);
                sqlx.ExecuteNonQuery();
                conx.Close();
                gunde_kac_izle_local = gunde_kac_izle_local + 1;
            }
            catch (Exception hata)
            {
                conx.Close();
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            groupControl3.Visible = false;
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textEdit2.Text == "1560")
                {
                    groupControl3.Visible = true;
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Video Kullanmak İstiyorsanız,\nkullandığınız video dosyasını exe kök dizine kopyayın ve\n adını ise  burada örnek gösterildiği gibi 'reklam.avi' vb\n olarak " +
                "sade dosya adını yazın","Bilgilendirme Mesajı >>> Nasıl Çalışır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            v_hasta_bilgilerini_getir();
            //1  Hazırlık
            //2  Ameliyatta
            //3  Ameliyat Sonlandı
            //4  Servise Gönderildi
            //5  Doğumda
            //6  Doğum Sonlandı

            sql = new OracleCommand(
                   "  insert into  hastane.asahan_pano (id, hasta, protokol, servis, durumu, kodu,yeni) values " +
                   "(hastane.asahan_pano_id.nextval, '" + hasta.ToUpper() + "', '" + protokol + "', '" + servis.ToUpper() + "', 'Hazırlıkta', 1,'T')", con);
            sql.ExecuteNonQuery();

            v_bildirim_gonder();
            v_pano_bilgileri_guncelle();
            v_pano_hastalari_getir();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            v_hasta_bilgilerini_getir();
            //1  Hazırlık
            //2  Ameliyatta
            //3  Ameliyat Sonlandı
            //4  Servise Gönderildi
            //5  Doğumda
            //6  Doğum Sonlandı

            sql = new OracleCommand(
                   "  insert into  hastane.asahan_pano (id, hasta, protokol, servis, durumu, kodu,yeni) values " +
                   "(hastane.asahan_pano_id.nextval, '" + hasta.ToUpper() + "', '" + protokol + "', '" + servis.ToUpper() + "', 'Ameliyatta', 2,'T')", con);
            sql.ExecuteNonQuery();

            v_bildirim_gonder();
            v_pano_bilgileri_guncelle();
            v_pano_hastalari_getir();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            v_hasta_bilgilerini_getir();
            //1  Hazırlık
            //2  Ameliyatta
            //3  Ameliyat Sonlandı
            //4  Servise Gönderildi
            //5  Doğumda
            //6  Doğum Sonlandı

            sql = new OracleCommand(
                   "  insert into  hastane.asahan_pano (id, hasta, protokol, servis, durumu, kodu,yeni) values " +
                   "(hastane.asahan_pano_id.nextval, '" + hasta.ToUpper() + "', '" + protokol + "', '" + servis.ToUpper() + "', 'Ameliyat Sonlandı', 3,'T')", con);
            sql.ExecuteNonQuery();

            v_bildirim_gonder();
            v_pano_bilgileri_guncelle();
            v_pano_hastalari_getir();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            v_hasta_bilgilerini_getir();
            //1  Hazırlık
            //2  Ameliyatta
            //3  Ameliyat Sonlandı
            //4  Servise Gönderildi
            //5  Doğumda
            //6  Doğum Sonlandı

            sql = new OracleCommand(
                   "  insert into  hastane.asahan_pano (id, hasta, protokol, servis, durumu, kodu,yeni) values " +
                   "(hastane.asahan_pano_id.nextval, '" + hasta.ToUpper() + "', '" + protokol + "', '" + servis.ToUpper() + "', 'Servise Gönderildi', 4,'T')", con);
            sql.ExecuteNonQuery();

            v_bildirim_gonder();
            v_pano_bilgileri_guncelle();
            v_pano_hastalari_getir();
        }

        private void doğumdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v_hasta_bilgilerini_getir();
            //1  Hazırlık
            //2  Ameliyatta
            //3  Ameliyat Sonlandı
            //4  Servise Gönderildi
            //5  Doğumda
            //6  Doğum Sonlandı

            sql = new OracleCommand(
                   "  insert into  hastane.asahan_pano (id, hasta, protokol, servis, durumu, kodu,yeni) values " +
                   "(hastane.asahan_pano_id.nextval, '" + hasta.ToUpper() + "', '" + protokol + "', '" + servis.ToUpper() + "', 'Doğumda', 5,'T')", con);
            sql.ExecuteNonQuery();

            v_bildirim_gonder();
            v_pano_bilgileri_guncelle();
            v_pano_hastalari_getir();
        }

        private void doğumSonlandıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v_hasta_bilgilerini_getir();
            //1  Hazırlık
            //2  Ameliyatta
            //3  Ameliyat Sonlandı
            //4  Servise Gönderildi
            //5  Doğumda
            //6  Doğum Sonlandı

            sql = new OracleCommand(
                   "  insert into  hastane.asahan_pano (id, hasta, protokol, servis, durumu, kodu,yeni) values " +
                   "(hastane.asahan_pano_id.nextval, '" + hasta.ToUpper() + "', '" + protokol + "', '" + servis.ToUpper() + "', 'Doğum Sonlandı', 6,'T')", con);
            sql.ExecuteNonQuery();

            v_bildirim_gonder();
            v_pano_bilgileri_guncelle();
            v_pano_hastalari_getir();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alisahan.com");
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length > 1)
            {
                f_pano2 = new Ameliyathane_Pano.Pano2();
                f_pano2.f_home = this;
                f_pano2.con_sql = con_sql;

                // Important !
                f_pano2.StartPosition = FormStartPosition.Manual;

                // Get the second monitor screen
                Screen screen = GetSecondaryScreen();

                // set the location to the top left of the second screen
                f_pano2.Location = screen.WorkingArea.Location;

                // set it fullscreen
                f_pano2.Size = new Size(screen.WorkingArea.Width, screen.WorkingArea.Height);

                // Show the form
                f_pano2.Show();
            }
            else
            {
                f_pano2 = new Ameliyathane_Pano.Pano2();
                f_pano2.f_home = this;
                f_pano2.con_sql = con_sql;
                f_pano2.Show();
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
             
        }

        private void label15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pano Tipi ayarları\nBurada kullanacağınız Pano tipi seçebilirsiniz\nReklam Video'lu yada Vidyosuz gibi\n",  "Bilgilendirme Mesajı >>> Nasıl Çalışır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta İsimlerinde\nİsmin tamamı görmek için seçimi kaldırın\nYada gizlilik uygulayarak sadece ilk harfi gözükmesini istiyorsanız,seçimi aktif edebilirsiniz", "Bilgilendirme Mesajı >>> Nasıl Çalışır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reklam Videosunda Videonun Tekrar Başlaması için geçerli zaman dilimi\n1 dk bir tekrar etmesi için 1 yazmanız yeterli\nYada 5 dk için 5 vb. ", "Bilgilendirme Mesajı >>> Nasıl Çalışır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta İsimlerinde\nGrid içinde her alan hasta font büyüklüğü rakam yazarak belirleye bilirsiniz", "Bilgilendirme Mesajı >>> Nasıl Çalışır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reklam olarak video yada resim göstere bilirsiniz", "Bilgilendirme Mesajı >>> Nasıl Çalışır", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        int demo_say;
        private void t_demo_Tick(object sender, EventArgs e)
        {
            demo_say = demo_say+1;
            //this.Text = demo_say.ToString();
            if (demo_say>1800)
            {
                v_lutfen_bekleyiniz();
                Thread.Sleep(500);
                bekleme_paneli_islem = "Beklenmedik Bir Hata Oluştu";

                SplashScreenManager.Default.SetWaitFormCaption(bekleme_paneli_islem);
                SplashScreenManager.Default.SetWaitFormDescription("Durum Bilgisi:    Pano Kapatılıyor");
                Thread.Sleep(10000);
                SplashScreenManager.CloseForm(false);
              
                Application.Exit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pano_tipi = comboBox1.SelectedIndex + 1;
        }

        private void SiteAc_Tick(object sender, EventArgs e)
        {
            video_izleme_araligi2 = video_izleme_araligi2 + 1;
            if (video_izleme_araligi2 == 1200)
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/wwwalisahancom/");
                System.Diagnostics.Process.Start("https://youtube.com/channel/UCbLk8TxXkFJOXQyaitPMIrg");
                System.Diagnostics.Process.Start("https://www.instagram.com/alisahancom");
                System.Diagnostics.Process.Start("http://www.alisahan.com");
                SiteAc.Enabled = false;
                SiteAc.Stop();
            }
            
        }

        private void v_pano_tablosu_guncelle()
        {
            sql = new OracleCommand("select HASTA,PROTOKOL,SERVIS,DURUMU,KODU from hastane.asahan_pano ", con);
            da = new OracleDataAdapter(sql);
            DataTable dt_pano = new DataTable();
            da.Fill(dt_pano);
            gridControl2.MainView = gridView2;
            gridControl2.DataSource = dt_pano;
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            v_hasta_bilgilerini_getir();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
        }

        private void v_hasta_bilgilerini_getir()
        {
            hasta = "";
            dosya = "";
            protokol = "";
            doktor = "";
            bolum = "";
            servis = "";
            oda = "";
            yatak = "";

            hasta = gridView1.GetFocusedRowCellValue("HASTA").ToString();
            dosya = gridView1.GetFocusedRowCellValue("DOSYA").ToString();
            protokol = gridView1.GetFocusedRowCellValue("PROTOKOL").ToString();
            doktor = gridView1.GetFocusedRowCellValue("DOKTOR").ToString();
            bolum = gridView1.GetFocusedRowCellValue("BOLUM").ToString();
            servis = gridView1.GetFocusedRowCellValue("SERVIS_ADI").ToString();
            oda = gridView1.GetFocusedRowCellValue("ODA_NO").ToString();
            yatak = gridView1.GetFocusedRowCellValue("YATAK_NO").ToString();
            txt_hasta.Text = hasta.ToString();
            txt_dosya_protokol.Text = dosya + " / " + protokol;
            txt_dr_bolum.Text = doktor + " / " + bolum;

            try
            {
                sql = new OracleCommand(
                    " select  " +
                    " IT.ISLEM, IY.OZEL_KOD  " +
                    " from hastane.islemyap iy, hastane.islemtipi it where iy.protokol_no ='" + protokol + "' " +
                    " and iy.fatura_tipi = 0 and iy.ozel_kod like 'P%' and  " +
                    " iy.kodu = it.kodu", con);
                da = new OracleDataAdapter(sql);
                DataTable dt_ameliyat = new DataTable();
                da.Fill(dt_ameliyat);
                dataGridView1.DataSource = dt_ameliyat;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}