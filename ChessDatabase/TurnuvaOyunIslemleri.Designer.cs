using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChessDatabase
{
    partial class TurnuvaOyunIslemleri
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.dgvVeriTablosu = new System.Windows.Forms.DataGridView();
            this.dtOyunlar = new System.Data.DataTable();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBeyazOyuncu = new System.Windows.Forms.ComboBox();
            this.cmbTurnuva = new System.Windows.Forms.ComboBox();
            this.cmbOyunSonucu = new System.Windows.Forms.ComboBox();
            this.cmbSiyahOyuncu = new System.Windows.Forms.ComboBox();
            this.txtOyunTarihi = new System.Windows.Forms.TextBox();
            this.txtNotasyon = new System.Windows.Forms.TextBox();
            this.cmbAcilis = new System.Windows.Forms.ComboBox();
            this.btnAnaSayfayaDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTablosu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOyunlar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(521, 88);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(139, 48);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Oyun Ekle";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(666, 89);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(139, 48);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Oyun Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(811, 89);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(139, 48);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // dgvVeriTablosu
            // 
            this.dgvVeriTablosu.AllowUserToAddRows = false;
            this.dgvVeriTablosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVeriTablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeriTablosu.Location = new System.Drawing.Point(21, 277);
            this.dgvVeriTablosu.Name = "dgvVeriTablosu";
            this.dgvVeriTablosu.RowHeadersWidth = 51;
            this.dgvVeriTablosu.RowTemplate.Height = 24;
            this.dgvVeriTablosu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVeriTablosu.Size = new System.Drawing.Size(1102, 283);
            this.dgvVeriTablosu.TabIndex = 3;
            this.dgvVeriTablosu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVeriTablosu_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Beyaz Oyuncu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Siyah Oyuncu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sonuç: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Oyun Tarihi: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Turnuva: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Açılış: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Notasyon: ";
            // 
            // cmbBeyazOyuncu
            // 
            this.cmbBeyazOyuncu.FormattingEnabled = true;
            this.cmbBeyazOyuncu.Location = new System.Drawing.Point(165, 37);
            this.cmbBeyazOyuncu.Name = "cmbBeyazOyuncu";
            this.cmbBeyazOyuncu.Size = new System.Drawing.Size(121, 24);
            this.cmbBeyazOyuncu.TabIndex = 11;
            // 
            // cmbTurnuva
            // 
            this.cmbTurnuva.FormattingEnabled = true;
            this.cmbTurnuva.Location = new System.Drawing.Point(165, 148);
            this.cmbTurnuva.Name = "cmbTurnuva";
            this.cmbTurnuva.Size = new System.Drawing.Size(121, 24);
            this.cmbTurnuva.TabIndex = 12;
            // 
            // cmbOyunSonucu
            // 
            this.cmbOyunSonucu.FormattingEnabled = true;
            this.cmbOyunSonucu.Location = new System.Drawing.Point(165, 94);
            this.cmbOyunSonucu.Name = "cmbOyunSonucu";
            this.cmbOyunSonucu.Size = new System.Drawing.Size(121, 24);
            this.cmbOyunSonucu.TabIndex = 13;
            // 
            // cmbSiyahOyuncu
            // 
            this.cmbSiyahOyuncu.FormattingEnabled = true;
            this.cmbSiyahOyuncu.Location = new System.Drawing.Point(165, 67);
            this.cmbSiyahOyuncu.Name = "cmbSiyahOyuncu";
            this.cmbSiyahOyuncu.Size = new System.Drawing.Size(121, 24);
            this.cmbSiyahOyuncu.TabIndex = 14;
            // 
            // txtOyunTarihi
            // 
            this.txtOyunTarihi.Location = new System.Drawing.Point(165, 120);
            this.txtOyunTarihi.Name = "txtOyunTarihi";
            this.txtOyunTarihi.Size = new System.Drawing.Size(121, 22);
            this.txtOyunTarihi.TabIndex = 15;
            // 
            // txtNotasyon
            // 
            this.txtNotasyon.Location = new System.Drawing.Point(165, 207);
            this.txtNotasyon.Multiline = true;
            this.txtNotasyon.Name = "txtNotasyon";
            this.txtNotasyon.Size = new System.Drawing.Size(182, 44);
            this.txtNotasyon.TabIndex = 16;
            // 
            // cmbAcilis
            // 
            this.cmbAcilis.FormattingEnabled = true;
            this.cmbAcilis.Location = new System.Drawing.Point(165, 177);
            this.cmbAcilis.Name = "cmbAcilis";
            this.cmbAcilis.Size = new System.Drawing.Size(121, 24);
            this.cmbAcilis.TabIndex = 17;
            // 
            // btnAnaSayfayaDon
            // 
            this.btnAnaSayfayaDon.Location = new System.Drawing.Point(521, 148);
            this.btnAnaSayfayaDon.Name = "btnAnaSayfayaDon";
            this.btnAnaSayfayaDon.Size = new System.Drawing.Size(429, 48);
            this.btnAnaSayfayaDon.TabIndex = 18;
            this.btnAnaSayfayaDon.Text = "Ana Sayfaya Dön";
            this.btnAnaSayfayaDon.UseVisualStyleBackColor = true;
            this.btnAnaSayfayaDon.Click += new System.EventHandler(this.btnAnaSayfayaDon_Click);
            // 
            // TurnuvaOyunIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 572);
            this.Controls.Add(this.btnAnaSayfayaDon);
            this.Controls.Add(this.cmbAcilis);
            this.Controls.Add(this.txtNotasyon);
            this.Controls.Add(this.txtOyunTarihi);
            this.Controls.Add(this.cmbSiyahOyuncu);
            this.Controls.Add(this.cmbOyunSonucu);
            this.Controls.Add(this.cmbTurnuva);
            this.Controls.Add(this.cmbBeyazOyuncu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvVeriTablosu);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Name = "TurnuvaOyunIslemleri";
            this.Text = "Turnuva Oyun İşlemleri";
            this.Load += new System.EventHandler(this.TurnuvaOyunIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTablosu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOyunlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.DataGridView dgvVeriTablosu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBeyazOyuncu;
        private System.Windows.Forms.ComboBox cmbTurnuva;
        private System.Windows.Forms.ComboBox cmbOyunSonucu;
        private System.Windows.Forms.ComboBox cmbSiyahOyuncu;
        private System.Windows.Forms.TextBox txtOyunTarihi;
        private System.Windows.Forms.TextBox txtNotasyon;
        private System.Windows.Forms.ComboBox cmbAcilis;
        private DataGridViewTextBoxColumn oyunIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn turnuvaIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn turnuvaAdiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn beyazOyuncuIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn beyazAdSoyadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn siyahOyuncuIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn siyahAdSoyadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acilisKoduDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acilisAdiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notasyonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn oyunSonucuDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn oyunTarihiDataGridViewTextBoxColumn;
        private DataTable dtOyunlar;
        private Button btnAnaSayfayaDon;
    }
}