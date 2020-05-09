using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProjectLibrary.Services
{
    /// <summary>
    /// Service class that sends and recieve data from the airport api.
    /// </summary>
    public class ApiHelper
    {
        /// <summary>
        /// This property represent the interface that prefome the connection to the api.
        /// </summary>
        public HttpClient ApiClient { get; set; }

        public ApiHelper()
        {
            InitializeClient();
        }

        /// <summary>
        /// Initialize the ApiClient, sets the base URI of the airport api and define the media type that the ApiClient accepts.
        /// </summary>
        private void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("http://localhost:60752/api/airport/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
