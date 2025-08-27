using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2._0_MVC.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("ContactDB")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}