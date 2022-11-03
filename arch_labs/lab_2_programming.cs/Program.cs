using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BaggageXML
{
    public class Baggage
    {
        public int number { get; set; }
        public float weight { get; set; }

        public Baggage(int number, float weight)
        {
            this.number = number;
            this.weight = weight;
        }

        public Baggage()
        {

        }

        public override string ToString()
        {
            return $"The passangers baggage have {number} things, with total weight: {weight}kg.";
        }
    }

    public class Baggages
    {
        public List<Baggage> baggages = new List<Baggage>();

        public Baggages()
        {

        }

        public void Add(int number, float weight)
        {
            baggages.Add(new Baggage(number, weight));
        }

        public void CreatePO(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Baggages));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                serializer.Serialize(fs, this);
            }
        }

        public void ReadPO(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Baggages));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            using (fs)
            {
                Baggages obj = (Baggages)serializer.Deserialize(fs);
                this.baggages = obj.baggages;
            }
        }

        public void Show() 
        {
            int moreThings = this.baggages.Max(x => x.number);
            this.baggages = this.baggages.Where(elem => elem.number < moreThings).ToList();
        }   
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Телінгер Ергард\source\repos\lab_2_programing\lab_2_programing\XMLFile1";

            Baggages baggages = new Baggages();
            baggages.Add(15, 20);
            baggages.Add(16, 40);
            baggages.Add(9, 10);
            baggages.Add(3, 8);
            baggages.Add(11, 45);
            baggages.Add(5, 32);

            baggages.CreatePO(fileName);

            Baggages baggages2 = new Baggages();
            baggages2.ReadPO(fileName);

            baggages2.Show();

            foreach (Baggage baggage in baggages2.baggages)
            {
                Console.WriteLine(baggage.ToString());
            }
            Console.WriteLine();

            var task = baggages.baggages
                .GroupBy(group => $"{group.weight}")
                .Select(item => new { item.Key, Value = item.Count() });

            foreach (var item in task)
            {
                Console.WriteLine($"Total weight: {item.Key}");
            }
            Console.WriteLine();
        }
    }
}
