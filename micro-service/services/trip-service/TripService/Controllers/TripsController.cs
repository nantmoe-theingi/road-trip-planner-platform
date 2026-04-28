using Microsoft.AspNetCore.Mvc;
using TripService.Models;

namespace TripService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private static readonly List<Trip> Trips =
    [
        new Trip
        {
            Id = 1,
            Title = "Auckland to Rotorua",
            StartLocation = "Auckland",
            Destination = "Rotorua",
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddDays(2)
        }
    ];

    [HttpGet]
    public ActionResult<List<Trip>> GetTrips()
    {
        Console.Write("success");
        return Ok(Trips);
    }

    [HttpGet("{id}")]
    public ActionResult<Trip> GetTripById(int id)
    {
        var trip = Trips.FirstOrDefault(t => t.Id == id);

        if (trip == null)
        {
            return NotFound();
        }

        return Ok(trip);
    }

    [HttpPost]
    public ActionResult<Trip> CreateTrip(Trip trip)
    {
        trip.Id = Trips.Count + 1;
        Trips.Add(trip);

        return CreatedAtAction(nameof(GetTripById), new { id = trip.Id }, trip);
    }
}