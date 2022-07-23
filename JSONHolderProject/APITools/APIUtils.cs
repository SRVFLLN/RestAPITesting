using RestSharp;
using JSONHolderProject.Utils;

namespace JSONHolderProject
{
    public static class APIUtils
    {
        public static RestClient client = new RestClient(ConfigTool.GetTagValue("api"));

        public static RestResponse SendGetRequest(string endpoint, DataFormat format)
        {
            RestRequest request = new RestRequest(endpoint, Method.Get)
            {
                RequestFormat = format
            };
            return client.Execute(request);
        }

        public static RestResponse SendPostRequest<T>(string endpoint, T model, DataFormat format = DataFormat.Json) where T : class
        {
            RestRequest request = new RestRequest(endpoint, Method.Post)
            {
                RequestFormat = format
            };
            request.AddJsonBody(model);
            return client.Execute(request);
        }

        public static RestResponse SendPutRequest<T>(string endpoint, T model, DataFormat format = DataFormat.Json) where T : class
        {
            RestRequest request = new RestRequest(endpoint, Method.Put)
            {
                RequestFormat = format
            };
            request.AddJsonBody(model);
            return client.Execute(request);
        }

        public static RestResponse SendPatchRequest<T>(string endpoint, T model, DataFormat format = DataFormat.Json) where T : class
        {
            RestRequest request = new RestRequest(endpoint, Method.Patch)
            {
                RequestFormat = format
            };
            request.AddJsonBody(model);
            return client.Execute(request);
        }

        public static RestResponse SendDeleteRequest(string endpoint) 
        {
            RestRequest request = new RestRequest(endpoint, Method.Delete);
            return client.Execute(request);
        } 
    }
}