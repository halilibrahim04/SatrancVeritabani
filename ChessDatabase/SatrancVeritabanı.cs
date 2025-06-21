using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Database=ChessDatabase;Trusted_Connection=True;";
        private void TurnuvaComboBoxDoldur(ComboBox cmbTurnuva)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TurnuvaID, TurnuvaAdi FROM Turnuvalar ORDER BY TurnuvaAdi", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbTurnuva.DataSource = dt;
                    cmbTurnuva.DisplayMember = "TurnuvaAdi";
                    cmbTurnuva.ValueMember = "TurnuvaID";
                    cmbTurnuva.SelectedIndex = -1; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Turnuva listesi yüklenirken hata: " + ex.Message);
            }
        }
        private void OyuncularıGöster(DataGridView veriTablosu)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM OyuncuBilgileri", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    veriTablosu.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void OyunlarıGöster(DataGridView veriTablosu, string oyuncuIsim)
        {
            if (string.IsNullOrWhiteSpace(oyuncuIsim))
            {
                MessageBox.Show("Lütfen bir oyuncu ismi girin.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand findPlayerCmd = new SqlCommand("SELECT FideID FROM Oyuncular WHERE CONCAT(Isim, ' ', Soyisim) = @OyuncuIsim", conn);
                    findPlayerCmd.Parameters.AddWithValue("@OyuncuIsim", oyuncuIsim.Trim());
                    object result = findPlayerCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Girilen isimle eşleşen oyuncu bulunamadı.");
                        return;
                    }

                    int fideID = Convert.ToInt32(result);

                    SqlCommand cmd = new SqlCommand("OyuncununOyunlariniListele", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FideID", SqlDbType.Int).Value = fideID;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Bu oyuncuya ait oyun bulunamadı.");
                        return;
                    }

                    veriTablosu.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void TurnuvaİstatistikleriniGöster(DataGridView veriTablosu, ComboBox cmbTurnuva)
        {
            if (cmbTurnuva.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir turnuva seçin.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("TurnuvaIstatistikleri", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TurnuvaID", SqlDbType.Int).Value = cmbTurnuva.SelectedValue;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    veriTablosu.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void btnTurnuvaİstatistikleri_Click(object sender, EventArgs e)
        {
            TurnuvaİstatistikleriniGöster(dgvVeriTablosu, cmbTurnuva);
        }

        private void btnOyuncularıGöster_Click(object sender, EventArgs e)
        {
            OyuncularıGöster(dgvVeriTablosu);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TurnuvaComboBoxDoldur(cmbTurnuva);
        }

        private void btnOyunlarıGoster_Click(object sender, EventArgs e)
        {
            OyunlarıGöster(dgvVeriTablosu, txtOyuncuIsim.Text);
        }

        private void btnYeniOyuncuEkle_Click(object sender, EventArgs e)
        {
            OyuncuIslemleri yenioyuncuekle = new OyuncuIslemleri();
            yenioyuncuekle.Show();
            this.Hide();
        }

        private void btnYeniOyunEkle_Click(object sender, EventArgs e)
        {
            TurnuvaOyunIslemleri yenioyunekle = new TurnuvaOyunIslemleri();
            yenioyunekle.Show();
            this.Hide();
        }
    }
}
