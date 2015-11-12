using System;
using System.Web.Mvc;
using Fitbit.Api;
using Microsoft.Azure;

namespace Fit.Web.Controllers
{
    public class HomeController : Controller
    {
        private  FitbitClient _client;

        public HomeController()
        {
            var creds = (CloudConfigurationManager.GetSetting("environment") == "local")
                ? CredentialParser.ParseFromFile(@"C:\Development\fitbitcreds.json")
                : CredentialParser.ParseFromConfiguration();

            _client = new FitbitClient(creds.ConsumerKey, creds.ConsumerSecret, creds.AuthToken, creds.AuthTokenSecret);
        }

        public ActionResult Index()
        {
            var date = DateTime.Now;
            var model = new Dashboard
            {
                Date = date,
                Activity = _client.GetDayActivity(date),
                Profile = _client.GetUserProfile()
            };
            return View("Dashboard", model);
        }
    }
}