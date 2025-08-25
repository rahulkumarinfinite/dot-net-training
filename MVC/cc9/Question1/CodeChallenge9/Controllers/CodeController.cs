﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeChallenge9.Models;

namespace CodeChallenge9.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities db = new northwindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomersInGermany()
        {
            var germanCustomers = db.Customers
                .Where(c => c.Country == "Germany")
                .ToList();

            return View(germanCustomers);
        }



        public ActionResult CustomerByOrder()
        {
            var order = db.Orders
                .Where(o => o.OrderID == 10248)
                .Select(o => o.Customer)
                .FirstOrDefault();

            return View(order);
        }


    }
}