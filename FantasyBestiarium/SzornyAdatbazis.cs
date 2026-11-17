using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace FantasyBestiarium
{
    internal class SzornyAdatbazis
    {
        private readonly string connectionString = "server=localhost;database=fantasybestariumdb;uid=root;pwd=";

        public SzornyAdatbazis(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Szorny> Feltolt()
        {
            var szornyek = new List<Szorny>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM szornyek";
                using(MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            szornyek.Add(new Szorny(
                                reader.GetInt32("Id"),
                                reader.GetString("Nev"),
                                reader.GetInt32("VeszelyessegiSzint"),
                                reader.GetString("Elohely"),
                                reader.GetString("FoGyengeseg"),
                                reader.GetString("LeggyakoribbZsakmany"),
                                reader.GetBoolean("VeszelyesE")


                                ));
                        }
                    }
                }
            }


                return szornyek;
        }
    }
}
