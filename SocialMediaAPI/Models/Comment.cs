using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMediaAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int GuidAuthor { get; set; }

        //public List<Reply> Reply { get; set; }

        //foreign key via original Post
    }
}