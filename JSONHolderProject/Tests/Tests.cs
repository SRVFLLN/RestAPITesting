using NUnit.Framework;
using System.Net;
using JSONHolderProject.Models;
using JSONHolderProject.Utils;
using JSONHolderProject.APITools;
using RestSharp;

namespace JSONHolderProject
{
    public class Tests
    {
        // Test case in Trello
        // https://trello.com/c/y35a0yo4
        [Test]
        public void TestForPosts()
        {
            RestResponse response = AplcationAPI.GetResource(Resource.Post);
            var models = Deserialization.GetListFromResponse<Post>(response);
            HttpStatusCode statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, HttpStatusCode.OK, "Different status code");
            StringAssert.Contains("json", response.ContentType, "Content type not json");
            CollectionAssert.IsOrdered(models, new ModelComparer(),"List not orered");

            response = AplcationAPI.GetResource(Resource.Post, "/"+ConfigTool.GetTagValue("post/get"));
            var post = Deserialization.GetObjectFromResponse<Post>(response);
            statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, HttpStatusCode.OK, "Different status code");
            Assert.Multiple(() => 
            {
                Assert.AreEqual(post.Id, int.Parse(ConfigTool.GetTagValue("post/get")), "Wrong id");
                Assert.AreEqual(post.UserId, int.Parse(ConfigTool.GetTagValue("post/getCheck")), "Wrong userId");
                Assert.IsNotEmpty(post.Title, "Title is empty");
                Assert.IsNotEmpty(post.Body, "Body is empty");
            });

