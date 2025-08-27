using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2._0_MVC.Models;

namespace Assignment2._0_MVC.Repo
{
    interface IContactRepo
    {
          Task<List<Contact>> GetAllAsync();
         Task CreateAsyn(Contact contact);
        Task DeleteAsync(long id);

    }
}
