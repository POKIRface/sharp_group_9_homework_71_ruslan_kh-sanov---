using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers
{
    public class CommentController : Controller
    {
        private UsersContext _db;

        public CommentController(UsersContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Comment(int id, Comment comment)
        {
            Photo photo = _db.Photos.FirstOrDefault(p => p.Id == id);
            if (ModelState.IsValid)
            {
                if (comment != null)
                {
                    Comment c = new Comment
                    {
                        CommentText = comment.CommentText,
                        PhotoId = id,
                        UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                    };
                    photo.Commentscount++;
                    _db.Comments.Add(c);
                    _db.SaveChanges();

                }
                return Redirect("~/Instagram/MainPhoto");
            }
            else
            {
                return View("~/Instagram/MainPhoto");
            }
        }

    }

}