using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMicroservice.Data;

namespace MyMicroservice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly MicroDbContext _microDbContext;

    public PersonController(MicroDbContext microDbContext)
    {
        _microDbContext = microDbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var persons = _microDbContext.Persons?.OrderBy(p => p.Id);

        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var persons = _microDbContext.Persons?.Find(id);

        return Ok(persons);
    }

    [HttpPost]
    public IActionResult Post([FromBody] PersonRequest person)
    {
        var newPerson = new Persons
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Birthday = person.Birthday
        };

        _microDbContext.Add(newPerson);
        _microDbContext.SaveChanges();

        return Created();
    }

    [HttpPut]
    public IActionResult Put([FromQuery] int id, [FromBody] PersonRequest person)
    {
        var updPerson = _microDbContext.Persons?.Find(id);

        if (updPerson != null)
        {
            updPerson.FirstName = person.FirstName;
            updPerson.LastName = person.LastName;
            updPerson.Birthday = person.Birthday;

            _microDbContext.Entry(updPerson).State = EntityState.Modified;
            _microDbContext.SaveChanges();
        }

        return Ok(updPerson);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        var personToDelete = _microDbContext.Persons?.Find(id);

        if (personToDelete != null)
        {
            _microDbContext.Remove(personToDelete);
            _microDbContext.SaveChanges();
        }

        return Ok(personToDelete);
    }
}