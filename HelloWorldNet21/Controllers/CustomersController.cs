using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldNet21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldNet21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<CustomersController> _logger;

        private HelloDBContext _context;

        public CustomersController(ILogger<CustomersController> logger, HelloDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created("", customer);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();
        }
    }
}
