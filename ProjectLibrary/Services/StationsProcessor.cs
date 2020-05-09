using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectLibrary.Services
{
    /// <summary>
    /// This class is a station api that sends data to the server and process data recieved from the server asynchronously.
    /// </summary>
    public class StationsProcessor : IStationsProcessor
    {
        public ApiHelper ApiHelper { get; set; }

        public StationsProcessor()
        {
            ApiHelper = new ApiHelper();
        }

        public async Task<List<Station>> LoadStations()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("stations"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Station> stations = await response.Content.ReadAsAsync<List<Station>>();
                    Console.WriteLine("All the stations are loaded.");
                    return stations;
                }
                else
                {
                    Console.WriteLine("Unable to load stations from database");
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Station> LoadStation(int stationId)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync($"stations/{stationId}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    Station station = await response.Content.ReadAsAsync<Station>();
                    Console.WriteLine($"Station number {station.Id} is loaded.");
                    return station;
                }
                else
                {
                    Console.WriteLine($"Unable to load station {stationId} from the database.");
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task DeleteStations()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync("stations/delete"))
            {
                Console.WriteLine("All the stations are successfully deleted from the database.");
            }
        }

        public async Task UpdateStations(List<Station> stationsToUpdate)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync("stations", stationsToUpdate))
            {
                Console.WriteLine($"All the stations are updated");
                return;
            }
        }
    }
}
