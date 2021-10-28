using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace task1.Models
{
    public class UsersContext : IdentityDbContext<User>
    {
        public DbSet<User> ContextUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options)
             : base(options)
        {
        }
    }
}