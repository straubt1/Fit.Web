using System;
using System.Web.Mvc;
using Fitbit.Api;
using Microsoft.Azure;

namespace Fit.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FitbitClient _client;

        public HomeController()
        {
            var creds = (CloudConfigurationManager.GetSetting("environment") == "local")
                ? CredentialParser.ParseFromFile(@"C:\Development\fitbitcreds.json")
                : CredentialParser.ParseFromConfiguration();

            _client = new FitbitClient(creds.ConsumerKey, creds.ConsumerSecret, creds.AuthToken, creds.AuthTokenSecret);
        }

        public ActionResult Index(DateTime? id = null)
        {
            var date = id ?? DateTime.Now;
            var model = new Dashboard
            {
                Date = date,
                Activity = _client.GetDayActivity(date),
                Profile = _client.GetUserProfile()
            };

            //model.Activity.Summary
            return View("Dashboard", model);
        }
    }
}