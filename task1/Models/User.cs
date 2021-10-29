using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace task1.Models
{
    public class User : IdentityUser
    {
        public string Avatar { get; set; }
        public string UserDescription { get; set; }
        public string Gender { get; set; }
        public int Subscriberscount { get; set; }
        public int Photoscount { get; set; }
        public string Login { get; set; }
        public int Subscriptionscount { get; set; }

 

        public List<string> Subscriptions2 { get; set; }
        public List<string> Subscribers2 { get; set; }
        public List<Photo> Photos { get; set; }
        public List<User> Subscribers { get; set; }
        public List<User> Subscriptions { get; set; }

        public User()
        {
            Subscriptions2 = new List<string>();
            Subscribers2 = new List<string>();
            Subscribers = new List<User>();
            Subscriptions = new List<User>();
        }


        



    }


}