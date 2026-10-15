using HW_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_4.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000 },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000 }
        };


        private static List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public  IActionResult Index()
        {
            return View(availableCars);
        }

        [HttpPost]
        public IActionResult Book(int id)
        {
            for (int i = 0; i < availableCars.Count; i++)
            {
                if (availableCars[i].Id == id)
                {
                    Car carToBook = availableCars[i];
                    availableCars.RemoveAt(i);
                    bookedCars.Add(carToBook);
                    return Redirect(nameof(Booked));
                }
            }
            return Redirect(nameof(Index));

        }
        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }

        [HttpPost]
        public IActionResult Unbook(int id)
        {
            for (int i = 0; i < bookedCars.Count; i++)
            {
                if (bookedCars[i].Id == id)
                {
                    var car = bookedCars[i];
                    bookedCars.RemoveAt(i);
                    availableCars.Add(car);
                    break;
                }
            }
            return RedirectToAction(nameof(Booked));
        }
    }
}
