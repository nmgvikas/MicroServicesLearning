using Microsoft.AspNetCore.Mvc;
using Ng.WebApi.MongoDb.RabbitMQ.Models;
using Ng.WebApi.MongoDb.RabbitMQ.Services;

namespace Ng.WebApi.MongoDb.RabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepositoryService _dataService;

        public CustomersController(ICustomerRepositoryService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public ActionResult<List<Customer>> Index()
        {
            return _dataService.GetAllCustomers().ToList();
        }
        [HttpGet]
        [Route("id")]
        public Customer GetCustomerById(int id)
        {
            return _dataService.GetCustomerById(id);
        }
        [HttpPost]
        public Customer AddNewCustomer(Customer customer)
        {

            return _dataService.AddNewCustomer(customer);
        }
        [HttpPut]
        [Route("id")]
        public Customer UpdateCustomer(int id, Customer customer)
        {

            return _dataService.UpdateCustomer(id,customer);
        }

        [HttpDelete]
        [Route("id")]
        public Customer RemoveCustomer(int id, Customer customer)
        {

            return _dataService.RemoveCustomer(id, customer);
        }

        [HttpGet]
        [Route("searchByName/{name}")]
        public List<Customer> SearchCustomersByName(string name)
        {

           return _dataService.SearchCustomersByName(name);
        }
    }
}
