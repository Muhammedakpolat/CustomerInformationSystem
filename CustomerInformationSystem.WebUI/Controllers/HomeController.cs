using CustomerInformationSystem.Core.CustomHelpers;
using CustomerInformationSystem.Entities.Concrete;
using CustomerInformationSystem.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerInformationSystem.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _httpClient = new HttpClient();
        private readonly CustomerAPIHelper _customerAPIHelper = new CustomerAPIHelper();

        public HomeController()
        {
            _httpClient = _customerAPIHelper.InitializeAPI();
        }

        public async Task<IActionResult> Index()
        {
            CustomerViewModel model = new CustomerViewModel();
            List<Customer> customers = new List<Customer>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("api/Customer");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = await httpResponseMessage.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(result);
                model.Customers = customers;
            }
            else
            {
                return BadRequest();
            }




            return View(model);
        }

        public IActionResult AddCustomer(Customer customer)
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
