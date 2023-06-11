using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select * from TBLBILGI", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();


            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Gorev = dr["GÖREV"].ToString();
                ent.Sehir = dr["ŞEHİR"].ToString();
                ent.Maas = short.Parse(dr["MAAŞ"].ToString());
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel personel)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBLBILGI (AD,SOYAD,GÖREV,ŞEHİR,MAAŞ) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", personel.Ad);
            komut2.Parameters.AddWithValue("@P2", personel.Soyad);
            komut2.Parameters.AddWithValue("@P3", personel.Gorev);
            komut2.Parameters.AddWithValue("@P4", personel.Sehir);
            komut2.Parameters.AddWithValue("@P5", personel.Maas);
            return komut2.ExecuteNonQuery();
        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TBLBILGI where ID=@P1", Baglanti.bgl);

            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", p);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut4=new SqlCommand("Update TBLBILGI SET AD=@P1,SOYAD=@P2,MAAŞ=@P3,ŞEHİR=@P4,GÖREV=@P5 WHERE ID=@P6", Baglanti.bgl);

            if(komut4.Connection.State != ConnectionState.Open) 
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.Ad);
            komut4.Parameters.AddWithValue("@P2", ent.Soyad);
            komut4.Parameters.AddWithValue("@P3", ent.Maas);
            komut4.Parameters.AddWithValue("@P4", ent.Sehir);
            komut4.Parameters.AddWithValue("@P5", ent.Gorev);
            komut4.Parameters.AddWithValue("@P6", ent.Id);
            return komut4.ExecuteNonQuery() > 0;
         }

}
}
