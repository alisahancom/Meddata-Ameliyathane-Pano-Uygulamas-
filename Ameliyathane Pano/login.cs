using System;
using System.Data.OracleClient;
using System.Threading;
using System.Windows.Forms;

namespace Ameliyathane_Pano
{
    public partial class login : DevExpress.XtraEditors.XtraForm
    {
        public login()
        {
            InitializeComponent();
        }

        private OracleConnection con = new OracleConnection();
        private OracleCommand sql = new OracleCommand();
        private OracleDataAdapter da = new OracleDataAdapter();

        private Ameliyathane_Pano.Home f_home;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string con_sql;
            try
            {
                con.ConnectionString = "User Id=" + textEdit1.Text + ";Password=" + textEdit2.Text + "; Data Source=" + textEdit3.Text + "";
                con.Open();
                try
                {
                    sql = new OracleCommand("select count(*) from hastane.ASAHAN_PANO ", con
                          );
                    sql.ExecuteScalar().ToString();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Tablo ve Scriptler Eksik.Ufak Bir Düzeltme Yapılacak", "Bilgilendirme Mesajı >>> Script Ekleniyor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    v_duzeltme_yap1();
                }

                con_sql = "User Id=" + textEdit1.Text + ";Password=" + textEdit2.Text + "; Data Source=" + textEdit3.Text + "";
                f_home = new Ameliyathane_Pano.Home();
                f_home.f_login = this;
                f_home.con_sql = con_sql;
                f_home.Show();
                this.Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void v_duzeltme_yap1()
        {
            try
            {
                sql = new OracleCommand(
                        "CREATE TABLE HASTANE.ASAHAN_PANO " +
                         "( " +
                          "ID        NUMBER, " +
                          "HASTA     VARCHAR2(149 BYTE), " +
                          "PROTOKOL  NUMBER, " +
                          "SERVIS    VARCHAR2(150 BYTE), " +
                          "YENI    VARCHAR2(1 BYTE), " +

                          "DURUMU    VARCHAR2(25 BYTE), " +
                          "KODU      NUMBER)", con);
                sql.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
            }

            try
            {
                sql = new OracleCommand(
                       " CREATE TABLE HASTANE.ASAHAN_PANO_AYARLAR " +
                       " ( " +
                       " ID         NUMBER, " +
                       " TUR        VARCHAR2(25 BYTE), " +
                       " DOSYA_ADI  VARCHAR2(50 BYTE), " +
                       " TIME       NUMBER, " +
                       "HASTA_ISMI    VARCHAR2(1 BYTE), " +
                       " DURUMU     VARCHAR2(1 BYTE) )", con);
                sql.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
            }
            sql = new OracleCommand("insert into  HASTANE.ASAHAN_PANO_AYARLAR (id,tur,dosya_adi,time,durumu) values (1,1,'a.mp4',1,'A')", con);
            sql.ExecuteNonQuery();

            try
            {
                sql = new OracleCommand(
                       " CREATE SEQUENCE HASTANE.ASAHAN_PANO_ID " +
                       " START WITH 1 " +
                       " MAXVALUE 999999999999999999999999999 " +
                       " MINVALUE 1 " +
                       " NOCYCLE " +
                       " NOCACHE " +
                       " NOORDER ", con);
                sql.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
            }
            sql = new OracleCommand("GRANT SELECT ON HASTANE.ASAHAN_PANO_ID TO DOKTOR", con);
            sql.ExecuteNonQuery();
            sql = new OracleCommand("GRANT SELECT ON HASTANE.ASAHAN_PANO_ID TO IDARECI", con);
            sql.ExecuteNonQuery();
            Thread.Sleep(1500);
            MessageBox.Show("Düzeltmeler  Yapıldı.\rİyi Eğlenceler", "Bilgilendirme Mesajı >>> ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alisahan.com");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/wwwalisahancom/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://studio.youtube.com/channel/UCbLk8TxXkFJOXQyaitPMIrg");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alisahan.com");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/alisahancom");
        }
    }
}