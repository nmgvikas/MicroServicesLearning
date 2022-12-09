using Ng.WebApi.MongoDb.RabbitMQ.Models;

namespace Ng.WebApi.MongoDb.RabbitMQ.Services
{
    public interface ICustomerRepositoryService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);

        Customer AddNewCustomer(Customer customerToAdd);
        Customer UpdateCustomer(int id, Customer customertoUpdate);

        Customer RemoveCustomer(int id, Customer customerToRemove);

        List<Customer> SearchCustomersByName(string searchString);


    }
}
