using RestSharp;
using JSONHolderProject.Models;

namespace JSONHolderProject.APITools
{
    public static class AplcationAPI
    {
        public static RestResponse GetResource(Resource resource, string filter = null, DataFormat format = DataFormat.Json) 
        {
            switch (resource) 
            {
                case Resource.Post:
                    if (filter != null) return APIUtils.SendGetRequest($"posts{filter}", format);
                    return APIUtils.SendGetRequest("posts", format);
                case Resource.Comment:
                    if (filter != null) return APIUtils.SendGetRequest($"comments{filter}", format);
                    return APIUtils.SendGetRequest("comments", format);
                case Resource.Album:
                    if (filter != null) return APIUtils.SendGetRequest($"albums{filter}", format);
                    return APIUtils.SendGetRequest("albums", format);
                case Resource.Photo:
                    if (filter != null) return APIUtils.SendGetRequest($"photos{filter}", format);
                    return APIUtils.SendGetRequest("photos", format);
                case Resource.ToDo:
                    if (filter != null) return APIUtils.SendGetRequest($"todos{filter}", format);
                    return APIUtils.SendGetRequest("todos", format);
                case Resource.User:
                    if (filter != null) return APIUtils.SendGetRequest($"users{filter}", format);
                    return APIUtils.SendGetRequest("users", format);
                default:
                    return null;
            }
        }

        public static RestResponse SendResource<T>(Resource resource, T model, DataFormat format = DataFormat.Json) where T : class
        {
            return resource switch
            {
                Resource.Post => APIUtils.SendPostRequest("posts", model, format),
                Resource.Comment => APIUtils.SendPostRequest("comments", model, format),
                Resource.Album => APIUtils.SendPostRequest("albums", model, format),
                Resource.Photo => APIUtils.SendPostRequest("photos", model, format),
                Resource.ToDo => APIUtils.SendPostRequest("todos", model, format),
                Resource.User => APIUtils.SendPostRequest("users", model, format),
                _ => null,
            };
        }

        public static RestResponse PutResource<T>(Resource resource, T model, string id, DataFormat format = DataFormat.Json) where T : class
        {
            return resource switch
            {
                Resource.Post => APIUtils.SendPutRequest($"posts/{id}", model, format),
                Resource.Comment => APIUtils.SendPutRequest($"comments/{id}", model, format),
                Resource.Album => APIUtils.SendPutRequest($"albums/{id}", model, format),
                Resource.Photo => APIUtils.SendPutRequest($"photos/{id}", model, format),
                Resource.ToDo => APIUtils.SendPutRequest($"todos/{id}", model, format),
                Resource.User => APIUtils.SendPutRequest($"users/{id}", model, format),
                _ => null,
            };
        }

        public static RestResponse PatchResource<T>(Resource resource, T model, int id) where T : class
        {
            return resource switch
            {
                Resource.Post => APIUtils.SendPatchRequest($"posts/{id}", model),
                Resource.Comment => APIUtils.SendPatchRequest($"comments/{id}", model),
                Resource.Album => APIUtils.SendPatchRequest($"albums/{id}", model),
                Resource.Photo => APIUtils.SendPatchRequest($"photos/{id}", model),
                Resource.ToDo => APIUtils.SendPatchRequest($"todos/{id}", model),
                Resource.User => APIUtils.SendPatchRequest($"users/{id}", model),
                _ => null,
            };
        }

        public static RestResponse DeleteResource(Resource resource, int id) 
        {
            return resource switch
            {
                Resource.Post => APIUtils.SendDeleteRequest($"posts/{id}"),
                Resource.Comment => APIUtils.SendDeleteRequest($"comments/{id}"),
                Resource.Album => APIUtils.SendDeleteRequest($"albums/{id}"),
                Resource.Photo => APIUtils.SendDeleteRequest($"photos/{id}"),
                Resource.ToDo => APIUtils.SendDeleteRequest($"todos/{id}"),
                Resource.User => APIUtils.SendDeleteRequest($"users/{id}"),
                _ => null,
            };
        }
    }
}
