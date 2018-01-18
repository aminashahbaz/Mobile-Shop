using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThetaMobileProject.Models;

namespace ThetaMobileProject.Controllers
{
    public class DashController : Controller
    {
        PointOfSaleSystemContext OurDBContext = null;
        public DashController(PointOfSaleSystemContext _OurDBContext)
        {


            OurDBContext = _OurDBContext;
        }


        public IActionResult Dashboard()
        {
            return View();
        }




        public int UserCount()
        {
            return OurDBContext.User.Count();
        }

        public int CustomerCount()
        {

            return OurDBContext.Customer.Count();

        }

        public int VendorCount()
        {
            return OurDBContext.Vendor.Count();
        }

        public int CategoryCount()
        {
            return OurDBContext.ItemCatagory.Count();

        }

        public int ItemCount()
        {
            return OurDBContext.Item.Count();

        }

        public int SaleCount()
        {
            return OurDBContext.Sale.Count();

        }

        public int PurchaseCount()
        {
            return OurDBContext.Purchase.Count();

        }
    }
}
       