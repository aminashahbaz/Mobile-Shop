using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThetaMobileProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ThetaMobileProject.Controllers
{
    public class ItemController : Controller
    {

        
            PointOfSaleSystemContext OurDBContext = null;
            IHostingEnvironment env = null;

            public ItemController(PointOfSaleSystemContext _OurDBContext, IHostingEnvironment _env)
            {
                OurDBContext = _OurDBContext;
                env = _env;
            }

            public IActionResult ViewAllItem()
            {
                return View(OurDBContext.Item.ToList<Item>());
            }

            [HttpGet]
            public IActionResult AddNewItem()
            {

               
                return View();
            }

            [HttpPost]
            public IActionResult AddNewItem(Item c, IFormFile Image)
            {

                c.Tdate = DateTime.Today.Date;
                string wwwrootPath = env.WebRootPath;
                string PPFolderPath = wwwrootPath + "/ProductImages/";

                string Name = Image.Name;
                string FileName = Image.FileName;
                long FileLength = Image.Length;

                string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
                Random r = new Random();

                FileNameWithoutExtension = DateTime.Now.ToString("ddMMyyyyhhmm") + r.Next(1, 1000).ToString();
                string Extension = Path.GetExtension(FileName);

                FileStream fs = new FileStream(PPFolderPath + FileNameWithoutExtension + Extension, FileMode.CreateNew);
                Image.CopyTo(fs);
                fs.Close();
                fs.Dispose();

                c.Image = "~/ProductImages/" + FileNameWithoutExtension + Extension;

                OurDBContext.Item.Add(c);
                OurDBContext.SaveChanges();


                return RedirectToAction(nameof(ViewAllItem));


            }

            public IActionResult DeleteItem(Item I)
            {
                OurDBContext.Item.Remove(I);
                OurDBContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            public IActionResult EditItem(int ItemCode)
            {

                IList<ItemCatagory> pc = OurDBContext.ItemCatagory.ToList();
                ViewBag.ItemCatagory = pc;
                Item I = OurDBContext.Item.Where(pd => pd.ItemCode == ItemCode).FirstOrDefault();
                return View(I);
            }

            [HttpPost]
            public IActionResult EditItem(Item I)
            {
                IList<ItemCatagory> pc = OurDBContext.ItemCatagory.ToList();
                ViewBag.ProductCategory = pc;

                Item i = OurDBContext.Item.Where(abc => abc.ItemCode == I.ItemCode).FirstOrDefault();

                if (I != null)
                {

                    I.Color = i.Color;
                    I.Description = i.Description;

                    I.ModelNo = i.ModelNo;
                    I.Price = i.Price;
                    I.SerialNo = i.SerialNo;

                    OurDBContext.Item.Update(I);
                    OurDBContext.SaveChanges();
                }



                return RedirectToAction(nameof(ViewAllItem));
            }


            public IActionResult ItemDetail(Item I)
            {

                return View(OurDBContext.Item.Where(abc => abc.ItemCode == I.ItemCode).FirstOrDefault<Item>());
            }




























            public IActionResult Index()
            {
                return View();
            }
        }
    }
