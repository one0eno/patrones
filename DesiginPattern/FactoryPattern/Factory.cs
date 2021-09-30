using System;
using System.Collections.Generic;
using System.Text;

namespace DesiginPattern.FactoryPattern
{
    //Creator 1 crear fabrica de ventas
    public abstract class SaleFactory
    {
        //Crear interface
        public abstract ISale GetSale();

    }

    //4 Concrete creater
    public class StoreSaleFactory : SaleFactory
    {
        private decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }
        public override ISale GetSale()
        {
            return new StoreSale(_extra);
            
        }
    }


    public class InternetSaleFactory : SaleFactory
    {
        private decimal _discount;

        public InternetSaleFactory(decimal discount)
        {
            _discount = discount;
        }
        public override ISale GetSale()
        {
            return new StoreSale(_discount);

        }
    }

    //Concrete product 3 implementar interface en una clase concret product
    public class StoreSale : ISale
    {
        private decimal _extra;

        public StoreSale(decimal extra)
        {
            _extra = extra;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"la venta en tienda tiene un totla de {total + _extra}");
        }
    }
    //2crear interface
    public interface ISale {

        public void Sell(decimal total);
    }
}
