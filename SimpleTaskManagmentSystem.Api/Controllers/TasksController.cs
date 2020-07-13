namespace SimpleTaskManagmentSystem.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SimpleTaskManagmentSystem.Application.Contracts.Repositories;
    using System.Linq;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private ITaskRepository taskService;

        public TasksController(ITaskRepository taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var response = taskService.GetTasks();

            if (response == null)
                return BadRequest(new { message = "Tasks missing" });

            return Ok(response.Select(t => new { t.Id, t.CreatedDate, t.RequiredByDate, t.Description, t.Status, t.Type }));
        }
    }
}
