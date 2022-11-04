using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace lab_4_programming
{
    internal class GasStation
    {
        static void Main(string[] args)
        {
            /*
            Singleton.GetInstance();
            SQLiteConnection conn = Singleton.GetInstance();
            
            string Table = "CREATE TABLE GasStation " +
                "(" +
                "id integer PRIMARY KEY AUTOINCREMENT," +
                "adress varchar(64) not null," +
                "company varchar(64) not null," +
                "benzin REAL not null," +
                "A_80 INTEGER not null," +
                "A_92 INTEGER not null," +
                "A_95 INTEGER not null," +
                "A_80_price INTEGER not null," +
                "A_92_price INTEGER not null," +
                "A_95_price INTEGER not null" +
                ")";
            SQLiteCommand cmd = new SQLiteCommand(Table, conn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            */

            GasStationTable table = new GasStationTable();
            GasStation gasStation = new GasStation("st.Gagarina 16", "WOG", 1000, 1500, 2000, 45, 50, 55);

            table.Save(gasStation);

            Console.WriteLine(gasStation.id);

            foreach (var item in table.GetAll())
            {
                Console.WriteLine(item);
            }

            gasStation.adress = "qwer";
            table.Save(gasStation);

            foreach (var item in table.GetAll())
            {
                Console.WriteLine(item);
            }

            table.Remove(gasStation);

            foreach (var item in table.GetAll())
            {
                Console.WriteLine(item);
            }

            GasStation gasStation1 = table.GetById(1);
            Console.WriteLine(gasStation1);

            Console.WriteLine(table.GetAvg(2));

            Singleton.CloseConnection();

        }
    }
}
