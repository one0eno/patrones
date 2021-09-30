using DesiginPattern.Models;
using DesiginPattern.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesiginPattern.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get;  }

        public IRepository<Brand> Brands{ get; }

        public void Save();

    }
}
