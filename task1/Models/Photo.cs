using System;
using System.Collections.Generic;

namespace task1.Models
{
    public class Photo
    {
        public List<string> UsersLikes { get; set; }
        public int Id { get; set; }
        public string Picture { get; set; }
        public string PuctureDescription { get; set; }
        public int Commentscount { get; set; }
        public int Likescount { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }

        public Photo()
        {
            UsersLikes = new List<string>();
            Comments = new List<Comment>();
           
        }
    }
}