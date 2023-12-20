using ContosoPizza.Models;

namespace ContosoPizza.Services;

public class PizzaService
{
    public static List<Pizza> Pizzas { get; set; }
    public static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>([
            new Pizza{Id = 1, Name = "Classic Italian", IsGlutenFree = false},
                new Pizza{Id = 2, Name = "Veggie", IsGlutenFree = true}
        ]);
    }

    public static List<Pizza> GetAll()
    {
        return Pizzas;
    }

    public static Pizza? Get(int Id)
    {
        return Pizzas.FirstOrDefault(p => p.Id == Id);
    }

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int Id)
    {
        var pizza = Get(Id);
        if (pizza is null) return;
        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1) return;
        Pizzas[index] = pizza;
    }
}