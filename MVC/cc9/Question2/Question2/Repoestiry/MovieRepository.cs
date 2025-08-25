using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Question2.Models;

namespace Question2.Repoestiry
{
    public class MovieRepository : IMovies
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movy> GetAll() => _context.Movies.ToList();

        public Movy GetById(int id) => _context.Movies.Find(id);

        public void Add(Movy movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movy movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Movy> GetByYear(int year) =>
            _context.Movies.Where(m => m.DateofRelease.Year == year).ToList();

        public IEnumerable<Movy> GetByDirector(string directorName) =>
            _context.Movies.Where(m => m.DirectorName == directorName).ToList();
    }

}


