using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("APIDemo")]
    public class APIDemoController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<EventsObj> students = null;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/Events");
                //HTTP GET
                var responseTask = client.GetAsync("events");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // var readTask = result.Content.ReadAsAsync<IList<EventsObj>>();
                    // readTask.Wait();

                    // students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<EventsObj>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);


            //return View();
        }


    }
}