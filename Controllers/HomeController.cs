using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> ListDishes = _context.Dishes.ToList();
        return View("Index", ListDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult FormDish()
    {
        return View("FormDish");
    }


    [HttpPost("dishes/add")]
    public IActionResult AddDish(Dish dish)
    {
        if (ModelState.IsValid)
        {
            /*insert into Dishes*/
            _context.Dishes.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("FormDish");

    }

    [HttpGet("dishes/{id_dish}")]
    public IActionResult Dish(int id_dish)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id_dish);
        return View("Dish", dish);
    }

    [HttpGet("dishes/edit/{id_dish}")]
    public IActionResult FormEditDish(int id_dish)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id_dish);
        return View("FormEditDish", dish);
    }

    [HttpPost("dishes/update/{id_dish}")]
    public IActionResult UpdateDish(Dish dish, int id_dish)
    {
        Dish? dishPrev = _context.Dishes.FirstOrDefault(d => d.DishId == id_dish);
        if (ModelState.IsValid)
        {
            dishPrev.Name = dish.Name;
            dishPrev.Chef = dish.Chef;
            dishPrev.Tastiness = dish.Tastiness;
            dishPrev.Calories = dish.Calories;
            dishPrev.Description = dish.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        return View("FormEditDish", dishPrev);

    }



    [HttpPost("dishes/delete/{id_dish}")]

    public IActionResult DeleteDish(int id_dish)
    {
        Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id_dish);
        _context.Dishes.Remove(dish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
