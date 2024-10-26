using Entities.Models;

namespace RepositoryContracts
{
    public interface ITasksRepository
    {
        /// <summary>
        /// Adds a new task to the repository.
        /// </summary>
        /// <param name="task">The task to be added.</param>
        /// <returns>Returns the added task.</returns>
        Task<UserTask> AddTask(UserTask task);

        /// <summary>
        /// Retrieves all tasks stored in the repository.
        /// </summary>
        /// <returns>A list of all tasks.</returns>
        Task<IEnumerable<UserTask>> GetAllTasks();

        /// <summary>
        /// Retrieves a task by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the task.</param>
        /// <returns>The task that matches the identifier, or null if not found.</returns>
        Task<UserTask?> GetTaskById(Guid id);

        /// <summary>
        /// Retrieves a task by its name.
        /// </summary>
        /// <param name="taskName">The name of the task to retrieve.</param>
        /// <returns>The task that matches the name, or null if not found.</returns>
        Task<UserTask?> GetTaskByName(string taskName);

        /// <summary>
        /// Deletes a task using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the task to delete.</param>
        /// <returns>Returns true if the task was successfully deleted, or false if not found.</returns>
        Task<bool> DeleteTaskByTaskId(Guid id);

        /// <summary>
        /// Updates an existing task with new information.
        /// </summary>
        /// <param name="task">The task with updated information.</param>
        /// <returns>The updated task.</returns>
        Task<UserTask> UpdateTask(UserTask task);
    }
}
