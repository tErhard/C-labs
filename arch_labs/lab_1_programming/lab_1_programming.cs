using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Program
    {
        public class Airport
        {
            protected double id;
            public double Id { get { return id; } set { id = value; } }
            // { get; set; } в цьому випадку не працює тому що атрибут повертає інший атрибут

            protected string fligh_num_city;
            public string Fligh_num_city { get { return fligh_num_city; } set { fligh_num_city = value; } }

            protected int seats;
            public int Seats { get { return seats; } set { seats = value; } }
            
            protected int flight_time;
            public int Flight_time { get { return flight_time; } set { flight_time = value; } }

            protected string ticket_price;
            public string Ticket_price { get { return ticket_price; } set { ticket_price = value; } }


            public Airport(int id, string fligh_num_city, int seats, int flight_time, string ticket_price )
            {
                this.id = id;
                this.fligh_num_city = fligh_num_city;
                this.seats = seats;
                this.flight_time = flight_time;
                this.ticket_price = ticket_price;
            }

            public override string ToString()
            {
                return $" Fligght to:{fligh_num_city} , seats:{seats} , flight time:{flight_time} hours, price: {ticket_price} . ";
            }
        }

        public interface IListAirports
        {
            void Add(Airport airport);
            void Delete(int id);
            void Show();
        }

        public class ListAirports : IListAirports
        {
            protected List<Airport> airports;
            public List<Airport> Airports { get { return airports; } set { airports = value; } }

            public ListAirports(List<Airport> airports)
            {
                this.airports = airports;
            }

            public void Add(Airport airport)
            {
                airports.Add(airport);
            }
            public void Delete(int id)
            {
                try
                {
                    airports = airports.Where(item => item.Id != id).ToList();
                }
                catch (Exception exexception)
                {
                    Console.WriteLine(exexception.Message);
                    Console.WriteLine("Smth wrong, check the id.");
                }
            }
            public void Show()
            {
                foreach (Airport airport in airports)
                {
                    Console.WriteLine(airport);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            ListAirports passengers = new ListAirports(
                new List<Airport>
                {
                    new Airport(1, "Berlin 401", '9', '5', "200$"),
                    new Airport(2, "Kiev 402", '7', '3', "350$"),
                    new Airport(3, "Tokio 403", '4', '7', "150$"),
                    new Airport(4, "New York 404", '3', '7', "100$"),
                    new Airport(5, "Madrid 405", '9', '8', "450$"),
                    new Airport(6, "Istambul 406", '6','1', "400$"),
                }
            );


            var task1 = passengers.Airports.Where(item => item.Flight_time <= '5' );

            foreach (var item in task1)
            {
                Console.WriteLine($"Passengers: {item.Seats},who fly to {item.Fligh_num_city}, and fly no longer that 5 hours");
            }
        }
    }
}
