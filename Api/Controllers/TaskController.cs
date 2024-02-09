using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Entities.DTO;

namespace TaskList_BusinessBooster.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Task>>> GetAllTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortBy = "", [FromQuery] string filterBy = "")
        {
            var query = new GetAllTasksQuery
            {
                Page = page,
                PageSize = pageSize,
                SortBy = sortBy,
                FilterBy = filterBy
            };

            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDTO taskDto)
        {
            
            var command = new AddTaskCommand
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                TaskListId = taskDto.TaskListId
            };
            var taskId = await _mediator.Send(command);

            return CreatedAtRoute(new { id = taskId }, taskId);
        }
        [HttpPost("status-history")]
        public async Task<IActionResult> AddTaskStatusHistory(AddTaskStatusHistoryDTO statusHistoryDTO)
        {
            var command = new AddTaskStatusHistoryCommand(
                statusHistoryDTO.TaskId,
                statusHistoryDTO.OldStatus,
                statusHistoryDTO.NewStatus,
                DateTime.Now.ToString()
            );

            var newStatusHistoryId = await _mediator.Send(command);

            return CreatedAtAction(nameof(AddTaskStatusHistory), new { id = newStatusHistoryId }, null);
        }

        [HttpGet("clear-tasks")]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Task>>> GetClearTasks()
        {
            var query = new GetAllClearTasksQuery();
            var result = await _mediator.Send(query);
            foreach (var task in result)
            {
                var queryComments = new GetCommentByTaskIdCommand(task.Id);
                var comments = await _mediator.Send(queryComments);
                task.Comments = comments;

            }

            return Ok(result);
        }
        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] UpdateTaskCommand command)
        {
            if (taskId != command.TaskId)
            {
                return BadRequest("Task ID mismatch");
            }

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var command = new DeleteTaskCommand { TaskId = taskId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
