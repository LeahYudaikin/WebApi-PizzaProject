using pizza_project.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pizza_project.project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private IPizza MyPizza;
    public PizzaController(IPizza MyPizza)
    {
        this.MyPizza = MyPizza;
        MyPizza.Date = DateTime.Now;
        Console.WriteLine(MyPizza.Date);
    }

    [HttpGet]
    public ActionResult <List<Pizza>> GetAll() =>
        MyPizza.GetAll();

    [HttpGet("{id}")]
    public ActionResult <Pizza> Get(int id)
    {
        var pizza = MyPizza.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    [Authorize(Policy = "SuperWorker")]
    public IActionResult Add(Pizza pizza)
    {
        MyPizza.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "SuperWorker")]
    public ActionResult UpDate(Pizza pizza)
    {
        var flag = MyPizza.UpDate(pizza);
        if(flag == false)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpDelete("Delete/{id}")]
    [Authorize(Policy = "SuperWorker")]
    public IActionResult Delete(int id)
    {
        MyPizza.Delete(id);
        return Ok();
    }

}