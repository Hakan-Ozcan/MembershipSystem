using MembershipSystemAPI.Database;
using MembershipSystemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MembershipSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly MemberShipDbContext _context;
        public PersonController(MemberShipDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<Person> Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }
        [HttpGet]
        public ActionResult<List<Person>> List()
        {
            return _context.People.ToList();
        }
        [HttpPut("{id}")]
        public ActionResult<Person> Edit(Person person,int id)
        {
            if (person.Id!=id)
            {
                return BadRequest();
            }           
            _context.People.Update(person);       
            _context.SaveChanges();
            return person;

        }
        [HttpDelete("{id}")]
        public ActionResult<Person>Delete(int id)
        {
            if (id==null)
            {
                return BadRequest();
            }
           Person returning = _context.People.FirstOrDefault(x => x.Id == id);
           _context.People.Remove(returning);
            _context.SaveChanges();
            return Ok();
        }

    }
}
