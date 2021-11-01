using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_Net5Udemy.Services;
using RestWithASP_Net5Udemy.Models;

namespace RestWithASP_Net5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
                return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById([FromRoute] long id)
        {
            var person = _personService.FindById(id);

            return person == null ? NotFound() : Ok(_personService.FindById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            _personService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            return person == null ? BadRequest() : Ok(_personService.Update(person));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            var personCreated = _personService.Create(person);
            return Created(string.Format("/persons/{0}", personCreated.Id), personCreated);
        }
    }
}
