using pizza_project.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pizza_project.project.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Admin")]
public class WorkerController : ControllerBase
{
    private IWorker MyWorker;
    public WorkerController(IWorker MyWorker)
    {
        this.MyWorker = MyWorker;
        MyWorker.Date = DateTime.Now;
        Console.WriteLine(MyWorker.Date);
    }

    [HttpGet]
    public ActionResult <List<Worker>> GetAll() =>
        MyWorker.GetAll();

    [HttpGet("{id}")]
    public ActionResult <Worker> Get(int id)
    {
        var worker = MyWorker.Get(id);

        if(worker == null)
            return NotFound();

        return worker;
    }

    [HttpPost]
    public IActionResult Add(Worker worker) 
    {
        MyWorker.Add(worker);
        return CreatedAtAction(nameof(Get), new { id = worker.Id }, worker);
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        MyWorker.Delete(id);
        return Ok();
    }

}