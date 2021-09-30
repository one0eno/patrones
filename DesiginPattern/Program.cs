using System;
using System.Linq;
using DesiginPattern.FactoryPattern;
using DesiginPattern.Models;
using DesiginPattern.RepositoryPattern;
using DesiginPattern.Singleton;
using DesiginPattern.UnitOfWorkPattern;

namespace DesiginPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton =  Singleton.Singleton.Instance ;
            var log = Singleton.Log.Instance;
            
            log.Save("Escribo esto");
            log.Save("Escribo esto otro");



            //Factory

            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(2);

            ISale sal1 = storeSaleFactory.GetSale();
            sal1.Sell(15);

            ISale sale2 = internetSaleFactory.GetSale();
            sale2.Sell(15);

            //REPOSITORY

            //using (var context = new DesignPatternsContext())
            //{
            //    var lst = context.Beers.ToList();

            //    foreach (var item in lst)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}

            //using (var context = new DesignPatternsContext()) {

            //    var beerRepository = new BeerRepository(context);
            //    var beer = new Beer();
            //    beer.Name = "Corona";
            //    beer.Style = "Pilsneer";

            //    beerRepository.Add(beer);
            //    beerRepository.Save();

            //    foreach (var item in beerRepository.Get())
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}

            //using (var context = new DesignPatternsContext())
            //{
            //    var beerRepo = new Repository<Beer>(context);
            //    var beer = new Beer();
            //    beer.Name = "STLUGGER";
            //    beer.Style = "Rubia";
            //    beerRepo.Add(beer);
            //    beerRepo.Save();

            //    var brandRepo = new Repository<Brand>(context);
            //    var brand = new Brand()
            //    {
            //        Name = "Marca nueva"
            //    };
            //    brandRepo.Add(brand);
            //    brandRepo.Save();
            //}



            using (var context = new DesignPatternsContext())
            {
                var unitOfWor = new UnitOfWork(context);
                var beers = unitOfWor.Beers;
                var beer = new Beer()
                {
                    Name = "Fuller",
                    Style = "Porter"
                };

                beers.Add(beer);

                var brands = unitOfWor.Brands;
                var brand = new Brand()
                {
                    Name = "Fuller"
                };

                brands.Add(brand);

                unitOfWor.Save();



            }
                Console.WriteLine("Hello World!");
        }
    }
}
