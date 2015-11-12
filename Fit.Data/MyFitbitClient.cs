using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fit.Data.Models;
using Fitbit.Api;
using Fitbit.Models;

namespace Fit.Data
{
    public class MyFitbitClient
    {
        private readonly FitbitClient _client;
        public MyFitbitClient(DataCredentials creds)
        {
            _client = new FitbitClient(creds.ConsumerKey, creds.ConsumerSecret, creds.AuthToken, creds.AuthTokenSecret);
        }

        public Activity GetDayActivity(DateTime date)
        {
            return _client.GetDayActivity(date);
        }
    }
}
