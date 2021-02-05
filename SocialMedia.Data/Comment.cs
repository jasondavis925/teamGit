using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        //[ForeignKey(nameof(Reply))]
        //public int ReplyId { get; set; }
        //public virtual Reply reply { get; set; } whats up studs

    }
}
