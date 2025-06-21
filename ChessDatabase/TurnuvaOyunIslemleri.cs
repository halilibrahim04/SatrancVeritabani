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
    public partial class TurnuvaOyunIslemleri : Form
    {
        public TurnuvaOyunIslemleri()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Database=ChessDatabase;Trusted_Connection=True;";
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbBeyazOyuncu.SelectedValue == null || cmbSiyahOyuncu.SelectedValue == null ||
        cmbOyunSonucu.SelectedValue == null || string.IsNullOrWhiteSpace(txtOyunTarihi.Text) ||
        cmbTurnuva.SelectedValue == null || string.IsNullOrWhiteSpace(txtNotasyon.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun: Beyaz Oyuncu, Siyah Oyuncu, Sonuç, Oyun Tarihi, Turnuva, Notasyon.");
                return;
            }

            if (!DateTime.TryParse(txtOyunTarihi.Text, out DateTime oyunTarihi))
            {
                MessageBox.Show("Oyun Tarihi geçerli bir tarih olmalıdır (YYYY-MM-DD).");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Oyunlar (TurnuvaID, BeyazOyuncuID, SiyahOyuncuID, AcilisKodu, Notasyon, OyunSonucu, OyunTarihi) " +
                                                    "VALUES (@TurnuvaID, @BeyazOyuncuID, @SiyahOyuncuID, @AcilisKodu, @Notasyon, @OyunSonucu, @OyunTarihi)", conn);
                    cmd.Parameters.AddWithValue("@TurnuvaID", SqlDbType.Int).Value = cmbTurnuva.SelectedValue;
                    cmd.Parameters.AddWithValue("@BeyazOyuncuID", SqlDbType.Int).Value = cmbBeyazOyuncu.SelectedValue;
                    cmd.Parameters.AddWithValue("@SiyahOyuncuID", SqlDbType.Int).Value = cmbSiyahOyuncu.SelectedValue;
                    cmd.Parameters.AddWithValue("@AcilisKodu", SqlDbType.Char).Value = cmbAcilis.SelectedValue?.ToString() == "" ? (object)DBNull.Value : cmbAcilis.SelectedValue;
                    cmd.Parameters.AddWithValue("@Notasyon", SqlDbType.Text).Value = txtNotasyon.Text.Trim();
                    cmd.Parameters.AddWithValue("@OyunSonucu", SqlDbType.NVarChar).Value = cmbOyunSonucu.SelectedValue;
                    cmd.Parameters.AddWithValue("@OyunTarihi", SqlDbType.Date).Value = oyunTarihi;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Oyun başarıyla eklendi!");

                    // DataGridView'ı güncelle
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT O.OyunID, O.TurnuvaID, T.TurnuvaAdi, O.BeyazOyuncuID, " +
                                                                "B.Isim + ' ' + B.Soyisim AS BeyazAdSoyad, O.SiyahOyuncuID, " +
                                                                "S.Isim + ' ' + S.Soyisim AS SiyahAdSoyad, O.AcilisKodu, A.AcilisAdi, " +
                                                                "O.Notasyon, O.OyunSonucu, O.OyunTarihi " +
                                                                "FROM Oyunlar O " +
                                                                "JOIN Turnuvalar T ON O.TurnuvaID = T.TurnuvaID " +
                                                                "JOIN Oyuncular B ON O.BeyazOyuncuID = B.FideID " +
                                                                "JOIN Oyuncular S ON O.SiyahOyuncuID = S.FideID " +
                                                                "LEFT JOIN Acilislar A ON O.AcilisKodu = A.AcilisKodu", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvVeriTablosu.DataSource = dt;

                    // Formu temizle
                    cmbBeyazOyuncu.SelectedIndex = -1;
                    cmbSiyahOyuncu.SelectedIndex = -1;
                    cmbOyunSonucu.SelectedIndex = -1;
                    txtOyunTarihi.Clear();
                    cmbTurnuva.SelectedIndex = -1;
                    cmbAcilis.SelectedIndex = 0;
                    txtNotasyon.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvVeriTablosu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir oyun seçin.");
                return;
            }

            int oyunID = Convert.ToInt32(dgvVeriTablosu.SelectedRows[0].Cells[0].Value);
            if (MessageBox.Show($"Oyun ID: {oyunID} olan oyun silinsin mi?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Oyunlar WHERE OyunID = @OyunID", conn);
                        cmd.Parameters.AddWithValue("@OyunID", SqlDbType.Int).Value = oyunID;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Oyun başarıyla silindi!");

                        // DataGridView'ı güncelle
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT O.OyunID, O.TurnuvaID, T.TurnuvaAdi, O.BeyazOyuncuID, " +
                                                                    "B.Isim + ' ' + B.Soyisim AS BeyazAdSoyad, O.SiyahOyuncuID, " +
                                                                    "S.Isim + ' ' + S.Soyisim AS SiyahAdSoyad, O.AcilisKodu, A.AcilisAdi, " +
                                                                    "O.Notasyon, O.OyunSonucu, O.OyunTarihi " +
                                                                    "FROM Oyunlar O " +
                                                                    "JOIN Turnuvalar T ON O.TurnuvaID = T.TurnuvaID " +
                                                                    "JOIN Oyuncular B ON O.BeyazOyuncuID = B.FideID " +
                                                                    "JOIN Oyuncular S ON O.SiyahOyuncuID = S.FideID " +
                                                                    "LEFT JOIN Acilislar A ON O.AcilisKodu = A.AcilisKodu", conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvVeriTablosu.DataSource = dt;

                        // Formu temizle
                        cmbBeyazOyuncu.SelectedIndex = -1;
                        cmbSiyahOyuncu.SelectedIndex = -1;
                        cmbOyunSonucu.SelectedIndex = -1;
                        txtOyunTarihi.Clear();
                        cmbTurnuva.SelectedIndex = -1;
                        cmbAcilis.SelectedIndex = 0;
                        txtNotasyon.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvVeriTablosu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir oyun seçin.");
                return;
            }

            if (cmbBeyazOyuncu.SelectedValue == null || cmbSiyahOyuncu.SelectedValue == null ||
                cmbOyunSonucu.SelectedValue == null || string.IsNullOrWhiteSpace(txtOyunTarihi.Text) ||
                cmbTurnuva.SelectedValue == null || string.IsNullOrWhiteSpace(txtNotasyon.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun: Beyaz Oyuncu, Siyah Oyuncu, Sonuç, Oyun Tarihi, Turnuva, Notasyon.");
                return;
            }

            if (!DateTime.TryParse(txtOyunTarihi.Text, out DateTime oyunTarihi))
            {
                MessageBox.Show("Oyun Tarihi geçerli bir tarih olmalıdır (YYYY-MM-DD).");
                return;
            }

            int oyunID = Convert.ToInt32(dgvVeriTablosu.SelectedRows[0].Cells[0].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Oyunlar SET TurnuvaID = @TurnuvaID, BeyazOyuncuID = @BeyazOyuncuID, " +
                                                    "SiyahOyuncuID = @SiyahOyuncuID, AcilisKodu = @AcilisKodu, Notasyon = @Notasyon, " +
                                                    "OyunSonucu = @OyunSonucu, OyunTarihi = @OyunTarihi WHERE OyunID = @OyunID", conn);
                    cmd.Parameters.AddWithValue("@OyunID", SqlDbType.Int).Value = oyunID;
                    cmd.Parameters.AddWithValue("@TurnuvaID", SqlDbType.Int).Value = cmbTurnuva.SelectedValue;
                    cmd.Parameters.AddWithValue("@BeyazOyuncuID", SqlDbType.Int).Value = cmbBeyazOyuncu.SelectedValue;
                    cmd.Parameters.AddWithValue("@SiyahOyuncuID", SqlDbType.Int).Value = cmbSiyahOyuncu.SelectedValue;
                    cmd.Parameters.AddWithValue("@AcilisKodu", SqlDbType.Char).Value = cmbAcilis.SelectedValue?.ToString() == "" ? (object)DBNull.Value : cmbAcilis.SelectedValue;
                    cmd.Parameters.AddWithValue("@Notasyon", SqlDbType.Text).Value = txtNotasyon.Text.Trim();
                    cmd.Parameters.AddWithValue("@OyunSonucu", SqlDbType.NVarChar).Value = cmbOyunSonucu.SelectedValue;
                    cmd.Parameters.AddWithValue("@OyunTarihi", SqlDbType.Date).Value = oyunTarihi;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Oyun başarıyla güncellendi!");

                    // DataGridView'ı güncelle
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT O.OyunID, O.TurnuvaID, T.TurnuvaAdi, O.BeyazOyuncuID, " +
                                                                "B.Isim + ' ' + B.Soyisim AS BeyazAdSoyad, O.SiyahOyuncuID, " +
                                                                "S.Isim + ' ' + S.Soyisim AS SiyahAdSoyad, O.AcilisKodu, A.AcilisAdi, " +
                                                                "O.Notasyon, O.OyunSonucu, O.OyunTarihi " +
                                                                "FROM Oyunlar O " +
                                                                "JOIN Turnuvalar T ON O.TurnuvaID = T.TurnuvaID " +
                                                                "JOIN Oyuncular B ON O.BeyazOyuncuID = B.FideID " +
                                                                "JOIN Oyuncular S ON O.SiyahOyuncuID = S.FideID " +
                                                                "LEFT JOIN Acilislar A ON O.AcilisKodu = A.AcilisKodu", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvVeriTablosu.DataSource = dt;

                    // Formu temizle
                    cmbBeyazOyuncu.SelectedIndex = -1;
                    cmbSiyahOyuncu.SelectedIndex = -1;
                    cmbOyunSonucu.SelectedIndex = -1;
                    txtOyunTarihi.Clear();
                    cmbTurnuva.SelectedIndex = -1;
                    cmbAcilis.SelectedIndex = 0;
                    txtNotasyon.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnAnaSayfayaDon_Click(object sender, EventArgs e)
        {
            Form1 geridon = new Form1();
            geridon.Show();
            this.Hide();
        }

        private void TurnuvaOyunIslemleri_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlDataAdapter adapter0 = new SqlDataAdapter("SELECT O.OyunID, O.TurnuvaID, T.TurnuvaAdi, O.BeyazOyuncuID, " +
                                            "B.Isim + ' ' + B.Soyisim AS BeyazAdSoyad, O.SiyahOyuncuID, " +
                                            "S.Isim + ' ' + S.Soyisim AS SiyahAdSoyad, O.AcilisKodu, A.AcilisAdi, " +
                                            "O.Notasyon, O.OyunSonucu, O.OyunTarihi " +
                                            "FROM Oyunlar O " +
                                            "JOIN Turnuvalar T ON O.TurnuvaID = T.TurnuvaID " +
                                            "JOIN Oyuncular B ON O.BeyazOyuncuID = B.FideID " +
                                            "JOIN Oyuncular S ON O.SiyahOyuncuID = S.FideID " +
                                            "LEFT JOIN Acilislar A ON O.AcilisKodu = A.AcilisKodu", conn);
                    DataTable dtOyunlar = new DataTable();
                    adapter0.Fill(dtOyunlar);
                    dgvVeriTablosu.DataSource = dtOyunlar;

                    // Beyaz ve Siyah Oyuncular
                    SqlDataAdapter adapter = new SqlDataAdapter(
                        "SELECT FideID, Isim + ' ' + Soyisim AS AdSoyad FROM Oyuncular ORDER BY Isim",
                        conn
                    );
                    DataTable dtOyuncular = new DataTable();
                    adapter.Fill(dtOyuncular);

                    // Beyaz Oyuncu ComboBox
                    cmbBeyazOyuncu.DataSource = dtOyuncular.Copy();
                    cmbBeyazOyuncu.DisplayMember = "AdSoyad";
                    cmbBeyazOyuncu.ValueMember = "FideID";

                    // Siyah Oyuncu ComboBox
                    cmbSiyahOyuncu.DataSource = dtOyuncular.Copy();
                    cmbSiyahOyuncu.DisplayMember = "AdSoyad";
                    cmbSiyahOyuncu.ValueMember = "FideID";

                    // Turnuvalar
                    adapter = new SqlDataAdapter(
                        "SELECT TurnuvaID, TurnuvaAdi FROM Turnuvalar ORDER BY TurnuvaAdi",
                        conn
                    );
                    DataTable dtTurnuva = new DataTable();
                    adapter.Fill(dtTurnuva);
                    cmbTurnuva.DataSource = dtTurnuva;
                    cmbTurnuva.DisplayMember = "TurnuvaAdi";
                    cmbTurnuva.ValueMember = "TurnuvaID";

                    // Açılışlar
                    adapter = new SqlDataAdapter(
                        "SELECT AcilisKodu, AcilisAdi FROM Acilislar ORDER BY AcilisAdi",
                        conn
                    );
                    DataTable dtAcilis = new DataTable();
                    adapter.Fill(dtAcilis);

                    // Nullable için "- Seçiniz -" ekle
                    DataRow rowAcilis = dtAcilis.NewRow();
                    rowAcilis["AcilisKodu"] = "";
                    rowAcilis["AcilisAdi"] = "- Seçiniz -";
                    dtAcilis.Rows.InsertAt(rowAcilis, 0);

                    cmbAcilis.DataSource = dtAcilis;
                    cmbAcilis.DisplayMember = "AcilisAdi";
                    cmbAcilis.ValueMember = "AcilisKodu";
                    cmbAcilis.SelectedIndex = 0;

                    // Oyun Sonucu
                    DataTable dtSonuc = new DataTable();
                    dtSonuc.Columns.Add("OyunSonucu", typeof(string));
                    dtSonuc.Rows.Add("1-0");
                    dtSonuc.Rows.Add("0-1");
                    dtSonuc.Rows.Add("1/2-1/2");
                    cmbOyunSonucu.DataSource = dtSonuc;
                    cmbOyunSonucu.DisplayMember = "OyunSonucu";
                    cmbOyunSonucu.ValueMember = "OyunSonucu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVeriTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVeriTablosu.Rows[e.RowIndex];
                cmbBeyazOyuncu.SelectedValue = row.Cells["BeyazOyuncuID"].Value;
                cmbSiyahOyuncu.SelectedValue = row.Cells["SiyahOyuncuID"].Value;
                cmbOyunSonucu.SelectedValue = row.Cells["OyunSonucu"].Value;
                txtOyunTarihi.Text = row.Cells["OyunTarihi"].Value == DBNull.Value ? "" : Convert.ToDateTime(row.Cells["OyunTarihi"].Value).ToString("yyyy-MM-dd");
                cmbTurnuva.SelectedValue = row.Cells["TurnuvaID"].Value;
                cmbAcilis.SelectedValue = row.Cells["AcilisKodu"].Value == DBNull.Value ? "" : row.Cells["AcilisKodu"].Value;
                txtNotasyon.Text = row.Cells["Notasyon"].Value?.ToString() ?? "";
            }
        }
    }
}
