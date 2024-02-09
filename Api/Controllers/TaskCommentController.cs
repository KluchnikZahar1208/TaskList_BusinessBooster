using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Entities.DTO;

namespace TaskList_BusinessBooster.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("comments")]
        public async Task<ActionResult<IEnumerable<TaskComment>>> GetAllComments()
        {
            var query = new GetAllCommentsQuery();
            var comments = await _mediator.Send(query);
            return Ok(comments);
        }
        [HttpPost("comments")]
        public async Task<ActionResult<int>> AddComment(TaskCommentDTO taskCommentDTO)
        {
            var command = new GetUserByEmailCommand(User.FindFirst(ClaimTypes.Email)?.Value);
            var user = await _mediator.Send(command);

            var commandAddComment = new AddCommentCommand(taskCommentDTO.Comment, taskCommentDTO.TaskId, user.Id);
            var commentId = await _mediator.Send(commandAddComment);
            return CreatedAtRoute(new { id = commentId }, commentId);
        }
        [HttpGet("comments/{id}")]
        public async Task<ActionResult<TaskComment>> GetCommentById(int id)
        {
            var command = new GetCommentByIdCommand { CommentId = id };
            var comment = await _mediator.Send(command);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        [HttpPut("comments/{id}")]
        public async Task<IActionResult> UpdateComment(int id, UpdateCommentCommand command)
        {
            if (id != command.CommentId)
            {
                return BadRequest("Comment ID mismatch");
            }

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to update comment: {ex.Message}");
            }
        }
        [HttpDelete("comments/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var command = new DeleteCommentCommand { CommentId = id };

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to delete comment: {ex.Message}");
            }
        }
        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskComment>> GetCommentByTaskId(int taskId)
        {
            var query = new GetCommentByTaskIdCommand(taskId);
            var comment = await _mediator.Send(query);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }
    }
}
