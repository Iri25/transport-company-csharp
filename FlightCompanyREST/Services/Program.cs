using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Caut zborul cu ID-ul 2");
            Flight flightById = await FindOne("http://localhost:8080/flights/2");
            Console.WriteLine("Am gasit zborul cu ID-ul 2!");
            Console.WriteLine("Zborul este: " + flightById.ToString());
            Console.WriteLine();

            Console.WriteLine("Afisez toate zborurile");
            foreach (Flight flight in await FindAll("http://localhost:8080/flights/"))
            {
                Console.WriteLine(flight.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Adaug un zbor cu ID-ul 8");
            Flight flightAdd = new Flight();
            flightAdd.Id = 8; flightAdd.Destination = "Timisoara"; flightAdd.DepartureDate = "2021-05-19"; flightAdd.DepartureTime = "21:00"; flightAdd.Airport = "International"; flightAdd.NumberOfSeats = 40;
            Flight add = await Save("http://localhost:8080/flights/", flightAdd);
            Console.WriteLine("Am adaugat un zbor cu ID-ul 8!");
            Console.WriteLine(flightAdd.ToString());
            //Console.WriteLine("Zborul este: " + add.ToString());
            Console.WriteLine();

            Console.WriteLine("Afisez toate zborurile");
            foreach (Flight flight in await FindAll("http://localhost:8080/flights/"))
            {
                Console.WriteLine(flight.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Actualizez un zbor");
            Flight flightUpdate = new Flight();
            flightAdd.Id = 6; flightAdd.Destination = "Timisoara"; flightAdd.DepartureDate = "2021-05-18"; flightAdd.DepartureTime = "11:00"; flightAdd.Airport = "International"; flightAdd.NumberOfSeats = 50;
            Flight update = await Update("http://localhost:8080/flights/", flightUpdate);
            Console.WriteLine("Am actualizat zborul cu ID-ul 6!");
            //Console.WriteLine("Zborul este: " + update.ToString());
            Console.WriteLine(flightUpdate.ToString());
            Console.WriteLine();

            Console.WriteLine("Afisez toate zborurile");
            foreach (Flight flight in await FindAll("http://localhost:8080/flights/"))
            {
                Console.WriteLine(flight.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Sterg un zbor");
            await client.DeleteAsync("http://localhost:8080/flights/8");
            Console.WriteLine("Am sters zborul cu ID-ul 8!"); 
            Console.WriteLine();

            Console.WriteLine("Zborurile sunt");
            foreach (Flight flight in await FindAll("http://localhost:8080/flights/"))
            {
                Console.WriteLine(flight.ToString());
            }

            Console.Read();
        }

        static async Task<Flight> FindOne(string path)
        {
            Flight flight = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                flight = await response.Content.ReadAsAsync<Flight>();
            }
            return flight;
        }

        static async Task<Flight[]> FindAll(string path)
        {
            Flight[] flight = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                flight = await response.Content.ReadAsAsync<Flight[]>();
            }
            return flight;
        }

        static async Task<Flight> Save(string path, Flight flight)
        {
            Flight result = null;
            HttpResponseMessage response = await client.PostAsJsonAsync<Flight>(path, flight);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Flight>();
            }
            return result;
        }

        static async Task<Flight> Update(string path, Flight flight)
        {
            Flight result = null;
            HttpResponseMessage response = await client.PutAsJsonAsync<Flight>(path, flight);
            if (response.IsSuccessStatusCode)
            {
                result = await FindOne("http://localhost:8080/flights/6");
            }
            return result;
        }
    }
}