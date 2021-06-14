using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsApiTool.Controllers
{
    public class EntityController : Controller
    {
        private readonly DynamicsConnector _dynamicsConnector;

        public EntityController(DynamicsConnector dynamicsConnector)
        {
            _dynamicsConnector = dynamicsConnector;
        }

        public IActionResult Account(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("accounts");

                return View("Accounts");
            }
            else
            {
                ViewBag.Account = _dynamicsConnector.GetJObject($"accounts({id})");

                return View("AccountDetail");
            }
        }

        public IActionResult Product(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("product");

                return View("Products");
            }
            else
            {
                ViewBag.Account = _dynamicsConnector.GetJObject($"products({id})");

                return View("ProductDetail");
            }
        }

    }
}
