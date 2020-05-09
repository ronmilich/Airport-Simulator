using AirportSimulator.API.Models;
using AirportSimulator.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AirportSimulator.API.Controllers
{
    /// <summary>
    /// Flights Controller
    /// </summary>
    [Route("api/airport/flights")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;

        public FlightsController(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Gets all the flights from database.
        /// </summary>
        /// <returns>Returns list of flights.</returns>
        [HttpGet]
        public ActionResult<List<Flight>> GetFlights()
        {
            var flights = _airportRepository.GetFlights();
            List<FlightDto> flightsDto = new List<FlightDto>();

            if (flights == null)
                return NotFound();

            foreach (Flight flight in flights)
            {
                var station = _airportRepository.GetStation(flight.StationId);

                if (station != null)
                {
                    station.IsOccupied = true;
                    station.CurrentFlight = flight.Id;
                }

                flightsDto.Add(new FlightDto()
                {
                    Id = flight.Id,
                    FlightStateType = flight.FlightStateType,
                    CurrentStation = station
                });
            }

            return Ok(flightsDto);
        }

        /// <summary>
        /// Get single flight using the flight id.
        /// </summary>
        /// <param name="flightId">Flight id.</param>
        /// <returns>Return single flight from database</returns>
        [HttpGet("{flightId}")]
        public ActionResult<List<Flight>> GetFlight(string flightId)
        {
            var flight = _airportRepository.GetFlight(flightId);

            if (flight == null)
                return NotFound();

            FlightDto flightDto = new FlightDto()
            {
                Id = flight.Id,
                FlightStateType = flight.FlightStateType,
                CurrentStation = _airportRepository.GetStation(flight.StationId)
            };

            return Ok(flightDto);
        }

        /// <summary>
        /// Delete single flight using the flight id.
        /// </summary>
        /// <param name="flightId">Flight id.</param>
        /// <returns>Returns no content status code or not found.</returns>
        [HttpDelete("{flightId}")]
        public ActionResult DeleteFlight(string flightId)
        {
            var flight = _airportRepository.GetFlight(flightId);

            if (flight == null)
                return NotFound();

            _airportRepository.DeleteFlight(flight);
            _airportRepository.Save();
            return NoContent();
        }

        /// <summary>
        /// Update specific flight.
        /// </summary>
        /// <param name="flightId">Flight id.</param>
        /// <param name="flight">Flight update details.</param>
        /// <returns>Returns No content if flight is updated successfully.</returns>
        [HttpPut("{flightId}")]
        public ActionResult UpdateFlight(string flightId, [FromBody] Flight flight)
        {
            if (flight == null)
                return BadRequest();

            var flightToUpdate = _airportRepository.GetFlight(flightId);

            if (flightToUpdate == null)
                return NotFound();

            flightToUpdate = flight;
            _airportRepository.Save();

            return NoContent();
        }

        /// <summary>
        /// Add single flight to the database.
        /// </summary>
        /// <param name="flight">Flight to add.</param>
        /// <returns>Returns No content if flight is added successfully.</returns>
        [HttpPut("one")]
        public ActionResult AddFlight([FromBody] Flight flight)
        {
            if (flight == null)
                return BadRequest();

            _airportRepository.AddFlight(flight);
            _airportRepository.Save();
            return NoContent();
        }

        /// <summary>
        /// Add a list of flights to the database. 
        /// </summary>
        /// <param name="flights">flights list to add.</param>
        /// <returns>Returns No content if flights is added successfully.</returns>
        [HttpPut]
        public ActionResult AddFlights([FromBody] List<Flight> flights)
        {
            if (flights == null)
                return BadRequest();

            _airportRepository.AddFlights(flights);
            _airportRepository.Save();
            return NoContent();
        }

        /// <summary>
        /// Delete all flights from database
        /// </summary>
        /// <returns>Returns No Content</returns>
        [HttpDelete]
        public ActionResult DeleteFlights()
        {
            _airportRepository.DeleteAllFlights();
            _airportRepository.Save();
            return NoContent();
        }


    }
}