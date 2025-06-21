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
    public partial class OyuncuIslemleri : Form
    {
        public OyuncuIslemleri()
        {
            InitializeComponent();
        }

        private string connectionString = "Server=localhost;Database=ChessDatabase;Trusted_Connection=True;";

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFideKimlik.Text) || string.IsNullOrWhiteSpace(txtIsim.Text) ||
                string.IsNullOrWhiteSpace(txtSoyisim.Text) || string.IsNullOrWhiteSpace(txtRating.Text) ||
                cmbUlkeKodu.SelectedValue?.ToString() == "")
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun: FIDE ID, İsim, Soyisim, Rating, Ülke.");
                return;
            }

            if (!int.TryParse(txtFideKimlik.Text, out int fideID))
            {
                MessageBox.Show("FIDE ID geçerli bir sayı olmalıdır.");
                return;
            }

            if (!int.TryParse(txtRating.Text, out int rating))
            {
                MessageBox.Show("Rating geçerli bir sayı olmalıdır.");
                return;
            }

            DateTime? dogumTarihi = null;
            if (!string.IsNullOrWhiteSpace(txtDogumTarihi.Text))
            {
                if (!DateTime.TryParse(txtDogumTarihi.Text, out DateTime parsedDate))
                {
                    MessageBox.Show("Doğum Tarihi geçerli bir tarih olmalıdır (YYYY-MM-DD).");
                    return;
                }
                dogumTarihi = parsedDate;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Oyuncular (FideID, Isim, Soyisim, DogumTarihi, Rating, UnvanAdi, UlkeKodu) " +
                                                    "VALUES (@FideID, @Isim, @Soyisim, @DogumTarihi, @Rating, @UnvanAdi, @UlkeKodu)", conn);
                    cmd.Parameters.AddWithValue("@FideID", SqlDbType.Int).Value = fideID;
                    cmd.Parameters.AddWithValue("@Isim", SqlDbType.NVarChar).Value = txtIsim.Text.Trim();
                    cmd.Parameters.AddWithValue("@Soyisim", SqlDbType.NVarChar).Value = txtSoyisim.Text.Trim();
                    cmd.Parameters.AddWithValue("@DogumTarihi", SqlDbType.Date).Value = dogumTarihi.HasValue ? (object)dogumTarihi.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Rating", SqlDbType.Int).Value = rating;
                    cmd.Parameters.AddWithValue("@UnvanAdi", SqlDbType.NVarChar).Value = cmbUnvan.SelectedValue?.ToString() == "" ? (object)DBNull.Value : cmbUnvan.SelectedValue;
                    cmd.Parameters.AddWithValue("@UlkeKodu", SqlDbType.Char).Value = cmbUlkeKodu.SelectedValue;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Oyuncu başarıyla eklendi!");

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Oyuncular", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvVeriTablosu.DataSource = dt;

                    txtFideKimlik.Clear();
                    txtIsim.Clear();
                    txtSoyisim.Clear();
                    txtDogumTarihi.Clear();
                    txtRating.Clear();
                    cmbUnvan.SelectedIndex = 0;
                    cmbUlkeKodu.SelectedIndex = 0;
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
                MessageBox.Show("Lütfen silmek için bir oyuncu seçin.");
                return;
            }

            int fideID = Convert.ToInt32(dgvVeriTablosu.SelectedRows[0].Cells["FideID"].Value);
            if (MessageBox.Show($"FIDE ID: {fideID} olan oyuncu silinsin mi?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Oyuncular WHERE FideID = @FideID", conn);
                        cmd.Parameters.AddWithValue("@FideID", SqlDbType.Int).Value = fideID;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Oyuncu başarıyla silindi!");

                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Oyuncular", conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvVeriTablosu.DataSource = dt;

                        txtFideKimlik.Clear();
                        txtIsim.Clear();
                        txtSoyisim.Clear();
                        txtDogumTarihi.Clear();
                        txtRating.Clear();
                        cmbUnvan.SelectedIndex = 0;
                        cmbUlkeKodu.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dgvVeriTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVeriTablosu.Rows[e.RowIndex];
                txtFideKimlik.Text = row.Cells["FideID"].Value?.ToString();
                txtIsim.Text = row.Cells["Isim"].Value?.ToString();
                txtSoyisim.Text = row.Cells["Soyisim"].Value?.ToString();
                txtDogumTarihi.Text = row.Cells["DogumTarihi"].Value == DBNull.Value ? "" : Convert.ToDateTime(row.Cells["DogumTarihi"].Value).ToString("yyyy-MM-dd");
                txtRating.Text = row.Cells["Rating"].Value?.ToString();
                cmbUnvan.SelectedValue = row.Cells["UnvanAdi"].Value == DBNull.Value ? "" : row.Cells["UnvanAdi"].Value;
                cmbUlkeKodu.SelectedValue = row.Cells["UlkeKodu"].Value?.ToString() ?? "";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvVeriTablosu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek için bir oyuncu seçin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIsim.Text) || string.IsNullOrWhiteSpace(txtSoyisim.Text) ||
                string.IsNullOrWhiteSpace(txtRating.Text) || cmbUlkeKodu.SelectedValue?.ToString() == "")
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun: İsim, Soyisim, Rating, Ülke.");
                return;
            }

            if (!int.TryParse(txtFideKimlik.Text, out int fideID))
            {
                MessageBox.Show("FIDE ID geçerli bir sayı olmalıdır.");
                return;
            }

            if (!int.TryParse(txtRating.Text, out int rating))
            {
                MessageBox.Show("Rating geçerli bir sayı olmalıdır.");
                return;
            }

            DateTime? dogumTarihi = null;
            if (!string.IsNullOrWhiteSpace(txtDogumTarihi.Text))
            {
                if (!DateTime.TryParse(txtDogumTarihi.Text, out DateTime parsedDate))
                {
                    MessageBox.Show("Doğum Tarihi geçerli bir tarih olmalıdır (YYYY-MM-DD).");
                    return;
                }
                dogumTarihi = parsedDate;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Oyuncular SET Isim = @Isim, Soyisim = @Soyisim, DogumTarihi = @DogumTarihi, " +
                                                    "Rating = @Rating, UnvanAdi = @UnvanAdi, UlkeKodu = @UlkeKodu WHERE FideID = @FideID", conn);
                    cmd.Parameters.AddWithValue("@FideID", SqlDbType.Int).Value = fideID;
                    cmd.Parameters.AddWithValue("@Isim", SqlDbType.NVarChar).Value = txtIsim.Text.Trim();
                    cmd.Parameters.AddWithValue("@Soyisim", SqlDbType.NVarChar).Value = txtSoyisim.Text.Trim();
                    cmd.Parameters.AddWithValue("@DogumTarihi", SqlDbType.Date).Value = dogumTarihi.HasValue ? (object)dogumTarihi.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Rating", SqlDbType.Int).Value = rating;
                    cmd.Parameters.AddWithValue("@UnvanAdi", SqlDbType.NVarChar).Value = cmbUnvan.SelectedValue?.ToString() == "" ? (object)DBNull.Value : cmbUnvan.SelectedValue;
                    cmd.Parameters.AddWithValue("@UlkeKodu", SqlDbType.Char).Value = cmbUlkeKodu.SelectedValue;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Oyuncu başarıyla güncellendi!");

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Oyuncular", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvVeriTablosu.DataSource = dt;

                    txtFideKimlik.Clear();
                    txtIsim.Clear();
                    txtSoyisim.Clear();
                    txtDogumTarihi.Clear();
                    txtRating.Clear();
                    cmbUnvan.SelectedIndex = 0;
                    cmbUlkeKodu.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void YeniOyuncuEkle_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT UnvanAdi, UnvanAdi + ' - ' + Aciklama AS Gosterim FROM Unvanlar ORDER BY UnvanAdi", conn);
                    DataTable dtUnvan = new DataTable();
                    adapter.Fill(dtUnvan);
                    DataRow rowUnvan = dtUnvan.NewRow();
                    rowUnvan["UnvanAdi"] = "";
                    rowUnvan["Gosterim"] = "- Seçiniz -";
                    dtUnvan.Rows.InsertAt(rowUnvan, 0);
                    cmbUnvan.DataSource = dtUnvan;
                    cmbUnvan.DisplayMember = "Gosterim";
                    cmbUnvan.ValueMember = "UnvanAdi";
                    cmbUnvan.SelectedIndex = 0;

                    adapter = new SqlDataAdapter("SELECT UlkeKodu, UlkeKodu + ' - ' + UlkeAdi AS Gosterim FROM Ulkeler ORDER BY UlkeAdi", conn);
                    DataTable dtUlke = new DataTable();
                    adapter.Fill(dtUlke);
                    DataRow rowUlke = dtUlke.NewRow();
                    rowUlke["UlkeKodu"] = "";
                    rowUlke["Gosterim"] = "- Seçiniz -";
                    dtUlke.Rows.InsertAt(rowUlke, 0);
                    cmbUlkeKodu.DataSource = dtUlke;
                    cmbUlkeKodu.DisplayMember = "Gosterim";
                    cmbUlkeKodu.ValueMember = "UlkeKodu";
                    cmbUlkeKodu.SelectedIndex = 0;

                    adapter = new SqlDataAdapter("SELECT * FROM Oyuncular", conn);
                    DataTable dtOyuncular = new DataTable();
                    adapter.Fill(dtOyuncular);
                    dgvVeriTablosu.DataSource = dtOyuncular;

                    dgvVeriTablosu.Columns["FideID"].HeaderText = "FIDE ID";
                    dgvVeriTablosu.Columns["Isim"].HeaderText = "İsim";
                    dgvVeriTablosu.Columns["Soyisim"].HeaderText = "Soyisim";
                    dgvVeriTablosu.Columns["DogumTarihi"].HeaderText = "Doğum Tarihi";
                    dgvVeriTablosu.Columns["Rating"].HeaderText = "Rating";
                    dgvVeriTablosu.Columns["UnvanAdi"].HeaderText = "Ünvan";
                    dgvVeriTablosu.Columns["UlkeKodu"].HeaderText = "Ülke Kodu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata: " + ex.Message);
            }

        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Form1 geridon = new Form1();
            geridon.Show();
            this.Hide();
        }
    }
}
