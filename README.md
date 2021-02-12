# teamGit
CommentCreate.cs
  public class CommentCreate
    {
        [Required]
        [MaxLength(10000)]
        public string Content { get; set; }

        public int PostId { get; set; }                               //ALLOW USER TO DICTATE WHICH POST THEY COMMENT ON
    }
    
CommentService.cs
    public bool CreateComment(CommentCreate Model)
        {
            var entity =
                new Comment()
                {
                    AuthorId = _userId,
                    Text = Model.Content,
                    PostId = Model.PostId                             //WRITES COMMNET TO DESIRED POST
                };
                
     public IEnumerable<CommentListItem> GetUserComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.AuthorId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Content = e.Text                       //FIX NULL CONTENT
                                }
                        );
                return query.ToArray();
            }
        }
