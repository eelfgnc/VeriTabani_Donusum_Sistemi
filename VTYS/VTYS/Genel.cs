using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VTYS
{
    class Genel
    {
        /**
         * \brief baglantiyolu stringi ile gelen SQL baglanti sorgusuyla birlikte uygulama ile veritabani arasinda bir baglanti acar.
         * \param baglantiyolu veritabanina baglanmak icin gerekli olan SQL sorgusunun oldugu string.
         * \return error baglantinin gerceklesip ya da gerceklesmedigi ile ilgili mesaj verir.
         */
        public string VeritabaniBaglantisiniAcma(string baglantiyolu)
        {
            string error;

            try
            {
                SqlConnection connection = new SqlConnection(baglantiyolu);
                connection.Open();
                error = "Connection is succesful!";

            }
            catch (Exception)
            {
                error = "Connection is failed!" + Environment.NewLine + "Please, control your SQL Connection.";
            }

            return error;
        }

        /**
         * \brief baglantiyolu stringi ile gelen SQL baglanti sorgusuyla birlikte uygulama ile veritabani arasindaki baglantiyi kapatir.
         * \param baglantiyolu veritabaninin baglantisini kapatmak icin gerekli olan SQL sorgusunun oldugu string.
         * \return error baglantinin gerceklesip ya da gerceklesmedigi ile ilgili mesaj verir.
         */
        public string VeritabaniBaglantisiniKapatma(string baglantiyolu)
        {
            string error;

            try
            {
                SqlConnection connection = new SqlConnection(baglantiyolu);
                connection.Close();
                connection.Dispose();

                error = "Connection is closed succesfully!";
            }
            catch (Exception)
            {
                error = "Connection is not closed succesfully!";
            }

            return error;
        }

        /**
         * \brief Gelen Select sorgusu ile birlikte tablolardaki bilgileri bir datatable uzerinde kaydeder.
         * \param sorgu Tablolardan veri cekmemize yarayan sorgu.
         * \param baglanti Veritabani ile uygulama arasindaki baglantiyi saglar 
         * \return table Verilen SELECT sorgusu ile birlikte bilgiler DataTable üzerine kaydedilir ve tablo olarak geri döndürür.
         */
        public DataTable Select(string sorgu, string baglanti)
        {
            DataTable table = new DataTable();

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sorgu, baglanti);
                dataAdapter.Fill(table);

                return table;
            }
            catch (Exception)
            {
                return table;
            }
        }
    }
}