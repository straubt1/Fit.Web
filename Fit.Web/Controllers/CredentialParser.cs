using System.IO;
using Microsoft.Azure;
using Newtonsoft.Json;

namespace Fit.Web.Controllers
{
    public static class CredentialParser
    {
        public static DataCredentials ParseFromFile(string filename)
        {
            var contents = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<DataCredentials>(contents);
        }
        public static DataCredentials ParseFromConfiguration()
        {
            return new DataCredentials
            {
                AuthToken = CloudConfigurationManager.GetSetting("fitbit.AuthToken"),
                AuthTokenSecret = CloudConfigurationManager.GetSetting("fitbit.AuthTokenSecret"),
                ConsumerKey = CloudConfigurationManager.GetSetting("fitbit.ConsumerKey"),
                ConsumerSecret = CloudConfigurationManager.GetSetting("fitbit.ConsumerSecret")
            };
        }
    }
}