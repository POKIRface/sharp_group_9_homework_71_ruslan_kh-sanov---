using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Models;

namespace task1.Controllers
{
    public class InstagramController : Controller
    {
        private UsersContext _db;

        public InstagramController(UsersContext db)
        {
            _db = db;
        }

        public IActionResult MainPage()
        {
            ViewBag.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = _db.ContextUsers.FirstOrDefault(u=>u.Id==id);
            user.Photos = _db.Photos.Where(p => p.UserId == id).ToList();
            return View(user);
        }

        public IActionResult MainPhoto(int id)
        {
            try
            {
                Photo photo = _db.Photos.FirstOrDefault(p => p.Id == id);
                ViewBag.Picture = photo.Picture;
                ViewBag.Likescount = photo.Likescount;
                ViewBag.CommentsCount = photo.Commentscount;
                ViewBag.PictureDescription = photo.PuctureDescription;
                ViewBag.PhotoId = photo.Id;
                ViewBag.Comments = _db.Comments.Where(c => c.PhotoId == id).ToList();
                var user = _db.Users.ToList();
            }catch(NullReferenceException)
            { }
            return View();
        }


        public IActionResult UserSearch(string Person)
        {
            var users = _db.Users.Where(u => u.Login == Person).ToList();
            return View(users);
        }

        public IActionResult MainUser(string id)
        {
            ViewBag.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _db.Users.FirstOrDefault(e => e.Id == id);
            try
            { 
                user.Photos = _db.Photos.Where(p => p.UserId == id).ToList();
            }catch(NullReferenceException)
            {
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Subscribe(string id)
        {
            int count = 0;
            string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User usernow = _db.Users.FirstOrDefault(e => e.Id == userid);
            User userfind = _db.Users.FirstOrDefault(e => e.Id == id);
            foreach (var s in usernow.Subscriptions2)
            {
                if(s==userfind.Id)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                usernow.Subscriptions2.Add(userfind.Id);
                usernow.Subscribers2.Add(usernow.Id);
                userfind.Subscriberscount++;
                usernow.Subscriptionscount++;
                _db.Users.Update(usernow);
                _db.Users.Update(userfind);
            }

            try
            {
                _db.SaveChanges();
            }
            catch(DbUpdateException)
            {

            }

            return Redirect("~/Instagram/MainUser/"+id);
        }

        public IActionResult Subscribers()
        {
            try
            {
                string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                User user = _db.ContextUsers.FirstOrDefault(u => u.Id == id);
                List<User> users = new List<User>();
                foreach (var c in _db.Users.ToList())
                {
                    foreach (var v in user.Subscribers2.ToList())
                    {
                        if (c.Id == v)
                        {
                            users.Add(c);
                        }
                    }
                }
                return View(users);
            }
            catch(ArgumentNullException)
            {
                return RedirectToAction("MainPage");
            }


        }

        public IActionResult Subscriptions()
        {
            try
            {
                string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                User user = _db.ContextUsers.FirstOrDefault(u => u.Id == id);
                List<User> users = new List<User>();
                foreach (var c in _db.Users.ToList())
                {
                    foreach (var v in user.Subscriptions2.ToList())
                    {
                        if (c.Id == v)
                        {
                            users.Add(c);
                        }
                    }
                }


                return View(users);
            }catch(ArgumentNullException)
            {
                return RedirectToAction("MainPage");
            }
        }

        [HttpPost]
        public IActionResult Like(int id)
        {
            Console.WriteLine(id);
            int count = 0;
            try
            {
            string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = _db.ContextUsers.FirstOrDefault(u => u.Id == userid);
            Photo photo = _db.Photos.FirstOrDefault(p => p.Id == id);
                foreach(var c in photo.UsersLikes.ToList())
                {
                    if(user.Id==c)
                    {

                        count++;
                        Console.WriteLine(count);
                    }
                }
                if(count==0)
                {
                    photo.UsersLikes.Add(user.Id);
                    photo.Likescount++;
                    _db.Photos.Update(photo);
                    _db.SaveChanges();
                }
                return Redirect("~/Instagram/MainPhoto/" + id);
            }
            catch (ArgumentNullException)
            {
                string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                User user = _db.ContextUsers.FirstOrDefault(u => u.Id == userid);
                Photo photo = _db.Photos.FirstOrDefault(p => p.Id == id);
                photo.Likescount++;
                _db.Photos.Update(photo);
                _db.SaveChanges();
                return Redirect("~/Instagram/MainPhoto/" +id);
            }
        }


    }

}