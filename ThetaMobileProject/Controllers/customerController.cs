using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThetaMobileProject.Models;

namespace ThetaMobileProject.Controllers
{
    public class customerController : Controller
    {

        PointOfSaleSystemContext OurDBContext = null;

        public customerController(PointOfSaleSystemContext _OurDBContext)
        {
            OurDBContext = _OurDBContext;
        }

       

        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCustomer(Customer c)
        {
            c.Tdate = DateTime.Now.Date;
            OurDBContext.Customer.Add(c);
            OurDBContext.SaveChanges();

            return RedirectToAction(nameof(ViewAllCustomer));
        }
        public IActionResult ViewAllCustomer()
        {
            return View(OurDBContext.Customer.ToList<Customer>());
        }

        public IActionResult DeleteCustomer(Customer C)
        {
            OurDBContext.Customer.Remove(C);
            OurDBContext.SaveChanges();

            return RedirectToAction(nameof(ViewAllCustomer));
        }
        [HttpGet]

        public IActionResult EditCustomer(int CustomerId)
        {


            Customer c = OurDBContext.Customer.Where(p => p.CustomerId == CustomerId).SingleOrDefault();

            if (c != null)
            {
                return View(c);
            }


            return RedirectToAction(nameof(ViewAllCustomer));
        }
    [HttpPost]
    public IActionResult EditCustomer(Customer c)
    {
            Customer pc = OurDBContext.Customer.Where(p => p.CustomerId == c.CustomerId).SingleOrDefault();

            if (pc != null)
            {
                pc.CustomerName = c.CustomerName;

                OurDBContext.Update(pc);
                OurDBContext.SaveChanges();
            }


            return RedirectToAction(nameof(ViewAllCustomer));
        }



        public IActionResult CustomerDetail(Customer c)
    {

        return View(OurDBContext.Customer.Where(abc => abc.CustomerId == c.CustomerId).FirstOrDefault());
    }






    public IActionResult Index()
        {
            return View();
        }
    }
}