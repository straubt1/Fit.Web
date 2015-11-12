using System.IO;
using Newtonsoft.Json;

namespace Fit.Web.Controllers
{
    public static class FileParser
    {
        public static T ParseFromFile<T>(string filename)
        {
            var contents = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(contents);
        }
    }
}