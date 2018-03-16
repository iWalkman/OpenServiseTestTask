using System;
namespace TestOpen.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Content { get; set; }
    }
}
