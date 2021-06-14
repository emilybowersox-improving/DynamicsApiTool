﻿using Microsoft.AspNetCore.Mvc;
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

<<<<<<< HEAD
<<<<<<< HEAD
        public IActionResult Competitor(string id)
        {
            if(String.IsNullOrWhiteSpace(id))
            {
                ViewBag.Data = _dynamicsConnector.GetJObject("competitors");

                return View("Competitors");
            }
            else
            {
                ViewBag.Competitor = _dynamicsConnector.GetJObject($"competitors({id})");

                return View("CompetitorDetail");
=======
=======
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

>>>>>>> c3747f8ad1704004a8f839b5557fbb3f595cc9a0
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
>>>>>>> 93a8c12c585afbe0f0448ad8a17c61f7ec78d7fc
            }
        }

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
    }
}
