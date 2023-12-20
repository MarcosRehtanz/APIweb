using System.Reflection.Metadata.Ecma335;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController() { }

    //? get
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();

    //? get 1
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    //? post -c "{"name":"Hawai", "isGlutenFree":false}"
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // class P
    // {
    //     public static required string Name { get; set; }
    //     public static bool IsGlutenFree { get; set; }
    // }

    //? post 3 -c "{"name":"Hawai", "isGlutenFree":false}"
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        // if (id != pizza.Id)
        //     return BadRequest();

        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        pizza.Id = id;

        PizzaService.Update(pizza);
        return CreatedAtAction(nameof(Get), new { id }, pizza);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);
        return NoContent();
    }
}