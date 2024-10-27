using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Person entity
    /// </summary>
    public interface ITasksService
    {
        /// <summary>
        /// Adds a new Task into the DataBase
        /// </summary>
        /// <param name="taskAddRequest">Task to add</param>
        /// <returns>Returns the same task details, along with newly generated Id</returns>
        Task<TaskResponse> AddTask(TaskPostRequest? taskAddRequest);

        /// <summary>
        /// Returns all tasks
        /// </summary>
        /// <returns>Returns a list of objects of TaskResponse type</returns>
        Task<IEnumerable<TaskResponse>> GetAllTasks();

        /// <summary>
        /// Returns the task object based on the given Id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>Returns matching task object</returns>
        Task<TaskResponse?> GetTaskByTaskId(Guid? taskId);

        /// <summary>
        /// Updates the specified task details based on the given Id
        /// </summary>
        /// <param name="taskUpdateRequest">Task details to update</param>
        /// <returns>Returns the task response object after update</returns>
        Task<TaskResponse> UpdateTask(TaskPutRequest? taskUpdateRequest);

        /// <summary>
        /// Deletes a task based on the given Id
        /// </summary>
        /// <param name="taskId">Task Id to delete</param>
        /// <returns>Returns true, if the deletion was successful; otherwise false</returns>
        Task<bool> DeleteTask(Guid? taskId);
    }
}
