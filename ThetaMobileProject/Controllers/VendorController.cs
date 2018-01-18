using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThetaMobileProject.Models;

namespace ThetaMobileProject.Controllers
{
    public class VendorController : Controller
    {
        PointOfSaleSystemContext OurDBContext = null;

        public VendorController(PointOfSaleSystemContext _OurDBContext)
        {
            OurDBContext = _OurDBContext;
        }


        [HttpGet]
        public IActionResult AddNewVendor()
        {
            IList<Item> plist = OurDBContext.Item.ToList();
            ViewBag.pl = plist;

            IList<Vendor> clist = OurDBContext.Vendor.ToList();
            ViewBag.cl = clist;

            return View();
        }

        [HttpPost]
        public IActionResult AddNewVendor(Vendor v)
        {
            v.Tdate = DateTime.Today.Date;
            OurDBContext.Vendor.Add(v);
            OurDBContext.SaveChanges();

            return RedirectToAction(nameof(ViewAllVendor));
        }


        public IActionResult VendorDetail(Vendor v)
        {
            return View(OurDBContext.Vendor.Where(abc => abc.VendorCode == v.VendorCode).FirstOrDefault());
        }
        public IActionResult ViewAllVendor()
        {
            IList<Item> plist = OurDBContext.Item.ToList();
            ViewBag.pl = plist;

            IList<Vendor> clist = OurDBContext.Vendor.ToList();
            ViewBag.cl = clist;

            return View(OurDBContext.Vendor.ToList<Vendor>());
        }
        [HttpGet]


        public IActionResult EditVendor(int VendorCode)
        {

            Vendor v = OurDBContext.Vendor.Where(ab => ab.VendorCode == VendorCode).FirstOrDefault();
            return View(v);
        }
        [HttpPost]
        public IActionResult EditVendor(Vendor v)
        {
            Vendor vE = OurDBContext.Vendor.Where(ab => ab.VendorCode == v.VendorCode).FirstOrDefault();
            vE.VendorName = v.VendorName;
            vE.Cnic = v.Cnic;

           
            OurDBContext.Vendor.Update(vE);
            OurDBContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        
    }





        public IActionResult DeleteVendor(Vendor v)
        {
            OurDBContext.Vendor.Remove(v);
            OurDBContext.SaveChanges();

            return RedirectToAction(nameof(ViewAllVendor));
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
