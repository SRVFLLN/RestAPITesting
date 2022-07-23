using JSONHolderProject.Models;
using JSONHolderProject.Utils;
using System.Collections.Generic;

namespace JSONHolderProject
{
    public static class ResourceSource
    {
        public static IEnumerable<IResource> Resource 
        {
            get 
            {
                yield return new Post()
                {
                    Body = TextUtils.GetRandomText(),
                    Title = TextUtils.GetRandomText(),
                    UserId = int.Parse(ConfigTool.GetTagValue("post/userId"))
                };
                yield return new Comment()
                {
                    PostId = int.Parse(ConfigTool.GetTagValue("comment/postId")),
                    Email = ConfigTool.GetTagValue("comment/email"),
                    Name = TextUtils.GetRandomText(5),
                    Body = TextUtils.GetRandomText(10)
                };
                //yield return new Album()
                //{
                //    UserId = 4,
                //    Title = TextUtils.GetRandomText(4)
                //};
                //yield return new Photo()
                //{
                //    AlbumId = 3,
                //    Title = TextUtils.GetRandomText(6),
                //    Url = "https://via.placeholder.com/600/0000FF",
                //    ThumbnailUrl = "https://via.placeholder.com/150/0000FF"
                //};
                //yield return new ToDo()
                //{
                //    UserId = 2,
                //    Title = TextUtils.GetRandomText(4),
                //    Completed = "false"
                //};
                //yield return new User()
                //{
                //    Name = TextUtils.GetRandomText(2),
                //    Username = TextUtils.GetRandomText(1),
                //    Email = TextUtils.GetRandomText(4),
                //    Adress = new Adress()
                //};
            }
        }
    }
}
