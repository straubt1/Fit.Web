using System;
using Fitbit.Models;

namespace Fit.Web.Controllers
{
    public class Dashboard
    {
        public DateTime Date { get; set; }
        public Activity Activity { get; set; }
        public UserProfile Profile { get; set; }
    }
}