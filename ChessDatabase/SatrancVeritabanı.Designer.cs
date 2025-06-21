namespace ChessDatabase
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOyuncularıGöster = new System.Windows.Forms.Button();
            this.btnOyunlarıGoster = new System.Windows.Forms.Button();
            this.btnTurnuvaİstatistikleri = new System.Windows.Forms.Button();
            this.btnYeniOyuncuEkle = new System.Windows.Forms.Button();
            this.dgvVeriTablosu = new System.Windows.Forms.DataGridView();
            this.cmbTurnuva = new System.Windows.Forms.ComboBox();
            this.txtOyuncuIsim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnYeniOyunEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOyuncularıGöster
            // 
            this.btnOyuncularıGöster.Location = new System.Drawing.Point(365, 54);
            this.btnOyuncularıGöster.Name = "btnOyuncularıGöster";
            this.btnOyuncularıGöster.Size = new System.Drawing.Size(156, 36);
            this.btnOyuncularıGöster.TabIndex = 0;
            this.btnOyuncularıGöster.Text = "Oyuncuları  Listele";
            this.btnOyuncularıGöster.UseVisualStyleBackColor = true;
            this.btnOyuncularıGöster.Click += new System.EventHandler(this.btnOyuncularıGöster_Click);
            // 
            // btnOyunlarıGoster
            // 
            this.btnOyunlarıGoster.Location = new System.Drawing.Point(365, 129);
            this.btnOyunlarıGoster.Name = "btnOyunlarıGoster";
            this.btnOyunlarıGoster.Size = new System.Drawing.Size(156, 36);
            this.btnOyunlarıGoster.TabIndex = 1;
            this.btnOyunlarıGoster.Text = "Oyunları Listele";
            this.btnOyunlarıGoster.UseVisualStyleBackColor = true;
            this.btnOyunlarıGoster.Click += new System.EventHandler(this.btnOyunlarıGoster_Click);
            // 
            // btnTurnuvaİstatistikleri
            // 
            this.btnTurnuvaİstatistikleri.Location = new System.Drawing.Point(365, 92);
            this.btnTurnuvaİstatistikleri.Name = "btnTurnuvaİstatistikleri";
            this.btnTurnuvaİstatistikleri.Size = new System.Drawing.Size(156, 36);
            this.btnTurnuvaİstatistikleri.TabIndex = 2;
            this.btnTurnuvaİstatistikleri.Text = "Turnuva Bilgileri";
            this.btnTurnuvaİstatistikleri.UseVisualStyleBackColor = true;
            this.btnTurnuvaİstatistikleri.Click += new System.EventHandler(this.btnTurnuvaİstatistikleri_Click);
            // 
            // btnYeniOyuncuEkle
            // 
            this.btnYeniOyuncuEkle.Location = new System.Drawing.Point(575, 71);
            this.btnYeniOyuncuEkle.Name = "btnYeniOyuncuEkle";
            this.btnYeniOyuncuEkle.Size = new System.Drawing.Size(156, 36);
            this.btnYeniOyuncuEkle.TabIndex = 3;
            this.btnYeniOyuncuEkle.Text = "Yeni Oyuncu Ekle";
            this.btnYeniOyuncuEkle.UseVisualStyleBackColor = true;
            this.btnYeniOyuncuEkle.Click += new System.EventHandler(this.btnYeniOyuncuEkle_Click);
            // 
            // dgvVeriTablosu
            // 
            this.dgvVeriTablosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVeriTablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeriTablosu.Location = new System.Drawing.Point(23, 184);
            this.dgvVeriTablosu.Name = "dgvVeriTablosu";
            this.dgvVeriTablosu.ReadOnly = true;
            this.dgvVeriTablosu.RowHeadersWidth = 51;
            this.dgvVeriTablosu.RowTemplate.Height = 24;
            this.dgvVeriTablosu.Size = new System.Drawing.Size(749, 243);
            this.dgvVeriTablosu.TabIndex = 4;
            // 
            // cmbTurnuva
            // 
            this.cmbTurnuva.DisplayMember = "TurnuvaAdi";
            this.cmbTurnuva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurnuva.FormattingEnabled = true;
            this.cmbTurnuva.Location = new System.Drawing.Point(174, 127);
            this.cmbTurnuva.Name = "cmbTurnuva";
            this.cmbTurnuva.Size = new System.Drawing.Size(121, 24);
            this.cmbTurnuva.TabIndex = 6;
            this.cmbTurnuva.ValueMember = "TurnuvaID";
            // 
            // txtOyuncuIsim
            // 
            this.txtOyuncuIsim.Location = new System.Drawing.Point(174, 71);
            this.txtOyuncuIsim.Name = "txtOyuncuIsim";
            this.txtOyuncuIsim.Size = new System.Drawing.Size(121, 22);
            this.txtOyuncuIsim.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Oyuncu Gir: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Turnuva Seç: ";
            // 
            // btnYeniOyunEkle
            // 
            this.btnYeniOyunEkle.Location = new System.Drawing.Point(575, 113);
            this.btnYeniOyunEkle.Name = "btnYeniOyunEkle";
            this.btnYeniOyunEkle.Size = new System.Drawing.Size(156, 40);
            this.btnYeniOyunEkle.TabIndex = 10;
            this.btnYeniOyunEkle.Text = "Yeni Oyun Ekle";
            this.btnYeniOyunEkle.UseVisualStyleBackColor = true;
            this.btnYeniOyunEkle.Click += new System.EventHandler(this.btnYeniOyunEkle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnYeniOyunEkle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOyuncuIsim);
            this.Controls.Add(this.cmbTurnuva);
            this.Controls.Add(this.dgvVeriTablosu);
            this.Controls.Add(this.btnYeniOyuncuEkle);
            this.Controls.Add(this.btnTurnuvaİstatistikleri);
            this.Controls.Add(this.btnOyunlarıGoster);
            this.Controls.Add(this.btnOyuncularıGöster);
            this.Name = "Form1";
            this.Text = "Satranç Veritabanı";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOyuncularıGöster;
        private System.Windows.Forms.Button btnOyunlarıGoster;
        private System.Windows.Forms.Button btnTurnuvaİstatistikleri;
        private System.Windows.Forms.Button btnYeniOyuncuEkle;
        private System.Windows.Forms.DataGridView dgvVeriTablosu;
        private System.Windows.Forms.ComboBox cmbTurnuva;
        private System.Windows.Forms.TextBox txtOyuncuIsim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnYeniOyunEkle;
    }
}

