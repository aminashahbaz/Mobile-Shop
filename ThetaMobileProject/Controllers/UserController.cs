using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThetaMobileProject.Models;



namespace ThetaMobileProject.Controllers
{
    public class UserController : Controller
    {

        PointOfSaleSystemContext OurDBContext = null;

        public UserController(PointOfSaleSystemContext _OurDBContext)
        {
            OurDBContext = _OurDBContext;
        }
        [HttpGet]
        public IActionResult AddNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(User U)
        {
            U.Tdate = DateTime.Today.Date;
            OurDBContext.User.Add(U);
            OurDBContext.SaveChanges();
            string msgBody = "<p>New User Created by User Id <br/>" + U.UserName + "</p>";

            EmailSending ES = new EmailSending();
            ES.SendEmail("New User Creation Confirmation", msgBody, U.UserName);


            return View();
        }

        public IActionResult ViewAllUser()
        {
            return View(OurDBContext.User.ToList<User>());
        }

        public IActionResult UserDetail(User U)
        {

            return View(OurDBContext.User.Where(abc => abc.UserId == U.UserId).FirstOrDefault<User>());


        }
        public IActionResult DeleteUser(User U)
        {

            OurDBContext.User.Remove(U);
            OurDBContext.SaveChanges();
            return RedirectToAction(nameof(ViewAllUser));
        }
        public string DeleteAjax(User U)
        {
            System.Threading.Thread.Sleep(3000);
            try
            {
                OurDBContext.User.Remove(U);
                OurDBContext.SaveChanges();
            }
            catch
            {
                return "0";
            }
            return "1";
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User U)
        {
            var x = OurDBContext.User.Where(ab => ab.UserName.Equals(U.UserName) && ab.Password.Equals(U.Password)).FirstOrDefault();
            if (x != null)
            {


                //return RedirectToAction(nameof(), "Dash");


            }
            else
            {
                ViewBag.Message = "Please Enter Valid UserName or Password";
            }
            return View();
        }

        public IActionResult LogOut()
        {

            return RedirectToAction(nameof(Login));

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}