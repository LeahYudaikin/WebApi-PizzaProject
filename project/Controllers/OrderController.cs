using pizza_project.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pizza_project.project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private IOrder MyOrder;
    public OrderController(IOrder MyOrder)
    {
        this.MyOrder = MyOrder;
        MyOrder.Date = DateTime.Now;
        Console.WriteLine(MyOrder.Date);
    }

    [HttpGet]
    public ActionResult <List<Order>> GetAll() =>
        MyOrder.GetAll();

    [HttpGet("{id}")]
    public ActionResult <Order> Get(int id)
    {
        var order = MyOrder.Get(id);

        if(order == null)
            return NotFound();

        return order;
    }

    [HttpPost]
    public IActionResult Add(Order order)
    {
        MyOrder.AddOrder(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        MyOrder.Delete(id);
        return Ok();
    }

}