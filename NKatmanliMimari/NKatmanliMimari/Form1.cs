using EntityLayer;
using LogicLayer;
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

namespace NKatmanliMimari
{
    public partial class txt_ : Form
    {
        public txt_()
        {
            InitializeComponent();
        }
        public void Listele()
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }
        private void Temizle()
        {
            txt_Id.Text = "";
            txt_Ad.Text = "";
            txt_Soyad.Text = "";
            txt_Gorev.Text = "";
            txt_Maas.Text = "";
            txt_Sehir.Text = "";
        }
        private void btn_Listele_Click(object sender, EventArgs e)
        {
            Listele();
        }
      
        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = txt_Ad.Text;
            ent.Soyad = txt_Soyad.Text;
            ent.Sehir=txt_Sehir.Text;
            ent.Maas = short.Parse(txt_Maas.Text);
            ent.Gorev = txt_Gorev.Text;
            LogicPersonel.LLPersonelEkle(ent);
            Listele();
            MessageBox.Show("Personel eklendi.");
            Temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(txt_Id.Text);
            LogicPersonel.LLPersonelSil(ent.Id);
            Listele();
            MessageBox.Show("Personel silindi.");
            Temizle();
        }

        private void txt__Load(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_Id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_Ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_Soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txt_Sehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_Gorev.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_Maas.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(txt_Id.Text);
            ent.Ad=txt_Ad.Text;
            ent.Soyad=txt_Soyad.Text;
            ent.Sehir = txt_Sehir.Text;
            ent.Gorev = txt_Gorev.Text;
            ent.Maas = short.Parse(txt_Maas.Text);
            LogicPersonel.LLpersonelGuncelle(ent);
            Listele();
            MessageBox.Show("Güncelleme işlemi yapıldı.");
            Temizle();
        }
    }
}
