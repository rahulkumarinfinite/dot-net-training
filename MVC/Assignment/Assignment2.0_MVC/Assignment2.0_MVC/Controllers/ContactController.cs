using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Assignment2._0_MVC.Models;
using Assignment2._0_MVC.Repo;

namespace Assignment2._0_MVC.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactRepo repo = new ContactRepo();

        public async Task<ActionResult> Index()
        {
            var contacts = await repo.GetAllAsync();
            return View(contacts);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repo.CreateAsyn(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }


        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null) return HttpNotFound();

            var contact = await repo.GetAllAsync();
            var item = contact.Find(c => c.Id == id.Value);

            if (item == null) return HttpNotFound();
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

