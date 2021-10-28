using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers
{
    public class PhotosController : Controller
    {
        public string mainid;
        private UsersContext _db;

        public PhotosController(UsersContext db)
        {
            _db = db;
        }

        public IActionResult Add(string userid)
        {
            Photo photo = new Photo
            {
                UserId = userid
            };
            
            return View(photo);
        }

        [HttpPost]
        public IActionResult Add(Photo photo)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    Photo p = new Photo
                    {
                        Picture = photo.Picture,
                        PuctureDescription = photo.PuctureDescription,
                        Commentscount = 0,
                        Likescount = 0,
                        UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };
                    user.Photoscount++;
                    _db.Photos.Add(p);
                    _db.SaveChanges();
                    
                }
                return Redirect("~/Instagram/MainPage");
            }
            else
            {
                return View("Add");
            }
        }

        [HttpPost]
        public IActionResult Comment(int id,Comment comment)
        {
            if (ModelState.IsValid)
            {
                if (comment != null)
                {
                    Comment c = new Comment
                    {
                        CommentText=comment.CommentText,
                        PhotoId=id,
                        UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                    };
                    Photo photo = _db.Photos.FirstOrDefault(p => p.Id == id);
                    photo.Commentscount++;
                    _db.Comments.Add(c);
                    _db.SaveChanges();

                }
                return Redirect("~/Instagram/MainPhoto/"+id);
            }
            else
            {
                return Redirect("~/Instagram/MainPhoto/"+id);
            }
        }

    }

}