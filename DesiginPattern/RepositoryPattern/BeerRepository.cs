using DesiginPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesiginPattern.RepositoryPattern
{
    public class BeerRepository : IBeerRepository
    {
        private DesignPatternsContext _contexto;

        public BeerRepository(DesignPatternsContext contexto)
        {
            _contexto = contexto;
        }
        public void Add(Beer data)
        {
            _contexto.Beers.Add(data);
        }

        public void Delete(int id)
        {
            var beer = _contexto.Beers.Find(id);

            _contexto.Beers.Remove(beer);
        }

        public IEnumerable<Beer> Get()
        {
           return  _contexto.Beers.ToList();
        }

        public Beer Get(int id)
        {
            return _contexto.Beers.Find(id);
        }

        public void Update(Beer data)
        {
            _contexto.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _contexto.SaveChanges();
        }

        
    }
}
