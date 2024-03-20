using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;


namespace MVC_API.Controllers
{
    public class CoctailController : Controller
    {
        public async Task<IActionResult> Index()
        {

            List<CoctailViewModel> drinks = new List<CoctailViewModel>();

            string url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail";

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await httpClient.GetAsync(url);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                JObject  json = JObject.Parse(results);
                JArray drinkArray = (JArray)json["drinks"];
                drinks = drinkArray.ToObject<List<CoctailViewModel>>();
            }
            else
            {
                Console.WriteLine("error calling web api");
            }

            return View(drinks);
        }
    }
}
