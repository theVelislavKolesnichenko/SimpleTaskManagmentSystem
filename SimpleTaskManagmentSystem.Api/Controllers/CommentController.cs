namespace SimpleTaskManagmentSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SimpleTaskManagmentSystem.Application.Contracts.Repositories;
    using System.Linq;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private ICommentRepository commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        [HttpGet("get")]
        public IActionResult GetBySearchText(string searchText)
        {
            var response = commentRepository.Get(searchText);

            if (response == null)
                return BadRequest(new { message = "Contact missing" });

            return Ok(response.Select(c => new { c.Id, c.Content, c.CreatedDate, c.TaskId, c.ReminderDate, c.Type }));
        }
    }
}
