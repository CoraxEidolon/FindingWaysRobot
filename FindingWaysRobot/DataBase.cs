using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using System.Windows.Forms;

namespace FindingWaysRobot
{
    class DataBase
    {     
        public static String connectionString; //Подключение к БД
        public static bool editTable=false; //Разрешить редактировать таблицу
        public static string currentTableName; //имя текущей таблицы

        /* Метод производит запросы которые возвращают значения */
        public string[] InquiryReturnValue(string inquiry)
        {          
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(inquiry, npgSqlConnection);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
            List<string> arResult = new List<string>();
            if (npgSqlDataReader.HasRows)
            {         
                while (npgSqlDataReader.Read())
                {
                    arResult.Add(npgSqlDataReader.GetString(0));
                }
            }
            npgSqlConnection.Close();
            return (arResult.ToArray());
        }

        /* Метод производит запросы которые НЕ возвращают значения */
        public string[] InquiryNOReturnValue(string inquiry)
        {
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();          
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(inquiry, npgSqlConnection);
            List<string> arResult = new List<string>();
            int count = npgSqlCommand.ExecuteNonQuery();
            npgSqlConnection.Close();
            return (arResult.ToArray());
        }

        /* Метод возвращает ВСЕ таблицы БД */
        public string[] AllTable()
        {
            try
            {
                NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
                npgSqlConnection.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT table_name FROM information_schema.tables  WHERE table_schema='public' ORDER BY table_name;", npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                List<string> arResult = new List<string>();
                if (npgSqlDataReader.HasRows)
                {
                    while (npgSqlDataReader.Read())
                    {
                        arResult.Add(npgSqlDataReader.GetString(0));
                    }
                }
                return (arResult.ToArray());
            }
            catch
            {
                List<string> arResult = new List<string>();
                MessageBox.Show("Не удалось выполнить подключение к БД. Проверьте подключение в настройках программы.");
                return (arResult.ToArray());
            }



          
        }//AllTable

        /* Проверяет таблицу на корректность */
        public bool verificationMap(string mapName)
        {
            bool OK = true;
            if (MapEdit.installRobot == false && MapEdit.installFinish == false)
            {
                OK = false;
                MessageBox.Show("Необходимо установить робота и финишную точку!");
            }
            else
            {
                if (mapName == "")
                {
                    OK = false;
                    MessageBox.Show("Название карты не может быть пустым!");
                }
                else
                {

                    if (editTable == false)
                    {
                        string[] tableName = AllTable();
                        for (int i = 0; i < tableName.Length; i++)
                        {
                            if (tableName[i] == mapName)
                            {
                                OK = false;
                                MessageBox.Show("Имя карты должно быть уникальным! Имя «" + mapName + "» уже занято.");
                                break;
                            }
                        }
                    }
                }
            }

            return (OK);
        }


        /* Метод проверяет подключение к БД */
        public static bool checkСonnection(string connectionTest)
        {
          
            bool OK = false;
            try
            {
                NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionTest);
                npgSqlConnection.Open();
                npgSqlConnection.Close();
                OK = true;
            }
            catch
            {
                OK = false;
            }
      
            return (OK);
        }








    }//class
}
