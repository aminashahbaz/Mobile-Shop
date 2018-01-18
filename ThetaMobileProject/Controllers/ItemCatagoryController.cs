using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThetaMobileProject.Models;

namespace ThetaMobileProject.Controllers
{
    public class ItemCatagoryController : Controller
    {
        PointOfSaleSystemContext OurDBContext = null;

        public ItemCatagoryController(PointOfSaleSystemContext _OurDBContext)
        {
            OurDBContext = _OurDBContext;
        }

        public IActionResult ViewAllItemCatagory()
        {
            return View(OurDBContext.ItemCatagory.ToList<ItemCatagory>());
        }

        [HttpGet]
        public IActionResult AddNewItemCatagory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewItemCatagory(ItemCatagory C)
        {
            C.Tdate = DateTime.Today.Date;


            if (OurDBContext.ItemCatagory.Where(abc => abc.CatagoryName == C.CatagoryName).Count() > 0)
            {
                ViewBag.CatagoryAlreadyExist = "Catagory Already Exist";
                return View();
            }

            OurDBContext.ItemCatagory.Add(C);
            OurDBContext.SaveChanges();

            return RedirectToAction(nameof(ViewAllItemCatagory));
        }

        public int CatagoryCountAjax(int CatagoryCode)
        {
            return OurDBContext.Item.Where(abc => abc.CatagoryCode == CatagoryCode).Count();
        }

        public IActionResult DeleteItemCatagory(ItemCatagory C)
        {


            OurDBContext.ItemCatagory.Remove(C);
            OurDBContext.SaveChanges();

            return RedirectToAction(nameof(ViewAllItemCatagory));
        }

        public IActionResult EditItemCatagory(int CatagoryCode)
        {
            ItemCatagory ic = OurDBContext.ItemCatagory.Where(abc => abc.CatagoryCode == CatagoryCode).FirstOrDefault();

            if (ic != null)
            {
                return View(ic);
            }


            return RedirectToAction(nameof(ViewAllItemCatagory));
        }

        [HttpPost]
        public IActionResult EditItemCatagory(ItemCatagory C)
        {
            ItemCatagory ic = OurDBContext.ItemCatagory.Where(abc => abc.CatagoryCode == C.CatagoryCode).FirstOrDefault();

            if (ic != null)
            {
                ic.CatagoryName = C.CatagoryName;

                OurDBContext.Update(ic);
                OurDBContext.SaveChanges();
            }


            return RedirectToAction(nameof(ViewAllItemCatagory));
        }


        public IActionResult ItemCatagoryDetail(ItemCatagory C)
        {
            return View(OurDBContext.ItemCatagory.Where(abc => abc.CatagoryCode == C.CatagoryCode).FirstOrDefault<ItemCatagory>());
        }
    }
}



































