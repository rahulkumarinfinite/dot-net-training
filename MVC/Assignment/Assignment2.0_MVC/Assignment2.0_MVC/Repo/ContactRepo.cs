using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Assignment2._0_MVC.Models;

namespace Assignment2._0_MVC.Repo
{
    public class ContactRepo :IContactRepo
    {
        private readonly ContactContext _db = new ContactContext();
        public async Task<List<Contact>> GetAllAsync()
        {
            return await _db.Contacts.ToListAsync();
        }

        public async Task CreateAsyn(Contact contact)
        {
            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var contact = await _db.Contacts.FindAsync(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
                await _db.SaveChangesAsync();
            }
        }
    }
}