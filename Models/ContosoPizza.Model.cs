namespace ContosoPizza.Models;
// record Pizza(int Id, string Name, bool IsGlutenFree);
public class Pizza
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required bool IsGlutenFree { get; set; }
};

