using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolundGameStudioWebsite.Models.Blog;

namespace VolundGameStudioWebsite.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=devblog.db");
        }
    }
}
