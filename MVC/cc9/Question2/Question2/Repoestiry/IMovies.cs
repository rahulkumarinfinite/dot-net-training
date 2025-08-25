using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Question2.Models;

namespace Question2.Repoestiry
{
   public interface IMovies<T> where T:class
    {
       
         

    IEnumerable<Movy> GetAll();
            Movy GetById(int id);
            void Add(Movy movie);
            void Update(Movy movie);
            void Delete(int id);
            IEnumerable<Movy> GetByYear(int year);
            IEnumerable<Movy> GetByDirector(string directorName);
        }

    }




