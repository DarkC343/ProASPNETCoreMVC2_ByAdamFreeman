using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // localhost:xyz/ , localhost:xyz/Home , localhost:xyz/Home/Index , localhost:xyz/Home/index are going run this action
        // The actions are going to be accessed by their names appearing on the url, so the action methods can return to any view that they want. What I mean is the view names are not important in url
        public ViewResult Index()
        {
            // view() by defualt redirects to default view which it's name is the same as the method name
            ViewBag.TimeOfDayMessage = DateTime.Now.Hour >= 12 ? "Good Afternoon" : "Good Morning";
            return View("MyView");
        }
        // HTTP GET: Handles the requests where the page url is entered
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        // -> Overloaded method <-
        // HTTP POST: Handles the requests when the user submits the form
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse response)
        {
            // Description: Handles the form by stroing the information
            // ModelState is the property of the base class (Controller) which specifies whether the data passed from form was valid or not. If ModelState.IsValid is false, something wrong has happened according to validation attributes that had been defined in the model. Otherwise, the boolean is going to be true
            if (ModelState.IsValid)
            {
                Repository.AddResponse(response);
                // View( x , y ) means that the action is going to be returned to x view with the object of the model (y) that has been instanced before. The idea is to obtain the data that has been saved to the model earlier.
                return View("Thanks", response);
            }
            else
            {
                return View();
            }
        }
        public ViewResult ListResponses() {
            // View( z ) means that the action is going to be returned to default view with the object of the model (z) that has been instanced before. The idea is to obtain the data that has been saved to the model earlier.
            // Description: Here we send IEnumerable<MODEL_OBJECT> to the view which the object is not a single, it is actually a list of objects of a same model
            return View(
                Repository.Responses.Where(r => r.WillAttend == true)
            );
        }
    }
}
