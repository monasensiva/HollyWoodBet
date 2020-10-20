using HWBUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HWBUi.Controllers
{
    public class EventDetailController : Controller
    {
        // GET: Tournament
        public ActionResult Index()
        {
            IEnumerable<UiEventDetail> uiEventDetails;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("EventdDetail").Result;
            uiEventDetails = response.Content.ReadAsAsync<IEnumerable<UiEventDetail>>().Result;
            return View(uiEventDetails);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new UiEventDetail());
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("EventdDetail/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<UiEventDetail>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddorEdit(UiEventDetail uiEventDetails)
        {
            if (uiEventDetails.EventId == 0)
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("EventdDetail", uiEventDetails).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("EventdDetail/" + uiEventDetails.EventDetailId
                    , uiEventDetails).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("EventdDetail/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}