﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundGameStudioWebsite.Models.Blog
{
    public class Post
    {
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public string PostThumbnail { get; set; }
        public string PostType { get; set; } //Like "Seidr", "MeleeVR" etc.
        public string Content { get; set; } // Content to use some form of markup language
    }
}