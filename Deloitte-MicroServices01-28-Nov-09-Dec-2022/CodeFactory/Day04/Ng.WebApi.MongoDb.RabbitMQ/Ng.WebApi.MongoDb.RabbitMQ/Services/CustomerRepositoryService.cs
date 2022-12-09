using Ng.WebApi.MongoDb.RabbitMQ.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace Ng.WebApi.MongoDb.RabbitMQ.Services
{
    //Self Configuring Service
    public class CustomerRepositoryService : ICustomerRepositoryService
    {

        private readonly IMongoCollection<Customer> _customers;
        //c'tor injected with the config
        public CustomerRepositoryService(IConfiguration config) {

            var mongoClient = new MongoClient(config.GetConnectionString("MyCustomerDB"));
            var database = mongoClient.GetDatabase("customerDb");
            //lazily loaded
            this._customers = database.GetCollection<Customer>("customers");
        }

        public Customer AddNewCustomer(Customer customerToAdd)
        {
            _customers.InsertOne(customerToAdd);
            return customerToAdd;
        }
        
        public List<Customer> GetAllCustomers()
        {
            return this._customers.Find<Customer>(Customer => true).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return this._customers.Find(cust => cust.Id == id).FirstOrDefault();
           
        }

        public Customer RemoveCustomer(int id, Customer customerToRemove)
        {
            this._customers.DeleteOne<Customer>(cust => cust.Id == id);
            return customerToRemove;
        }

        public Customer UpdateCustomer(int id, Customer customertoUpdate)
        {
            this._customers.ReplaceOne<Customer>(cust => cust.Id == id,customertoUpdate);
            return customertoUpdate;
        }

       public  List<Customer> SearchCustomersByName(string searchString)
        {
           return  this._customers.Find<Customer>(cust => cust.Name.Contains(searchString)).ToList();
        }
    }
}
