using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMediaAPI.Controllers
{
    public class CommentController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Comment(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            if(comment.Post == null)
            {
                return BadRequest("Request Body Can't Be Empty");
            }
            var service = CreateCommentService();

            if (!service.CreateComment(comment))
            {
                return InternalServerError();
            }

            return Ok();
        }
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }

        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetUserComments();
            return Ok(comments);
        }

        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            return Ok();
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int Id)
        {
            var service = CreateCommentService();
            if (!service.DeleteComment(Id))
                return InternalServerError();

            return Ok();

        }
    }
}
