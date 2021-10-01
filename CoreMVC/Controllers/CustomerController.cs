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
        public ActionResult GetTrainer()
        {
            var customers = repo.GetUsers();
            var data = new List<CoreMVC.Models.Skillsett>();
            foreach (var c in customers)
            {
                data.Add(Mappert.MaptSkill(c));
            }
            return View(data);
        }

        public ActionResult GetProfile()
        {
            string user = HttpContext.Session.GetString("Username");
            var profile = repo.GetProfile(user);
            return View(Mappert.Map(profile));
        }
        public ActionResult GetSkills()
        {
            string user = HttpContext.Session.GetString("Username");
            var skillset = repo.GetSkill(user);
            if(skillset != null)
            {
                return View(Mappert.MapSkill(skillset));
            }
            else
            {
                return RedirectToAction("Skillset");
            }
            
        }
        public ActionResult GetCustomerById(int? id)
        {
            var customer = repo.GetCustomerById(id);
            return View(Mappert.Map(customer));
        }
        public ActionResult DeleteCustomerById(int? id)
        {
            repo.DeleteCustomerById(id);
            Logout();
            return RedirectToAction("Loginn");
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
        public IActionResult Update(int id,Registeration reg)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(Mappert.Map(reg),id);
                return RedirectToAction("GetProfile");
            }
            else
            {
                return View(reg);
            }
        }

        [HttpGet]
        public IActionResult Updateskill()
        {
            string user = HttpContext.Session.GetString("Username");
            var data = repo.GetSkill(user);
                if (data != null)
                {
                    return View(Mappert.MapSkill(data));
                }
                else
                {
                    return RedirectToAction("GetUser");
                }
        }
        [HttpPost]
        public IActionResult Updateskill(SkillSet sk)
        {
            if (ModelState.IsValid)
            {
                string user = HttpContext.Session.GetString("Username");
                repo.EditSkill(Mappert.MapSkill(sk),user);
                return RedirectToAction("GetSkills");
            }
            else
            {
                return View(sk);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index","Home");
        }
    }
}
