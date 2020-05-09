using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectLibrary.Services
{
    /// <summary>
    /// This class is a flight api that sends data to the server and process data recieved from the server asynchronously.
    /// </summary>
    public class FlightsProcessor : IFlightsProcessor
    {
        public ApiHelper ApiHelper { get; set; }

        public FlightsProcessor()
        {
            ApiHelper = new ApiHelper();
        }

        public async Task<List<Flight>> GetFlights()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("flights"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Flight> flights = await response.Content.ReadAsAsync<List<Flight>>();
                    Console.WriteLine("Flights are loaded from the server.");
                    return flights;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<Flight> GetFlight(string flightId)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"flights/{flightId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    Flight flight = await response.Content.ReadAsAsync<Flight>();
                    Console.WriteLine($"Flight {flight.Id} is loaded from the server.");
                    return flight;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        public async void AddFlight(Flight flight)
        {
            FlightDto flightToUpdate = new FlightDto(flight.Id, flight.FlightStateType, flight.CurrentStation.Id);
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync<FlightDto>($"flights/one", flightToUpdate))
            {
                Console.WriteLine($"Flight {flight.Id} is added successfully to the database.");
            }
        }

        public async void AddFlights(List<Flight> flights)
        {
            List<FlightDto> flightsDto = new List<FlightDto>();

            // converting all the flights of type Flight to FlightDto class to send to the server.
            foreach (var flight in flights)
            {
                var stattionId = flight.CurrentStation != null ? flight.CurrentStation.Id : 100;
                flightsDto.Add(new FlightDto(flight.Id, flight.FlightStateType, stattionId));
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync<List<FlightDto>>($"flights", flightsDto))
            {
                Console.WriteLine("All the flights successfully added to the database.");
            }
        }

        public async Task DeleteFlight(Flight flight)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync($"flights/{flight.Id}"))
            {
                Console.WriteLine($"Flight {flight.Id} is deleted successfully.");
                return;
            }
        }

        public async Task DeleteFlights()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync($"flights"))
            {
                Console.WriteLine($"All the flights are deleted successfully from the database.");
                return;
            }
        }

        public async Task UpdateFlight(Flight flight)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync($"flights/{flight.Id}", flight))
            {
                Console.WriteLine($"Flight {flight.Id} is updated in the database.");
                return;
            }
        }
    }
}
