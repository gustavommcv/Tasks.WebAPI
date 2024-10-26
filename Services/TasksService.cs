using Entities.Models;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository) 
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<TaskResponse> AddTask(TaskPostRequest? taskAddRequest)
        {
            // Check if taskAddRequest is not null
            if (taskAddRequest == null) throw new ArgumentNullException(nameof(taskAddRequest));

            // Model validation
            ValidationHelper.ModelValidation(taskAddRequest);

            // Convert taskAddRequest into UserTask type
            UserTask task = taskAddRequest.ToTask();

            // Generates a new Task Id
            task.Id = Guid.NewGuid();

            // Add Task object into database
            await _tasksRepository.AddTask(task);

            // Convert the Task object into TaskResponse type
            return task.ToTaskResponse();
        }

        public async Task<IEnumerable<TaskResponse>> GetAllTasks()
        {
            var tasks = await _tasksRepository.GetAllTasks();

            return tasks.Select(task => task.ToTaskResponse());
        }

        public async Task<TaskResponse?> GetTaskByTaskId(Guid? taskId)
        {
            if (taskId == null) return null;

            UserTask? task = await _tasksRepository.GetTaskById(taskId.Value);

            if (task == null) return null;

            return task.ToTaskResponse();
        }

        public async Task<TaskResponse> UpdateTask(TaskPutRequest? taskUpdateRequest)
        {
            if (taskUpdateRequest == null) throw new ArgumentNullException(nameof(taskUpdateRequest));

            // Validation
            ValidationHelper.ModelValidation(taskUpdateRequest);

            // Get matching task object to update
            UserTask? matchingTask = await _tasksRepository.GetTaskById(taskUpdateRequest.Id);

            if (matchingTask == null) throw new ArgumentException("Given id doesn't exist");

            // Update all details
            matchingTask.Title = taskUpdateRequest.Title;
            matchingTask.status = taskUpdateRequest.status.ToString();
            matchingTask.Description = taskUpdateRequest.Description;

            await _tasksRepository.UpdateTask(matchingTask); // UPDATE

            return matchingTask.ToTaskResponse();
        }

        public async Task<bool> DeleteTask(Guid? taskId)
        {
            if (taskId == null) throw new ArgumentNullException(nameof(taskId));

            UserTask? task = await _tasksRepository.GetTaskById(taskId.Value);

            if (task == null) return false;

            await _tasksRepository.DeleteTaskByTaskId(taskId.Value);

            return true;
        }
    }
}
