using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEBAPIDemo.Models;

namespace WEBAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        [Route("events")]
        public IActionResult GetEvents()
        {
            var result = GetData();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        public EventsObj[] GetData()
        {
            var webClientObj = new WebClient();
            var Json = webClientObj.DownloadString("C:\\Users\\navee\\OneDrive\\Desktop\\bravotest\\bravo-csharp-technical-test\\src\\Project\\wwwroot\\assets\\data\\events.json");
            EventsObj[] eventsJson = JsonConvert.DeserializeObject<EventsObj[]>(Json);
            return eventsJson;
        }
    }
}