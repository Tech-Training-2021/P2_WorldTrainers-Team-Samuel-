using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CoreMVC.Controllers
{
    [Route("[controller]/[action]")]

    public class CustomerController : Controller
    {
        private readonly IRepository repo;
        public CustomerController(IRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddR()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddR(RegisterationViewModel registeration)
        {
            if (ModelState.IsValid)
            {
                int RegisterationId = repo.AddR(Mappert.Map(registeration));
                repo.AddL(Mappert.Maplogin(registeration), RegisterationId);
                return RedirectToAction("Index","Home");
            }
            else
                return View(registeration);
        }

        public ActionResult Loginn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginn(Login login)
        {
            if (ModelState.IsValid)
            {

                    int p = repo.CustomerLogin(Mappert.Maploguser(login));
                    if (p!=0)
                    {
                        HttpContext.Session.SetString("Username", login.Username);
                        HttpContext.Session.SetString("Role", p.ToString());
                    return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Loginn");
                    }
            }

            return View();
        }
        public ActionResult Skillset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Skillset(SkillSet sk)
        {
            if (ModelState.IsValid)
            {
                string user = HttpContext.Session.GetString("Username");
                repo.AddSkiil(Mappert.MapSkill(sk),user);
                return RedirectToAction("Index", "Home");

            }
             else
             {
                return View(sk);
            }
            
        }

        public ActionResult GetUser()
        {
            var customers = repo.GetUsers();
            var data = new List<CoreMVC.Models.Registeration>();
            foreach (var c in customers)
            {
                data.Add(Mappert.Map(c));
            }
            return View(data);
        }
        public ActionResult GetCustomerById(int? id)
        {
            var customer = repo.GetCustomerById(id);
            return View(Mappert.Map(customer));
        }
        public ActionResult DeleteCustomerById(int? id)
        {
            repo.DeleteCustomerById(id);
            return RedirectToAction("GetUser");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id > 0)
            {
                var data = repo.GetCustomerById(id);
                if (data != null)
                {
                    return View(Mappert.Map(data));
                }
                else
                {
                    return RedirectToAction("GetUser");
                }
            }
            else
            {
                return RedirectToAction("GetUser");
            }
        }
        [HttpPost]
        public IActionResult Update(Registeration reg)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(Mappert.Map(reg));
                return RedirectToAction("GetUser");
            }
            else
            {
                return View(reg);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index","Home");
        }
    }
}
