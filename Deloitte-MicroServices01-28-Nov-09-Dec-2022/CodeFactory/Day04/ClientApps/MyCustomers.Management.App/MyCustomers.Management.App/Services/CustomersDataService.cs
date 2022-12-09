using MyCustomers.Management.App.Models;
using System.Net.Http.Json;

namespace MyCustomers.Management.App.Services
{

    public interface ICustomerDataService
    {
        Task<Customer[]> GetCustomersAsync();
        Task<Customer[]> SearchCustomersAsync(string strNameFragment);

    }
    public class CustomersDataService : ICustomerDataService
    {
        private  string customersApiUrl = "http://win10dockersrini2022.eastus.cloudapp.azure.com:7071/api/customers";
        private HttpClient commsSocket { get; set; }

        //c'tor
        public CustomersDataService(HttpClient injectedCommsSocket)
        {
            this.commsSocket = injectedCommsSocket;
        }
        public async Task<Customer[]> GetCustomersAsync()
        {
            var result = await this.commsSocket.GetFromJsonAsync<Customer[]>(this.customersApiUrl);
            return result;
        }

        public async Task<Customer[]> SearchCustomersAsync(string strNameFragment)
        {
            string strSearchUrl = this.customersApiUrl + "/searchByName/" + strNameFragment;
            var result = await this.commsSocket.GetFromJsonAsync<Customer[]>(strSearchUrl);
            return result;
        }

    }
}
