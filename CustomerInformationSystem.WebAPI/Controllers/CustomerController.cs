using CustomerInformationSystem.Business.Services.Customers;
using CustomerInformationSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformationSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            //Gets all customers list
            var customers = await _customerService.GetAllAsync();

            //Check customers null control
            if (customers is null)
                throw new ArgumentNullException(nameof(customers));

            return customers.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            //Gets customer by id
            var customer = _customerService.GetById(id);

            //Check customer null control
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                //Check customer null control
                if (customer is null)
                    throw new ArgumentNullException(nameof(customer));

                //Add customer
                await _customerService.AddAsync(customer);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            try
            {
                //Check customer null control
                if (customer is null)
                    throw new ArgumentNullException(nameof(customer));

                //Update customer
                await _customerService.UpdateAsync(customer);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //Check id 0 or null control
                if (id == 0 || string.IsNullOrEmpty(id.ToString()))
                    throw new ArgumentNullException(nameof(id));

                //Delete customer
                await _customerService.DeleteByIdAsync(id);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
