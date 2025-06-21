namespace ChessDatabase
{
    partial class OyuncuIslemleri
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
            this.txtFideKimlik = new System.Windows.Forms.TextBox();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.txtSoyisim = new System.Windows.Forms.TextBox();
            this.txtDogumTarihi = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.lblFideKimlik = new System.Windows.Forms.Label();
            this.lblIsım = new System.Windows.Forms.Label();
            this.lblSoyisim = new System.Windows.Forms.Label();
            this.lblDogumTarihi = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblUnvan = new System.Windows.Forms.Label();
            this.lblUlkeKodu = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.dgvVeriTablosu = new System.Windows.Forms.DataGridView();
            this.cmbUnvan = new System.Windows.Forms.ComboBox();
            this.cmbUlkeKodu = new System.Windows.Forms.ComboBox();
            this.btnAnaSayfa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFideKimlik
            // 
            this.txtFideKimlik.Location = new System.Drawing.Point(181, 32);
            this.txtFideKimlik.Name = "txtFideKimlik";
            this.txtFideKimlik.Size = new System.Drawing.Size(100, 22);
            this.txtFideKimlik.TabIndex = 0;
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(181, 60);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(100, 22);
            this.txtIsim.TabIndex = 1;
            // 
            // txtSoyisim
            // 
            this.txtSoyisim.Location = new System.Drawing.Point(181, 88);
            this.txtSoyisim.Name = "txtSoyisim";
            this.txtSoyisim.Size = new System.Drawing.Size(100, 22);
            this.txtSoyisim.TabIndex = 2;
            // 
            // txtDogumTarihi
            // 
            this.txtDogumTarihi.Location = new System.Drawing.Point(181, 120);
            this.txtDogumTarihi.Name = "txtDogumTarihi";
            this.txtDogumTarihi.Size = new System.Drawing.Size(100, 22);
            this.txtDogumTarihi.TabIndex = 3;
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(181, 148);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(100, 22);
            this.txtRating.TabIndex = 4;
            // 
            // lblFideKimlik
            // 
            this.lblFideKimlik.AutoSize = true;
            this.lblFideKimlik.Location = new System.Drawing.Point(63, 37);
            this.lblFideKimlik.Name = "lblFideKimlik";
            this.lblFideKimlik.Size = new System.Drawing.Size(59, 16);
            this.lblFideKimlik.TabIndex = 7;
            this.lblFideKimlik.Text = "FIDE ID: ";
            // 
            // lblIsım
            // 
            this.lblIsım.AutoSize = true;
            this.lblIsım.Location = new System.Drawing.Point(63, 66);
            this.lblIsım.Name = "lblIsım";
            this.lblIsım.Size = new System.Drawing.Size(81, 16);
            this.lblIsım.TabIndex = 8;
            this.lblIsım.Text = "Oyuncu Adı: ";
            // 
            // lblSoyisim
            // 
            this.lblSoyisim.AutoSize = true;
            this.lblSoyisim.Location = new System.Drawing.Point(63, 94);
            this.lblSoyisim.Name = "lblSoyisim";
            this.lblSoyisim.Size = new System.Drawing.Size(104, 16);
            this.lblSoyisim.TabIndex = 9;
            this.lblSoyisim.Text = "Oyuncu Soyadı: ";
            // 
            // lblDogumTarihi
            // 
            this.lblDogumTarihi.AutoSize = true;
            this.lblDogumTarihi.Location = new System.Drawing.Point(63, 126);
            this.lblDogumTarihi.Name = "lblDogumTarihi";
            this.lblDogumTarihi.Size = new System.Drawing.Size(94, 16);
            this.lblDogumTarihi.TabIndex = 10;
            this.lblDogumTarihi.Text = "Doğum Tarihi: ";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(63, 154);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(33, 16);
            this.lblRating.TabIndex = 11;
            this.lblRating.Text = "Elo: ";
            // 
            // lblUnvan
            // 
            this.lblUnvan.AutoSize = true;
            this.lblUnvan.Location = new System.Drawing.Point(63, 182);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(52, 16);
            this.lblUnvan.TabIndex = 12;
            this.lblUnvan.Text = "Ünvan: ";
            // 
            // lblUlkeKodu
            // 
            this.lblUlkeKodu.AutoSize = true;
            this.lblUlkeKodu.Location = new System.Drawing.Point(63, 210);
            this.lblUlkeKodu.Name = "lblUlkeKodu";
            this.lblUlkeKodu.Size = new System.Drawing.Size(75, 16);
            this.lblUlkeKodu.TabIndex = 13;
            this.lblUlkeKodu.Text = "Ülke Kodu: ";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(359, 94);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(139, 48);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(504, 93);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(113, 49);
            this.btnSil.TabIndex = 15;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(624, 94);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(132, 48);
            this.btnGuncelle.TabIndex = 16;
            this.btnGuncelle.Text = "Guncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // dgvVeriTablosu
            // 
            this.dgvVeriTablosu.AllowUserToAddRows = false;
            this.dgvVeriTablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeriTablosu.Location = new System.Drawing.Point(24, 240);
            this.dgvVeriTablosu.Name = "dgvVeriTablosu";
            this.dgvVeriTablosu.RowHeadersWidth = 51;
            this.dgvVeriTablosu.RowTemplate.Height = 24;
            this.dgvVeriTablosu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVeriTablosu.Size = new System.Drawing.Size(746, 198);
            this.dgvVeriTablosu.TabIndex = 17;
            this.dgvVeriTablosu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVeriTablosu_CellClick);
            // 
            // cmbUnvan
            // 
            this.cmbUnvan.FormattingEnabled = true;
            this.cmbUnvan.Location = new System.Drawing.Point(181, 179);
            this.cmbUnvan.Name = "cmbUnvan";
            this.cmbUnvan.Size = new System.Drawing.Size(121, 24);
            this.cmbUnvan.TabIndex = 18;
            // 
            // cmbUlkeKodu
            // 
            this.cmbUlkeKodu.FormattingEnabled = true;
            this.cmbUlkeKodu.Location = new System.Drawing.Point(181, 210);
            this.cmbUlkeKodu.Name = "cmbUlkeKodu";
            this.cmbUlkeKodu.Size = new System.Drawing.Size(121, 24);
            this.cmbUlkeKodu.TabIndex = 19;
            // 
            // btnAnaSayfa
            // 
            this.btnAnaSayfa.Location = new System.Drawing.Point(359, 155);
            this.btnAnaSayfa.Name = "btnAnaSayfa";
            this.btnAnaSayfa.Size = new System.Drawing.Size(397, 48);
            this.btnAnaSayfa.TabIndex = 20;
            this.btnAnaSayfa.Text = "Ana Sayfaya Dön";
            this.btnAnaSayfa.UseVisualStyleBackColor = true;
            this.btnAnaSayfa.Click += new System.EventHandler(this.btnAnaSayfa_Click);
            // 
            // OyuncuIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.btnAnaSayfa);
            this.Controls.Add(this.cmbUlkeKodu);
            this.Controls.Add(this.cmbUnvan);
            this.Controls.Add(this.dgvVeriTablosu);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblUlkeKodu);
            this.Controls.Add(this.lblUnvan);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblDogumTarihi);
            this.Controls.Add(this.lblSoyisim);
            this.Controls.Add(this.lblIsım);
            this.Controls.Add(this.lblFideKimlik);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtDogumTarihi);
            this.Controls.Add(this.txtSoyisim);
            this.Controls.Add(this.txtIsim);
            this.Controls.Add(this.txtFideKimlik);
            this.Name = "OyuncuIslemleri";
            this.Text = "Oyuncu İşlemleri";
            this.Load += new System.EventHandler(this.YeniOyuncuEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFideKimlik;
        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.TextBox txtSoyisim;
        private System.Windows.Forms.TextBox txtDogumTarihi;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label lblFideKimlik;
        private System.Windows.Forms.Label lblIsım;
        private System.Windows.Forms.Label lblSoyisim;
        private System.Windows.Forms.Label lblDogumTarihi;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.Label lblUlkeKodu;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridView dgvVeriTablosu;
        private System.Windows.Forms.ComboBox cmbUnvan;
        private System.Windows.Forms.ComboBox cmbUlkeKodu;
        private System.Windows.Forms.Button btnAnaSayfa;
    }
}