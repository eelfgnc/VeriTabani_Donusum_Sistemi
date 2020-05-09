using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace VTYS
{
    public partial class ConverterForm : Form
    {
        /**
         * \brief Genel sinifina ait nesne
         */
        Genel genel = new Genel();

        /**
         * \brief Stringleri dosyaya yazmak icin kullandigimiz degisken
         */
        StringBuilder builder = new StringBuilder();

        /**
         * \brief Stringleri dosyaya yazdirmak icin kullandigimiz degisken
         */
        StreamWriter sw;
        string primarykey;
        string[] key;

        public ConverterForm()
        {
            InitializeComponent();
        }

        /**
         * \brief Form_Load oldugu zaman arayuzde gerceklesecek islemlerin listesi
         */
        private void ConverterForm_Load(object sender, EventArgs e)
        {
            serverNameTextBox.Text = "DESKTOP-ASEN0UC\\SERGENSQLSERVER";
            databaseNameTextBox.Text = "db_TheatreManager";

            optionComboBox.Items.Add("SELECT - UPDATE - DELETE - INSERT");
            optionComboBox.Items.Add("CREATE TABLE - ALTER TABLE");
            optionComboBox.Items.Add("CREATE VIEW");
            optionComboBox.Items.Add("CREATE_DELETE TRIGGER");
            optionComboBox.Items.Add("CREATE_UPDATE TRIGGER");
        }

        /**
         * \brief sourceButton'le donusturulecek sorgunun oldugu dosya konumunu aciyoruz.
         */
        private void sourceButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ShowDialog();
                sourceTextBox.Text = openFile.FileName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /**
         * \brief destinationButton'le donusturulen sorgunun nereye kaydedilecegini belirliyoruz.
         */
        private void destinationButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ShowDialog();
                destinationTextBox.Text = openFile.FileName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /**
         * \brief showpasswordButton'la birlikte passwordTextBox icerisindeki text dosyasini sifreler ya da kaldiririz.
         */
        private void showpasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (passwordTextBox.UseSystemPasswordChar == true)
                {
                    passwordTextBox.UseSystemPasswordChar = false;
                    Bitmap bm = new Bitmap(Path.Combine(Application.StartupPath, "hide.png"));
                    showpasswordButton.Image = bm;
                }
                else
                {
                    passwordTextBox.UseSystemPasswordChar = true; ;
                    Bitmap bm = new Bitmap(Path.Combine(Application.StartupPath, "show.png"));
                    showpasswordButton.Image = bm;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /**
         * \brief RadioButton'un secimleriyle birlikte SQL Server'a nasil baglanilacagimizi belirliyoruz.
         */
        private void windowsAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (windowsAuthenticationRadioButton.Checked == true)
            {
                usernameTextBox.Enabled = false;
                usernameTextBox.Text = "";
                passwordTextBox.Enabled = false;
                passwordTextBox.Text = "";
            }
            else
            {
                usernameTextBox.Enabled = true;
                usernameTextBox.Text = "sa";
                passwordTextBox.Enabled = true;
                passwordTextBox.Text = "3.141592653";
            }
        }
        /**
         * \brief convertButton'a tikladigimiz zaman donusturme islemini baslatiyoruz.
         */
        private void convertButton_Click(object sender, EventArgs e)
        {
            string message = "";
            string SQL = "";

            /**
             *\brief SQL Server'a nasil baglanacagimizi belirliyoruz - (Username, password) olsun mu?
             */
            if (windowsAuthenticationRadioButton.Checked == true)
            {
                SQL = "Data Source = " + serverNameTextBox.Text + ";Initial Catalog = " + databaseNameTextBox.Text + ";Integrated Security = True";
            }
            else
            {
                SQL = "Server =" + serverNameTextBox.Text + ";Database =" + databaseNameTextBox.Text + ";User =" + usernameTextBox.Text + ";Password =" + passwordTextBox.Text + ";";
            }

            /**
             * \brief SQL baglantisini acar.Baglantinin durumu ile ilgili bir mesaji message stringine kaydeder.
             */
            message = genel.VeritabaniBaglantisiniAcma(SQL);

            /**
             * \brief Baglanti basarisiz ise hata mesaji yollar. Baglanti basarili olursa donusturmeyi tamamlar
             * ve ekrana bilgi mesaji yollar.
             */
            if (message != "Connection is succesful!")
            {
                MessageBox.Show(message, "Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                /**
                 * \brief comboBox uzerinden "SELECT - UPDATE - DELETE - INSERT" textini secer.
                 * Buradaki islemle yukarida yazilan sorgular PostgreSQL karsiligina donusturulur.
                 */
                if (optionComboBox.SelectedIndex == 0)
                {
                    if (sourceTextBox.Text.Length != 0 && destinationButton.Text.Length != 0)
                    {
                        builder.Clear();
                        /**
                         * \brief SQL sorgusu okunur ve bir string uzerine kaydedilir.
                         */
                        TextReader reader = new StreamReader(sourceTextBox.Text);
                        string oku = reader.ReadToEnd();
                        string[] satir = oku.Split('\n');

                        for (int i = 0; i < satir.Length; i++)
                        {

                            satir[i] = satir[i].Replace("]", "");
                            satir[i] = satir[i].Replace("[", "");

                            builder.Append(satir[i]);

                            if (satir[i].EndsWith("\r") && satir[i]!="\r")
                            {
                                builder.Append(";");
                            }

                            if (i == satir.Length - 1)
                            {
                                builder.Append(";");
                            }

                            builder.Append(Environment.NewLine);
                        }

                        /**
                         * \brief SQL sorgusu donusturulur ve bir dosya uzerine kaydedilir.
                         */
                        sw = new StreamWriter(destinationTextBox.Text);
                        sw.Write(builder);
                        sw.Close();
                        MessageBox.Show("Converting is succesful!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Source TextBox's or Destination TextBox's Text is empty!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                /**
                 * \brief comboBox uzerinden "CREATE TABLE - ALTER TABLE" textini secer.
                 * Veritabani uzerinden tablolari olusturur ve bir script uzerinden PRIMARY KEY
                 * ve FOREIGN KEY tanimlamalari yapilir.
                 */
                else if (optionComboBox.SelectedIndex == 1)
                {
                    if (sourceTextBox.Text.Length != 0 && destinationTextBox.Text.Length != 0)
                    {
                        builder.Clear();

                        /**
                         * \brief Tablolari bastan olusturmak icin veritabanindan tablo isimlerini cekiyoruz.
                         * Sonrasinda butun tablo isimlerini bir DataTable uzerine atip oradan isimlerini dongu 
                         * icinde aliyoruz.
                         */
                        string table_name_select = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG ='" + databaseNameTextBox.Text + "'" + " order by TABLE_SCHEMA, TABLE_NAME ASC ";
                        DataTable table_name = new DataTable();
                        table_name = genel.Select(table_name_select, SQL);
                        genel.VeritabaniBaglantisiniKapatma(SQL);

                        /**
                         * \brief Tablolarin sutunlarindaki veri tipi karsiliklarini buradaki veritabanindan cekiyoruz.
                         * MsSQLdeki veritipinin yerine PostgreSQLdeki karsiligini koyaraktan tabloyu olusturuyrouz.
                         */
                        if (windowsAuthenticationRadioButton.Checked == true)
                        {
                            SQL = "Data Source = " + serverNameTextBox.Text + ";Initial Catalog = donusum" + ";Integrated Security = True";
                        }
                        else
                        {
                            SQL = "Server =" + serverNameTextBox.Text + ";Database =donusum;User =" + usernameTextBox.Text + ";Password =" + passwordTextBox.Text + ";";
                        }

                        /**
                         * \brief Veri tipi karsiliklarini bu sorgu ile cekip degistiriyoruz.
                         */
                        genel.VeritabaniBaglantisiniAcma(SQL);
                        string ms_post_select = "SELECT * FROM [ms-post]";
                        DataTable ms_post = new DataTable();
                        ms_post = genel.Select(ms_post_select, SQL);
                        genel.VeritabaniBaglantisiniKapatma(SQL);

                        string[] primary = new string[table_name.Rows.Count];
                        TextReader treader = new StreamReader(sourceTextBox.Text);
                        string okunan = treader.ReadToEnd();
                        string[] satirlar = okunan.Split('\n');
                        string[] bolum;
                        int k;
                        int z = 0;

                        /**
                         * \brief CREATE ve ALTER scriptini satir satir okuyaraktan gelen karsiliklarini bulup
                         * sonrasinda olusturmus oldugumuz tablolarda PRIMARY KEY ve FOREIGN KEY atamalarini yapiyoruz.
                         */
                        for (k = 0; k < satirlar.Length; k++)
                        {
                            //satirlar[k] = satirlar[k].TrimStart(' ');
                            /**
                             * \brief if blogundaki kelimeleri gorunce 2 satir asagiya gec primary keyleri oradan cek.
                             */
                            bolum = satirlar[k].Split('[');
                            if (bolum[0] == " CONSTRAINT " || satirlar[k] == "PRIMARY KEY CLUSTERED \r")
                            {
                                k += 2;
                                while (satirlar[k] != ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]\r")
                                {
                                    key = satirlar[k].Split(']');
                                    key[0] = key[0].Replace("\t[", "");
                                    primarykey += key[0] + ", ";
                                    k++;
                                }

                                /**
                                 * \brief her dongu icerisinde primary keyleri alir ve sonrasinda primary string arrayin 
                                 * icerisine atar ve primary keyler tutulur bulunur.
                                 * */
                                primary[z] = primarykey;
                                primary[z] = primary[z].Substring(0, primary[z].Length - 2);
                                z++;
                            }

                            primarykey = "";
                        }
                        z = 0;

                        /**
                         * \brief Asagidaki donguyle birlikte tablolar olusturmaya baslaniyor her tablo tek tek gezilir
                         * data tipleri verilir, NULL mu degil mi bulunur ve tablolar olusturulur.
                         */
                        for (int i = 0; i < table_name.Rows.Count; i++)
                        {
                            string tablename = table_name.Rows[i][0].ToString();
                            builder.Append("CREATE TABLE " + tablename + " (" + Environment.NewLine);

                            /**
                             * \brief Donusumunu yapacagimiz veritabanina baglaniriz ve tablolardaki bilgileri cekeriz.
                             */
                            if (windowsAuthenticationRadioButton.Checked == true)
                            {
                                SQL = "Data Source = " + serverNameTextBox.Text + ";Initial Catalog = " + databaseNameTextBox.Text + ";Integrated Security = True";
                            }
                            else
                            {
                                SQL = "Server =" + serverNameTextBox.Text + ";Database =" + databaseNameTextBox.Text + ";User =" + usernameTextBox.Text + ";Password =" + passwordTextBox.Text + ";";
                            }

                            /**
                             * \brief Veritabanindaki tablolarin sutun adlarini, data tiplerini, ve karakter 
                             * uzunluklari hakkindaki bilgilerini asagidaki sorgudan cekeriz.
                             */
                            genel.VeritabaniBaglantisiniAcma(SQL);
                            string table_info_select = "SELECT COLUMN_NAME,DATA_TYPE, IS_NULLABLE,CHARACTER_MAXIMUM_LENGTH FROM " + databaseNameTextBox.Text + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tablename + "'";
                            DataTable table_info = new DataTable();
                            table_info = genel.Select(table_info_select, SQL);
                            genel.VeritabaniBaglantisiniKapatma(SQL);

                            /**
                             * \brief Tablolardaki bilgilere gore degisiklik yapiyoruz.
                             * Ornegin, nvarchar(MAX) gordugu zaman oradaki degeri text olarak donusturmek gibi.
                             */
                            for (int j = 0; j < table_info.Rows.Count; j++)
                            {
                                builder.Append(table_info.Rows[j][0].ToString() + "\t");

                                string aranacakdeger = table_info.Rows[j][1].ToString();
                                if (table_info.Rows[j][3].ToString() == (-1).ToString())
                                {
                                    aranacakdeger += "(MAX)";
                                }

                                /**
                                 * \brief donusum tablosundaki veritiplerini karsilastirarak MsSQL'den 
                                 * PostgreSQL'e birebir veri tiplerinin donusumu saglanir.
                                 */
                                DataRow[] drDizi = ms_post.Select("mssql Like '" + aranacakdeger + "'");
                                if (drDizi.Length > 0)
                                {
                                    int bulunduguSatirIndex = ms_post.Rows.IndexOf(drDizi[0]);
                                    if (table_info.Rows[j][3].ToString() != (-1).ToString() && table_info.Rows[j][3].ToString() != "")
                                    {
                                        builder.Append("\t" + ms_post.Rows[bulunduguSatirIndex][1].ToString() + "(" + table_info.Rows[j][3].ToString() + ")\t");
                                    }
                                    else
                                    {
                                        builder.Append("\t" + ms_post.Rows[bulunduguSatirIndex][1].ToString() + "\t");
                                    }
                                }

                                /**
                                 * \brief Asagidaki else blogunda NULL olmasina bakiyoruz. Eger YES diyorsa NULL 
                                 * Eger NO diyorsa NOT NULL olarak tablolardaki bilgileri olusturuyoruz.
                                 */
                                else
                                {
                                    builder.Append(table_info.Rows[j][1].ToString() + "\t");
                                }
                                if (table_info.Rows[j][2].ToString() == "YES")
                                {
                                    builder.Append("NULL," + Environment.NewLine);
                                }
                                else
                                {
                                    builder.Append("NOT NULL," + Environment.NewLine);
                                }
                            }

                            /**
                             * \brief Asagidaki if blogunda primary string arrayinde buldugumuz keyleri tablolardaki
                             * karsilik gelen primary key olarak yeni olusturdugumuz scripte ekliyoruz.
                             */
                            builder.Append("CONSTRAINT PK_" + tablename + " PRIMARY KEY  (" + primary[z] + ")) ;");
                            if (i < table_name.Rows.Count - 1)
                            {
                                z++;
                                builder.Append(Environment.NewLine + Environment.NewLine);
                            }

                        }

                        /**
                         * \brief Asagidaki for blogunda Tablolar arasindaki iliskiyi tanimliyoruz. ALTER TABLE
                         * kelimesine karsilik gelecek sekilde tablolardaki FOREIGN KEY iliskileri duzenleniyor.
                         */
                        for (int i = 0; i < satirlar.Length; i++)
                        {
                            string[] alterParca;

                            alterParca = satirlar[i].Split('[');

                            if (alterParca[0] == "ALTER TABLE ")
                            {
                                string[] sil = alterParca[3].Split(']');
                                string[] checksil = sil[1].Split('(');
                                string[] silinecek = alterParca[2].Split(']');
                                if (silinecek[1] == " ADD  CONSTRAINT " || silinecek[1] == " CHECK CONSTRAINT " || checksil[0] == " CHECK  ")
                                {
                                    satirlar[i] = "";
                                }
                                satirlar[i] = satirlar[i].Replace(alterParca[1], "");

                                satirlar[i] = satirlar[i].Replace("]", "");
                                satirlar[i] = satirlar[i].Replace("[", "");
                                satirlar[i] = satirlar[i].Replace("GO", "");

                                satirlar[i] = satirlar[i].Replace("WITH CHECK ", "");

                                builder.Append(Environment.NewLine + Environment.NewLine + satirlar[i]);


                            }

                            /**
                             * \brief Asagidaki else if blogunda REFERENCES gordugumuz yerde FOREIGN KEYLERIN
                             * hangi tablodan REFERANS alindiginin bilgilerini ekliyoruz.
                             */
                            else if (alterParca[0] == "REFERENCES ")
                            {
                                satirlar[i] = satirlar[i].Replace(alterParca[1], "");
                                satirlar[i] = satirlar[i].Replace("[", "");
                                satirlar[i] = satirlar[i].Replace("]", "");
                                satirlar[i] = satirlar[i].Replace("GO", "");
                                builder.Append(Environment.NewLine + satirlar[i] + ";" + Environment.NewLine);
                            }

                        }

                        /**
                         * \brief SQL baglantisi kapatilir ve Tablolarin donusumu destinationTextBox icerisindeki path
                         * uzerinde bulunan dosyanin uzerine yazilir.
                         */
                        genel.VeritabaniBaglantisiniKapatma(SQL);
                        sw = new StreamWriter(destinationTextBox.Text);
                        sw.Write(builder);
                        sw.Close();
                        MessageBox.Show("Converting is succesful!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Source TextBox's or Destination TextBox's Text is empty!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                /**
                 * \brief comboBox uzerinden "CREATE VIEW" textini secer.
                 * Buradaki islemle yukarida yazilan sorgular PostgreSQL karsiligina donusturulur.
                 */
                else if (optionComboBox.SelectedIndex == 2)
                {

                    if (sourceTextBox.Text.Length != 0 && destinationTextBox.Text.Length != 0)
                    {
                        /**
                         * \brief VIEW tablolarinin donusumu yapilacak olan text sourceTextBox uzerinden secilir.
                         * Satir satir split edilir.
                         */
                        builder.Clear();
                        TextReader readview = new StreamReader(sourceTextBox.Text);
                        string okuview = readview.ReadToEnd();
                        string[] satirview = okuview.Split('\n');

                        /**
                         * \brief VIEW tablolarin karsiliklari PostgreSQL'e cevilir. Bu cevirme islemi
                         * GO ifadesi gorene kadar devam eder oradaki "[" ve "]" karakterleri silinir.
                         * CREATE VIEW ve GO arasindaki parcalar alinir. PostgreSQL karsiligi bulunmus olur.
                         */
                        for (int i = 0; i < satirview.Length; i++)
                        {
                            string[] parcalaview = satirview[i].Split('[');
                            if (parcalaview[0] == "CREATE VIEW ")
                            {
                                satirview[i] = satirview[i].Replace(parcalaview[1], "");
                                satirview[i] = satirview[i].Replace("]", "");
                                satirview[i] = satirview[i].Replace("[", "");
                                while (satirview[i] != "GO\r")
                                {
                                    satirview[i] = satirview[i].Replace("]", "");
                                    satirview[i] = satirview[i].Replace("[", "");
                                    builder.Append(satirview[i] + Environment.NewLine);
                                    i++;
                                }
                                builder.Append(Environment.NewLine);
                            }
                        }

                        /**
                         * \brief Donusturmus oldugumuz sanal tablolar hedef dosya konumuna yazilir.
                         */
                        sw = new StreamWriter(destinationTextBox.Text);
                        sw.Write(builder);
                        sw.Close();
                        MessageBox.Show("Converting is succesful!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Source TextBox's or Destination TextBox's Text is empty!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                /**
                 * \brief comboBox uzerinden "CREATE_DELETE TRIGGER" textini sectigimiz zaman calisir.
                 * Burada yapilan islem verilen script uzerinden sirketin istedigi LOG ve DELETE tablolarindaki
                 * bilgilerin DELETE TRIGGERLARINI PostgreSQL'e gore olusturmaktir.
                 */
                else if (optionComboBox.SelectedIndex == 3)
                {
                    if (sourceTextBox.Text.Length != 0 && destinationTextBox.Text.Length != 0)
                    {
                        /**
                         * \brief SQL baglantisi acilir. Sirketin istedigi her tablo icin DELETE TRIGGERI olusturulur.
                         * Bu tablolardaki veriler tum tablolari gezerek elde edilir.
                         */
                        string SQLdelete1 = "Data Source = " + serverNameTextBox.Text + ";Initial Catalog = " + databaseNameTextBox.Text + ";Integrated Security = True";
                        string table_name_select_delete = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG ='" + databaseNameTextBox.Text + "' AND TABLE_NAME NOT LIKE '%LOG%' AND TABLE_NAME NOT LIKE '%DEL%'" + " order by TABLE_NAME DESC";
                        DataTable table_name_delete = new DataTable();
                        table_name_delete = genel.Select(table_name_select_delete, SQLdelete1);
                        genel.VeritabaniBaglantisiniKapatma(SQLdelete1);

                        builder.Clear();

                        /**
                         * \brief Tablolardaki tum veriler cekilir. Asagidaki ifadeye gore CREATE FUNCTIONLAR olustulur.
                         * Eskiden gelenler yerine yeniler eklenir. LOG tablolarindaki bilgiler degistirilir.
                         */
                        for (int i = 0; i < table_name_delete.Rows.Count; i++)
                        {
                            builder.Append("CREATE OR REPLACE FUNCTION ");
                            builder.Append("func_del_" + table_name_delete.Rows[i][0].ToString() + "()" + Environment.NewLine);
                            builder.Append("RETURNS TRIGGER AS $$" + Environment.NewLine);
                            builder.Append("BEGIN insert into LOG_" + table_name_delete.Rows[i][0].ToString() + " ( " + "log_type, ");

                            /**
                             * \brief Asagidaki kod blogunda Tablolarin isimlerini veritabanindan cekip triggerlari
                             * kendi elimizde bastan olusturarak yaziyoruz.
                             */
                            string SQLdelete2 = "Data Source = " + serverNameTextBox.Text + ";Initial Catalog = " + databaseNameTextBox.Text + ";Integrated Security = True";
                            genel.VeritabaniBaglantisiniAcma(SQLdelete2);
                            string table_info_select = "SELECT COLUMN_NAME FROM " + databaseNameTextBox.Text + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table_name_delete.Rows[i][0].ToString() + "'";
                            DataTable table_column_name = new DataTable();
                            table_column_name = genel.Select(table_info_select, SQLdelete2);
                            genel.VeritabaniBaglantisiniKapatma(SQLdelete2);

                            for (int j = 0; j < table_column_name.Rows.Count; j++)
                            {
                                builder.Append(table_column_name.Rows[j][0].ToString());
                                if (j != table_column_name.Rows.Count - 1)
                                {
                                    builder.Append(", ");
                                }
                            }

                            /**
                             * \brief OLD bilgileri silmek icin kullanilan ifade.
                             */
                            builder.Append(")" + Environment.NewLine);
                            builder.Append("values ('D', ");
                            for (int j = 0; j < table_column_name.Rows.Count; j++)
                            {
                                builder.Append("OLD." + table_column_name.Rows[j][0].ToString());
                                if (j != table_column_name.Rows.Count - 1)
                                {
                                    builder.Append(", ");
                                }
                            }
                            builder.Append(");	");
                            builder.Append(Environment.NewLine + "RETURN OLD;" + Environment.NewLine + "END;" + Environment.NewLine + "$$ language plpgsql; " + Environment.NewLine + Environment.NewLine);

                            /**
                             * \brief TRIGGERLAR olustulur. Buradaki ifadeyi kullanaraktan her tablo icin delete triggeri
                             * olusturulur.
                             */
                            builder.Append("CREATE TRIGGER TG_DEL_" + table_name_delete.Rows[i][0].ToString() + Environment.NewLine);
                            builder.Append("AFTER DELETE ON " + table_name_delete.Rows[i][0].ToString() + Environment.NewLine);
                            builder.Append("FOR EACH ROW EXECUTE PROCEDURE func_del_" + table_name_delete.Rows[i][0].ToString() + "();" + Environment.NewLine + Environment.NewLine);
                        }

                        /**
                         * \brief Donusumunu sagladigimiz TRIGGERLAR hedef konumundaki dosyanin uzerine yazilir.
                         */
                        sw = new StreamWriter(destinationTextBox.Text);
                        sw.Write(builder);
                        sw.Close();
                        MessageBox.Show("Converting is succesful!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Source TextBox's or Destination TextBox's Text is empty!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                /**
                 * \brief comboBox uzerinden "CREATE_UPDATE TRIGGER" textini sectigimiz zaman calisir.
                 * Burada yapilan islem verilen script uzerinden sirketin istedigi LOG ve DELETE tablolarindaki
                 * bilgilerin UPDATE TRIGGERLARINI PostgreSQL'e gore olusturmaktir.
                 */
                else if (optionComboBox.SelectedIndex == 4)
                {
                    if (sourceTextBox.Text.Length != 0 && destinationTextBox.Text.Length != 0)
                    {
                        /**
                         * \brief SQL baglantisi acilir. Sirketin istedigi her tablo icin UPDATE TRIGGERI olusturulur.
                         * Bu tablolardaki veriler tum tablolari gezerek elde edilir.
                         */
                        string SQLupdate1 = "Data Source = " + serverNameTextBox.Text + ";Initial Catalog = " + databaseNameTextBox.Text + ";Integrated Security = True";
                        string table_name_select_update = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG ='" + databaseNameTextBox.Text + "' AND TABLE_NAME NOT LIKE '%LOG%' AND TABLE_NAME NOT LIKE '%DEL%'" + " order by TABLE_NAME DESC";
                        DataTable table_name_update = new DataTable();
                        table_name_update = genel.Select(table_name_select_update, SQLupdate1);
                        genel.VeritabaniBaglantisiniKapatma(SQLupdate1);

                        builder.Clear();

                        /**
                         * \brief Tablolardaki tum veriler cekilir. Asagidaki ifadeye gore CREATE FUNCTIONLAR olustulur.
                         * Eskiden gelenler yerine yeniler eklenir. LOG tablolarindaki bilgiler degistirilir.
                         */
                        for (int i = 0; i < table_name_update.Rows.Count; i++)
                        {
                            builder.Append("CREATE OR REPLACE FUNCTION ");
                            builder.Append("func_upt_" + table_name_update.Rows[i][0].ToString() + "()" + Environment.NewLine);
                            builder.Append("RETURNS TRIGGER AS $$" + Environment.NewLine);
                            builder.Append("BEGIN insert into LOG_" + table_name_update.Rows[i][0].ToString() + " (" + "log_type, ");

                            /**
                             * \brief Asagidaki kod blogunda Tablolarin isimlerini veritabanindan cekip triggerlari
                             * kendi elimizde bastan olusturarak yaziyoruz.
                             */
                            string SQLupdate2 = "Data Source = " + serverNameTextBox.Text + ";Initial Catalog = " + databaseNameTextBox.Text + ";Integrated Security = True";
                            genel.VeritabaniBaglantisiniAcma(SQLupdate2);
                            string table_info_select = "SELECT COLUMN_NAME FROM " + databaseNameTextBox.Text + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table_name_update.Rows[i][0].ToString() + "'";
                            DataTable table_column_update_name = new DataTable();
                            table_column_update_name = genel.Select(table_info_select, SQLupdate2);
                            genel.VeritabaniBaglantisiniKapatma(SQLupdate2);

                            for (int j = 0; j < table_column_update_name.Rows.Count; j++)
                            {
                                builder.Append(table_column_update_name.Rows[j][0].ToString());
                                if (j != table_column_update_name.Rows.Count - 1)
                                {
                                    builder.Append(", ");
                                }
                            }
                            builder.Append(")" + Environment.NewLine);
                            builder.Append("values ('U', ");

                            /**
                             * \brief OLD bilgileri yeni bilgilerle degistirmek icin kullanilir.
                             */
                            for (int j = 0; j < table_column_update_name.Rows.Count; j++)
                            {
                                builder.Append("NEW." + table_column_update_name.Rows[j][0].ToString());
                                if (j != table_column_update_name.Rows.Count - 1)
                                {
                                    builder.Append(", ");
                                }
                            }
                            builder.Append(");	");
                            builder.Append(Environment.NewLine + "RETURN NEW;" + Environment.NewLine + "END;" + Environment.NewLine + "$$ language plpgsql; " + Environment.NewLine + Environment.NewLine);

                            /**
                             * \brief TRIGGERLAR olustulur. Buradaki ifadeyi kullanaraktan her tablo icin delete triggeri
                             * olusturulur.
                             */
                            builder.Append("CREATE TRIGGER TG_UPT_" + table_name_update.Rows[i][0].ToString() + Environment.NewLine);
                            builder.Append("AFTER UPDATE ON " + table_name_update.Rows[i][0].ToString() + Environment.NewLine);
                            builder.Append("FOR EACH ROW EXECUTE PROCEDURE func_upt_" + table_name_update.Rows[i][0].ToString() + "();" + Environment.NewLine + Environment.NewLine);

                        }

                        /**
                         * \brief Donusumunu sagladigimiz TRIGGERLAR hedef konumundaki dosyanin uzerine yazilir.
                         */
                        sw = new StreamWriter(destinationTextBox.Text);
                        sw.Write(builder);
                        sw.Close();
                        MessageBox.Show("Converting is succesful!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Source TextBox's or Destination TextBox's Text is empty!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (optionComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("You didn't choose any option!", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}