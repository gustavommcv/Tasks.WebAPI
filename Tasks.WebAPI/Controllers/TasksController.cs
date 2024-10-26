using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.DTO.Enums;

namespace Tasks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _tasksService.GetAllTasks();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var taskResponse = await _tasksService.GetTaskByTaskId(id);

            if (taskResponse == null) return NotFound();

            return Ok(taskResponse);
        }


        [HttpPost]
        public async Task<IActionResult> PostTask(TaskPostRequest taskAddRequest)
        {
            var taskResponse = await _tasksService.AddTask(taskAddRequest);

            return CreatedAtAction(nameof(GetTaskById), new { id = taskResponse.Id }, taskResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(Guid id, [FromBody] TaskPutRequest taskPutRequest)
        {
            if (id != taskPutRequest.Id) return BadRequest("ID mismatch.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var taskResponse = await _tasksService.GetTaskByTaskId(id);

            if (taskResponse == null) return NotFound();

            var updatedTask = await _tasksService.UpdateTask(taskPutRequest);
            return Ok(updatedTask);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTask(Guid id, [FromBody] TaskPatchRequest taskPatchRequest)
        {
            if (taskPatchRequest == null) return BadRequest("Invalid update request.");

            var taskResponse = await _tasksService.GetTaskByTaskId(id);
            if (taskResponse == null) return NotFound();

            var updatedTaskRequest = new TaskPutRequest
            {
                Id = id,
                Title = taskPatchRequest.Title ?? taskResponse.Title,
                Description = taskPatchRequest.Description ?? taskResponse.Description,
                status = taskPatchRequest.status ?? (taskResponse.status == "Pending" ? Status.Pending : Status.Completed)
            };

            var updatedTask = await _tasksService.UpdateTask(updatedTaskRequest);

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid? id)
        {
            if (id == null) return BadRequest("Invalid ID");

            var taskResponse = await _tasksService.GetTaskByTaskId(id);

            if (taskResponse == null) return NotFound();

            await _tasksService.DeleteTask(taskResponse.Id);

            return NoContent();
        }
    }
}
