namespace SimpleTaskManagmentSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SimpleTaskManagmentSystem.Application.Contracts.Repositories;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using System.Linq;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ITaskRepository taskService;
        private string message = "Tasks missing";

        public TasksController(ITaskRepository taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = taskService.GetTasks();

            if (response == null)
                return BadRequest(new { message });

            return Ok(response.Select(t => new { t.Id, t.CreatedDate, t.RequiredByDate, t.Description, t.Status, t.Type }));
        }

        [HttpGet("insert")]
        public IActionResult Insert([FromBody] Task task)
        {
            int response = taskService.Insert(task);

            if (response == 0)
                return BadRequest(new { message });

            return Ok(response);
        }

        [HttpGet("update")]
        public IActionResult Update([FromBody] Task task)
        {
            var response = taskService.Update(task);

            if (response)
                return BadRequest(new { message });

            return Ok();
        }
    }
}
