using AirportSimulator.API.Models;
using AirportSimulator.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AirportSimulator.API.Controllers
{
    /// <summary>
    /// Stations Controller
    /// </summary>
    [Route("api/airport/stations")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;

        public StationsController(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Get all stations from database
        /// </summary>
        /// <returns>Return list of stations</returns>
        [HttpGet]
        public ActionResult<List<Station>> GetStations()
        {
            var stations = _airportRepository.GetStations();

            if (stations == null)
                return NotFound();

            return Ok(stations);
        }

        /// <summary>
        /// Get single station from database.
        /// </summary>
        /// <param name="stationId">Station id.</param>
        /// <returns>Return single station.</returns>
        [HttpGet("{stationId}")]
        public ActionResult<Station> GetStation(int stationId)
        {
            var station = _airportRepository.GetStation(stationId);

            if (station == null)
                return NotFound();

            return Ok(station);
        }

        /// <summary>
        /// Delete all stations from database.
        /// </summary>
        /// <returns>Return No Content</returns>
        [HttpDelete("delete")]
        public ActionResult DeleteStations()
        {
            _airportRepository.DeleteAllStations();
            _airportRepository.Save();

            return NoContent();
        }

        /// <summary>
        /// Update Stations in the database
        /// </summary>
        /// <param name="stationsToUpdate">List of stations to update.</param>
        /// <returns>No content</returns>
        [HttpPut]
        public ActionResult UpdateStations([FromBody] List<Station> stationsToUpdate)
        {
            foreach (Station station in stationsToUpdate)
            {
                var stationFromRepo = _airportRepository.GetStation(station.Id);
                stationFromRepo = station;
            }

            _airportRepository.Save();

            return NoContent();
        }
    }
}