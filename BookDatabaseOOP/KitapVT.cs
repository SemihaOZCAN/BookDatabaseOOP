using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookDatabaseOOP
{
    internal class KitapVT
    {
        public readonly string connectionString = @"Data Source=DESKTOP-KIMUOA0\SQLEXPRESS;Initial Catalog=DbKitaplik;Integrated Security=True";

        public List<Kitap> Liste()
        {
            List<Kitap> kitaplar = new List<Kitap>();

            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();

                    using (SqlCommand komut = new SqlCommand("SELECT * FROM TBLKITAPLAR", baglanti))
                    {
                        using (SqlDataReader dr = komut.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Kitap k = new Kitap
                                {
                                    ID = Convert.ToInt16(dr[0]),
                                    KITAPAD = dr[1].ToString(),
                                    YAZAR = dr[2].ToString()
                                };
                                kitaplar.Add(k);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Veritabanı hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Genel hata: " + ex.Message);
            }

            return kitaplar;
        }

        public void KitapEkle(Kitap kt)
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(connectionString))
                {
                    baglanti.Open();

                    string sqlQuery = "INSERT INTO TBLKITAPLAR (KITAPAD, YAZAR) VALUES (@p1, @p2)";
                    using (SqlCommand komut = new SqlCommand(sqlQuery, baglanti))
                    {
                        // Parametreleri ekle
                        komut.Parameters.AddWithValue("@p1", kt.KITAPAD);
                        komut.Parameters.AddWithValue("@p2", kt.YAZAR);

                        // Sorguyu çalıştır
                        komut.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Veritabanı hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Genel hata: " + ex.Message);
            }
        }
    }

}

