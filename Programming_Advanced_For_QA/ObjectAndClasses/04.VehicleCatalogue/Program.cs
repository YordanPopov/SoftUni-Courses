using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace _04.VehicleCatalogue
{
    internal class Program
    {
        public class Trucks
        {
            public string Brand {  get; set; }

            public string Model { get; set; }

            public string Weight { get; set; }

            public Trucks(string brand, string model, string weight)
            {
                Brand = brand;
                Model = model;
                Weight = weight;
            }
        }

        public class  Cars
        {
            public string Brand { get; set; }

            public string Model { get; set; }

            public string HorsePower { get; set; }

            public Cars(string brand, string model, string horsePower) 
            {
                Brand= brand;
                Model = model;
                HorsePower = horsePower;
            }
        }

        public class Catalog
        {
            public List<Trucks> Trucks { get; set; }

            public List<Cars> Cars { get; set; }

            public Catalog()
            {
                Trucks = new List<Trucks>();
                Cars = new List<Cars>();
            }
        }
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string[] input = Console.ReadLine().Split("/");

            while (input[0] != "end")
            {
                string type = input[0];
                string brand = input[1];
                string model = input[2];

                if (type == "Car")
                {
                    string horsePower = input[3];
                    Cars currentCar = new Cars(brand, model, horsePower);
                    catalog.Cars.Add(currentCar);

                }
                else if (type == "Truck")
                {
                    string weight = input[3];
                    Trucks currentTruck = new Trucks(brand, model, weight);
                    catalog.Trucks.Add(currentTruck);
                }

                input = Console.ReadLine().Split("/");
            }

            if (catalog.Cars.Count > 0)
            {
                List<Cars> orderedCars = catalog.Cars.OrderBy(car => car.Brand).ToList();

                Console.WriteLine("Cars:");

                foreach (Cars car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                List<Trucks> orderedTrucks = catalog.Trucks.OrderBy(truck => truck.Brand).ToList();

                Console.WriteLine("Trucks:");

                foreach (Trucks truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }  
            }
        }
    }
}