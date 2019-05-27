using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AddressWebApp.Controllers
{
    public class AddressController : Controller
    {
        public IConfiguration Configuration { get; }

        public AddressController(IConfiguration configuration)
        {
            Configuration = configuration;
        }                      

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = Configuration["Greeting"];
            return View("Index",model);
        }
    }
}