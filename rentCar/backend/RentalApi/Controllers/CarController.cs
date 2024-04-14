using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RentalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2020, Color = "White", Price = 25 },
            new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2019, Color = "Black", Price = 30 },
            new Car { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021, Color = "Red", Price = 60 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = cars.Find(c => c.Id == id);
            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> AddCar(Car car)
        {
            cars.Add(car);
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, Car updatedCar)
        {
            var car = cars.Find(c => c.Id == id);
            if (car == null)
                return NotFound();

            car.Make = updatedCar.Make;
            car.Model = updatedCar.Model;
            car.Year = updatedCar.Year;
            car.Color = updatedCar.Color;
            car.Price = updatedCar.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = cars.Find(c => c.Id == id);
            if (car == null)
                return NotFound();

            cars.Remove(car);
            return NoContent();
        }
    }
}
