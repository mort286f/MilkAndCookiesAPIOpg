using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MilkAndCookiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MilkshakeController : ControllerBase
    {
        public static List<string> milkshakes = new List<string>();

        [HttpGet]
        public List<string> Get(string flavour)
        {
            milkshakes.Add("Strawberry");
            milkshakes.Add("Chocolate");
            milkshakes.Add("Vanilla");

            
            if (!string.IsNullOrEmpty(flavour))
            {
                CookieOptions co = new CookieOptions();
                co.Expires = DateTime.Now.AddSeconds(30);

                //Creates a new cookie and adds the favorite flavour as the value.
                Response.Cookies.Append("favoriteFlavour", flavour, co);
                return milkshakes.Where(x => x == flavour).ToList();
            }
            else
            {

                return milkshakes;
            }
        }

        [HttpGet("returnFlavourCookie")]
        public string GetFlavourCookieValue()
        {
            //if the cookie is not null, so if it is created
            if (Request.Cookies["favoriteFlavour"] != null)
            {
                var value = Request.Cookies["favoriteFlavour"];
                return value;
            }
            else
            {
                //else, the cookie cannot be found
                return "Unknown";
            }
        }
    }
}
