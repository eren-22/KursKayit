using KursKayit.Models;
using Microsoft.AspNetCore.Mvc;

namespace KursKayit.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index() 
        {
            var model = Repository.Applications;
            return View(model);
        }
        public IActionResult Apply() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate person) 
        {                
            if(Repository.Applications.Any(c=>c.Email.Equals(person.Email)))
            {
                ModelState.AddModelError("","There is already application for you");
            }

            if(person == null)
            {
                return BadRequest();
            }

            if(ModelState.IsValid)
            {
            Repository.Add(person);    
            return View("Feedback" , person);
            }
            return View();   
        }
    }
}