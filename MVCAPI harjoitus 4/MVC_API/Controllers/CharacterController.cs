using Microsoft.AspNetCore.Mvc;
using MVC_API.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVC_API.Controllers
{
    public class CharacterController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //fetch JSON string from URL
            List<CharacterViewModel> characters = new List<CharacterViewModel>();

        //string url = "https://mocki.io/v1/d4867d8b-b5d5-4a48-a4ab-79131b5809b8";

         string url = "https://mocki.io/v1/06bc582e-8185-4f43-a071-378a9a1d88e1";

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await httpClient.GetAsync(url);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                characters = JsonConvert.DeserializeObject<List<CharacterViewModel>>(results);

            }
            else
            {
                Console.WriteLine("error calling web API");
            }

            return View(characters);
        }
    }
}