            response = AplcationAPI.GetResource(Resource.Post, ConfigTool.GetTagValue("post/getOut"));
            statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, HttpStatusCode.NotFound, "Different status code");
            Assert.AreEqual(response.Content, "{}", "Request body not empty");

            var newPost = new Post()
            {
                Body = TextUtils.GetRandomText(),
                Title = TextUtils.GetRandomText(),
                UserId = int.Parse(ConfigTool.GetTagValue("post/userId"))
            };
            response = AplcationAPI.SendResource(Resource.Post, newPost);
            statusCode = response.StatusCode;
            var createdPost = Deserialization.GetObjectFromResponse<Post>(response);
            Assert.AreEqual(HttpStatusCode.Created, statusCode, "Wrong status code");
            Assert.Multiple(() =>
            {
                Assert.AreEqual(newPost.Body,createdPost.Body,"Different body");
                Assert.AreEqual(newPost.Title, createdPost.Title, "Different title");
                Assert.AreEqual(newPost.UserId, createdPost.UserId, "Different userId");
                Assert.IsNotNull(createdPost.Id, "Response not contains id");
            });

            string newTitle = TextUtils.GetRandomText(4);
            post = createdPost;
            post.Title = newTitle;
            response = AplcationAPI.PatchResource(Resource.Post, post,createdPost.Id);
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "Wrong status code");
            var patchedPost = Deserialization.GetObjectFromResponse<Post>(response);
            Assert.Multiple(() => 
            {
                Assert.AreEqual(newTitle, patchedPost.Title, "Title not changed");
                Assert.AreEqual(createdPost.UserId, patchedPost.UserId, "userId has changed");
                Assert.AreEqual(createdPost.Body, patchedPost.Body, "Body has changed");
                Assert.AreEqual(createdPost.Id, patchedPost.Id, "Id has changed");
            });

            newPost = new Post()
            {
                Id = int.Parse(ConfigTool.GetTagValue("post/get")),
                Body = TextUtils.GetRandomText(),
                Title = TextUtils.GetRandomText(),
                UserId = int.Parse(ConfigTool.GetTagValue("post/userId"))+ int.Parse(ConfigTool.GetTagValue("post/userId"))
            };
            response = AplcationAPI.PutResource(Resource.Post, newPost, newPost.Id.ToString());
            statusCode = response.StatusCode;
            var puttedPost = Deserialization.GetObjectFromResponse<Post>(response);
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "Wrong status code");
            Assert.AreEqual(newPost, puttedPost);

            response = AplcationAPI.DeleteResource(Resource.Post, int.Parse(ConfigTool.GetTagValue("post/delete")));
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, statusCode,"Wrong status code");

            response = AplcationAPI.GetResource(Resource.Post, ConfigTool.GetTagValue("post/filter"));
            StringAssert.Contains(ConfigTool.GetTagValue("post/check"), response.Content);
        }


        [Test]
        public void TestForUsers() 
        {
            RestResponse response = AplcationAPI.GetResource(Resource.User);
            var models = Deserialization.GetListFromResponse<User>(response);
            HttpStatusCode statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, HttpStatusCode.OK, "Different status code");
            StringAssert.Contains("json", response.ContentType, "Content type not json");
            CollectionAssert.IsOrdered(models, new ModelComparer(), "List not orered");

            response = AplcationAPI.GetResource(Resource.User, "/" + ConfigTool.GetTagValue("user/get"));
            var user = Deserialization.GetObjectFromResponse<User>(response);
            var checkUser = Deserialization.GetModelFromFile<User>("Resources/UserModel.json");
            statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, HttpStatusCode.OK, "Different status code");
            Assert.AreEqual(checkUser, user);

            response = AplcationAPI.GetResource(Resource.User, ConfigTool.GetTagValue("user/getOut"));
            statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, HttpStatusCode.NotFound, "Different status code");
            Assert.AreEqual(response.Content, "{}", "Request body not empty");

            var newUser = new User()
            {
                Id = 11,
                Name = TextUtils.GetRandomText(2),
                Username = TextUtils.GetRandomText(3),
                Email = TextUtils.GetRandomText(1)+"domain.com",
                Adress = new Adress() 
                {
                    Street = TextUtils.GetRandomText(1),
                    Suite = TextUtils.GetRandomText(1),
                    City = TextUtils.GetRandomText(1),
                    Zipecode = $"{int.Parse(ConfigTool.GetTagValue("user/get"))*2500}",
                    Geo = new Geo() 
                    {
                        Lat = $"-{int.Parse(ConfigTool.GetTagValue("user/get")) * 20}",
                        Lng = $"-{int.Parse(ConfigTool.GetTagValue("user/get")) * 15}"
                    }
                },
                Phone = $"{int.Parse(ConfigTool.GetTagValue("user/get")) * 250000}",
                Website = TextUtils.GetRandomText(2).Replace(" ","."),
                Company = new Company() 
                {
                    CompanyName = TextUtils.GetRandomText(2),
                    CatchPhrase = TextUtils.GetRandomText(5),
                    Bs = TextUtils.GetRandomText(4)
                }
            };
            response = AplcationAPI.SendResource(Resource.User, newUser);
            statusCode = response.StatusCode;
            var createdUser = Deserialization.GetObjectFromResponse<User>(response);
            Assert.AreEqual(HttpStatusCode.Created, statusCode, "Wrong status code");
            Assert.AreEqual(newUser, createdUser, "Different created user");

            user.Name = TextUtils.GetRandomText(2);
            user = createdUser;
            response = AplcationAPI.PatchResource(Resource.User, user, createdUser.Id);
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "Wrong status code");
            var patchedUser = Deserialization.GetObjectFromResponse<User>(response);
            Assert.AreEqual(user, patchedUser);

            var newAddres = new Adress()
            {
                Street = TextUtils.GetRandomText(1),
                Suite = TextUtils.GetRandomText(1),
                City = TextUtils.GetRandomText(1),
                Zipecode = $"{int.Parse(ConfigTool.GetTagValue("user/get")) * 3500}",
                Geo = new Geo()
                {
                    Lat = $"-{int.Parse(ConfigTool.GetTagValue("user/get")) * 15}",
                    Lng = $"-{int.Parse(ConfigTool.GetTagValue("user/get")) * 20}"
                }
            };
            var newCompany = new Company()
            {
                CompanyName = TextUtils.GetRandomText(2),
                CatchPhrase = TextUtils.GetRandomText(5),
                Bs = TextUtils.GetRandomText(4)
            };
            newUser.Adress = newAddres;
            newUser.Company = newCompany;
            newUser.Id = int.Parse(ConfigTool.GetTagValue("user/change"));
            response = AplcationAPI.PutResource(Resource.User, newUser, newUser.Id.ToString());
            statusCode = response.StatusCode;
            var puttedUser = Deserialization.GetObjectFromResponse<User>(response);
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "Wrong status code");
            Assert.AreEqual(newUser, puttedUser);

            response = AplcationAPI.DeleteResource(Resource.User, int.Parse(ConfigTool.GetTagValue("user/delete")));
            statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "Wrong status code");

            response = AplcationAPI.GetResource(Resource.User, ConfigTool.GetTagValue("user/filter"));
            StringAssert.Contains(ConfigTool.GetTagValue("user/check"), response.Content);
        }
    }
}