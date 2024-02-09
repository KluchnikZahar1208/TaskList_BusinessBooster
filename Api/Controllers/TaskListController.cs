using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Application.Queries;
using TaskList_BusinessBooster.Domain.Entities.DTO;
using TaskList_BusinessBooster.Domain.Entities;

namespace TaskList_BusinessBooster.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> GetAllTaskLists()
        {
            var query = new GetAllTaskListsQuery();

            var taskLists = await _mediator.Send(query);

            return Ok(taskLists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetByIdTaskList(int id)
        {
            var query = new GetByIdTaskListQuery(id);

            var taskList = await _mediator.Send(query);

            if (taskList == null)
            {
                return NotFound();
            }

            return Ok(taskList);
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddTaskList(TaskListDTO taskListDTO)
        {
            var command = new GetUserByEmailCommand(User.FindFirst(ClaimTypes.Email)?.Value);
            var user = await _mediator.Send(command);

            var commandAddList = new AddTaskListCommand(taskListDTO.Title, taskListDTO.Description, user.Id);

            var taskListId = await _mediator.Send(commandAddList);
            return Ok(taskListId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskList(int id, UpdateTaskListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Invalid task list ID.");
            }

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskList(int id)
        {
            var command = new DeleteTaskListCommand(id);

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
