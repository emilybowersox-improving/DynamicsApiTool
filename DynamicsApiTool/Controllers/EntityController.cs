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
        public IActionResult Lead(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("leads");

                return View("Leads");
            }
            else
            {
                ViewBag.Lead = _dynamicsConnector.GetJObject($"leads({id})");

                return View("LeadDetail");
            }
        }

        public IActionResult Competitor(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("competitors");

                return View("Competitors");
            }
            else
            {
                ViewBag.Competitor = _dynamicsConnector.GetJObject($"competitors({id})");

                return View("CompetitorDetail");
            }
        }
        public IActionResult Users(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
              ViewBag.Data = _dynamicsConnector.GetJObject("systemusers");

              return View("Users");
            }
            else
            {
              ViewBag.User = _dynamicsConnector.GetJObject($"systemusers({id})");

              return View("UserDetail");
            }
        }

        public IActionResult Contact(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("contacts");

                return View("Contacts");
            }
            else
            {
                ViewBag.Contact = _dynamicsConnector.GetJObject($"contacts({id})");

                return View("ContactDetail");
            }
        }

<<<<<<< HEAD
=======
        public IActionResult Quote(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject($"quotes");
                return View("Quotes");
            }
            else 
            {
                ViewBag.Quote = _dynamicsConnector.GetJObject($"quotes({id})");
                return View("QuoteDetail");
            }
        }
>>>>>>> 0cf7789bf25aa2469dd92afe440dcff2e5395fd4

        public IActionResult Opportunity(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("opportunities");

                return View("Opportunities");
            }
            else
            {
                ViewBag.Opportunity = _dynamicsConnector.GetJObject($"opportunities({id})");

                return View("OpportunityDetail");
            }
        }

        public IActionResult Campaign(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("campaigns");

                return View("Campaigns");
            }
            else
            {
                ViewBag.Campaign = _dynamicsConnector.GetJObject($"campaigns({id})");

                return View("CampaignDetail");
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
