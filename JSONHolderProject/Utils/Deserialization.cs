using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JSONHolderProject.Utils
{
    public static class Deserialization
    {
        public static T GetObjectFromResponse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
        public static List<T> GetListFromResponse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<List<T>>(response.Content);
        }
        public static T GetModelFromFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}