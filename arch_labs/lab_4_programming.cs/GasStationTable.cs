using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace lab_4_programming
{
    internal class GasStationTable
    {
        private string tableName;
        public GasStationTable()
        {
            tableName = "GasStation";
        }
        public GasStation GetById(int id)
        {
            GasStation gasStation = null;
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM " + tableName + " WHERE id = @Id", conn))
            {
                SQLiteParameter param = new SQLiteParameter();
                param.ParameterName = "@Id";
                param.Value = id;

                command.Parameters.Add(param);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    gasStation = new GasStation
                    {
                        id = Convert.ToInt32(reader[0].ToString()),
                        adress = reader[1].ToString(),
                        company = reader[2].ToString(),
                        benzin = Convert.ToDouble(reader[3].ToString()),
                        A_80 = Convert.ToInt32(reader[4].ToString()),
                        A_92 = Convert.ToInt32(reader[5].ToString()),
                        A_95 = Convert.ToInt32(reader[6].ToString()),
                        A_80_price = Convert.ToInt32(reader[7].ToString()),
                        A_92_price = Convert.ToInt32(reader[8].ToString()),
                        A_95_price = Convert.ToInt32(reader[9].ToString()),
                    };
                }
                reader.Close();
                return gasStation;
            }
        }

        public IEnumerable<GasStation> GetAll()
        {
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM " + tableName, conn))
            {
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GasStation gasStation = new GasStation
                    {
                        id = Convert.ToInt32(reader[0].ToString()),
                        adress = reader[1].ToString(),
                        company = reader[2].ToString(),
                        benzin = Convert.ToDouble(reader[3].ToString()),
                        A_80 = Convert.ToInt32(reader[4].ToString()),
                        A_92 = Convert.ToInt32(reader[5].ToString()),
                        A_95 = Convert.ToInt32(reader[6].ToString()),
                        A_80_price = Convert.ToInt32(reader[7].ToString()),
                        A_92_price = Convert.ToInt32(reader[8].ToString()),
                        A_95_price = Convert.ToInt32(reader[9].ToString()),
                    };
                    yield return gasStation;
                }
                reader.Close();
            }
        }

        public int GetAvg(int x)
        {
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("SELECT AVG(benzin) FROM " + tableName + " WHERE A_80_price + A_92_price + A_95_price > " + x, conn))
            {
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
                }
                return 0;
            }
        }

        public void Save(GasStation gasStation)
        {
            SQLiteConnection conn = Singleton.GetInstance();

            SQLiteCommand command = null;

            if (gasStation.id < 1)
            {
                using (command = new SQLiteCommand("INSERT INTO " + tableName + "(adress, company, benzin, A_80, A_92, A_95, A_80_price, A_92_price, A_95_price) " +
                    "VALUES (@adress, @company, @benzin, @A_80, @A_92, @A_95)", conn))
                {
                    command.Parameters.AddWithValue("@adress", gasStation.adress);
                    command.Parameters.AddWithValue("@company", gasStation.company);
                    command.Parameters.AddWithValue("@benzin", gasStation.benzin);
                    command.Parameters.AddWithValue("@A_80", gasStation.A_80);
                    command.Parameters.AddWithValue("@A_92", gasStation.A_92);
                    command.Parameters.AddWithValue("@A_95", gasStation.A_95);
                    command.Parameters.AddWithValue("@A_80_price", gasStation.A_80_price);
                    command.Parameters.AddWithValue("@A_92_price", gasStation.A_92_price);
                    command.Parameters.AddWithValue("@A_95_price", gasStation.A_95_price);
                    command.ExecuteNonQuery();
                    command.CommandText = "Select seq from sqlite_sequence where name = '" + tableName + "'";
                    gasStation.id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            else
            {
                using (command = new SQLiteCommand("UPDATE " + tableName +
                    " SET adress = @adress, company = @company, benzin = @benzin, A_80 = @A_80, A_92 = @A_92, A_95 = @A_95, A_80_price = @A_80_price, A_92_price = @A_92_price, A_95_price = @A_95_price " +
                    " WHERE id = @id", conn))
                {
                    command.Parameters.Add(new SQLiteParameter("@adress", gasStation.adress));
                    command.Parameters.Add(new SQLiteParameter("@company", gasStation.company));
                    command.Parameters.Add(new SQLiteParameter("@benzin", gasStation.benzin));
                    command.Parameters.Add(new SQLiteParameter("@A_80", gasStation.A_80));
                    command.Parameters.Add(new SQLiteParameter("@A_92", gasStation.A_92));
                    command.Parameters.Add(new SQLiteParameter("@A_95", gasStation.A_95));
                    command.Parameters.Add(new SQLiteParameter("@A_80_price", gasStation.A_80_price));
                    command.Parameters.Add(new SQLiteParameter("@A_92_price", gasStation.A_92_price));
                    command.Parameters.Add(new SQLiteParameter("@A_95_price", gasStation.A_95_price));
                    command.Parameters.Add(new SQLiteParameter("@id", gasStation.id));
                    command.ExecuteNonQuery();
                }
            }

        }

        public void Remove(GasStation gasStation)
        {
            SQLiteConnection conn = Singleton.GetInstance();

            using (SQLiteCommand command = new SQLiteCommand("DELETE FROM " + tableName + " WHERE id = @id", conn))
            {
                command.Parameters.Add(new SQLiteParameter("@id", gasStation.id));
                command.ExecuteNonQuery();
                gasStation.id = 0;
            }
        }
    }
}
