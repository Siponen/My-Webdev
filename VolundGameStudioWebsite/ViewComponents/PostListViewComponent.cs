using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolundGameStudioWebsite.Data;
using VolundGameStudioWebsite.Models.Blog;

namespace VolundGameStudioWebsite.Views.Home
{
    [ViewComponent(Name="PostList")]
    public class PostListViewComponent : ViewComponent
    {
        private readonly BlogContext db;

        public PostListViewComponent(BlogContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            int maxPosts, bool isDone)
        {
            var posts = await GetPostsAsync(maxPosts, isDone);
            return View(posts);
        }

        private Task<List<Post>> GetPostsAsync(int maxPosts, bool isDone)
        {
            var year = DateTime.Today.Year;
            return db.Posts.Where(p => p.PostDate.Year == year).OrderByDescending(p => p.PostDate).Take(maxPosts)
                .ToListAsync();
        }
    }
}
