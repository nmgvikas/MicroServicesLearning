using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace _02FirstMVCDemo.Controllers
{
    public class HelloWorldController : Controller
    {
        public ContentResult Index()
        {
            ContentResult myContent = new ContentResult();
            myContent.Content = $"<h1>Welcome to First MVC Demo {DateTime.Now.ToString()}</h1>";
            myContent.ContentType = "text/html" ;

            return myContent;

        }
        //An Action with a parameter
        [ActionName("Index2")]
        public ContentResult Index(int id)
        {
            ContentResult myContent = new ContentResult();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < id; i++)
            {
                stringBuilder.Append($"<h1>Welcome to First MVC Demo {DateTime.Now.ToString()}</h1>");
            }
            myContent.Content = stringBuilder.ToString();

            myContent.ContentType = "text/html";

            return myContent;

        }
        //Controller Action that send the data to a View for Rendering
        public IActionResult ListCountries()
        {
                List<Country> countries = new List<Country>();
            countries.Add(new Country { FullName = "India", ShortName = "IN", Currency = "₹" });
            countries.Add(new Country { FullName = "Nepal", ShortName = "NP", Currency = "रू" });
            countries.Add(new Country { FullName = "Srilanla", ShortName = "SL", Currency = "රු" });
            //View Data is a Dictionary - Data stored in Binary without typing
            ViewData["Today"] = DateTime.Now.Date;
            ViewBag.Now = DateTime.Now;


            
            return View(countries);

        }
         

          
    }
    public class Country
    {
        public string FullName { get; set; }
        public string ShortName { get;set; }
        public string Currency { get; set; }
    }
}
