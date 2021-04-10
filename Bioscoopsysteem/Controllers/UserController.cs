using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Bioscoopsysteem.Data;
using Microsoft.AspNetCore.Http;

namespace Bioscoopsysteem.Controllers
{
    public class UserController : Controller
    {
        private readonly BioscoopsysteemContext _context;
        public UserController(BioscoopsysteemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = _context.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    HttpContext.Session.SetString("FullName", data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName);
                    HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                    HttpContext.Session.SetInt32("idUser", data.FirstOrDefault().idUser);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Index");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
