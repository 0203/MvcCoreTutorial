using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using MvcCoreTutorial.Models.Domain;

namespace MvcCoreTutorial.Controllers
{
    public class PersonController : Controller
    {
        private readonly DBContext _ctx;

        public PersonController (DBContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.greeting = "Parse a data using ViewBag";
            ViewData["greeting2"] = "Parse a data using ViewData";
            //ViewBag and ViewData only can pass the data from controller to view
            TempData["greeting3"] = "Parse a data using TempData";
            //TempData can pass data from one controller method to another controller method
            return View();
        }

        //it is a get method
        public IActionResult AddPerson()
        {
            return View();
        }

        //it is a post method

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {

            try
            {
                _ctx.Add(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Successfully added person!";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Operation Failed!";
                return View();
            }
  
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {

            try
            {
                _ctx.Update(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Successfully update person!";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Operation Failed!";
                return View();
            }

        }

        [HttpPost]
        public IActionResult DeletePerson(Person person)
        {

            try
            {
                _ctx.Remove(person);
                _ctx.SaveChanges();
                TempData["msg"] = "Successfully remove person!";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Operation Failed!";
                return View();
            }

        }

        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Person.ToList();
            return View(persons);
        }

        public IActionResult EditPerson(int id)
        {
            var person = _ctx.Person.Find(id);
            return View(person);
        }

        public IActionResult DeletePerson(int id)
        {
            var person = _ctx.Person.Find(id);

            try
            {
                if (person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }
            }

            catch (Exception ex)
            {

            }

            return RedirectToAction("DisplayPersons");

        }
    }
}
