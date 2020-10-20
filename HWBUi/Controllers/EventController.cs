using HWBUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace HWBUi.Controllers
{
    public class EventController : Controller
    {
        // GET: Tournament
        public ActionResult Index()
        {
            IEnumerable<UiEvent> uiEvents;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Event").Result;
            uiEvents = response.Content.ReadAsAsync<IEnumerable<UiEvent>>().Result;
            return View(uiEvents);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new UiEvent());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Event/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<UiEvent>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddorEdit(UiEvent uiEvents)
        {
            if (uiEvents.EventId == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Event", uiEvents).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Event/" + uiEvents.EventId
                    , uiEvents).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Event/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}