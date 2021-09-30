using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolss.Earn;

namespace DesignPatterASP.Controllers
{
    public class ProductDetailController: Controller
    {
        private EarnFactory _localEarnFactory;
        private ForeignEarnFactory _foreignFactory;
        public ProductDetailController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignFactory) {
            _localEarnFactory = localEarnFactory;
            _foreignFactory = foreignFactory;
        }
        public IActionResult Index(decimal total)
        {
            //factory
            //ForeignEarnFactory foreignFactor = new ForeignEarnFactory(0.30m, 20);

            //producto
            var localEarn =_localEarnFactory.GetEarn();

            var foreignEarn = _foreignFactory.GetEarn();

            //total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + foreignEarn.Earn(total);
            return View();
        }
    }
}
