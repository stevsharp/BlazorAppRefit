using Microsoft.AspNetCore.Mvc;

using Server.Model;

using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>() {
            new Customer(1, "John"),
            new Customer(1, "Stev"),
            new Customer(1, "George")
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        [HttpGet("{id}")]
        public Customer? Get(int id)
        {
            return customers.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            customers.Add(customer);

            return Created();
        }
        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {

            var editCustomer = customers.FirstOrDefault(x => x.Id == id);
            if (editCustomer is not null)
            {
                customers.Remove(editCustomer);
                customers.Add(customer);
            }

            return NoContent();

        }
        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteCustomer = customers.FirstOrDefault(x => x.Id == id);
            if (deleteCustomer is not null)
            {
                customers.Remove(deleteCustomer);
            }

            return NoContent();
        }

    }
}
