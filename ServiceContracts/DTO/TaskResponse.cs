using Entities.Models;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents DTO class that is used as return type of most methods of Persons Service
    /// </summary>
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? status { get; set; }

        /// <summary>
        /// Compares the current object data with the parameter object
        /// </summary>
        /// <param name="obj">The TaskResponse</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if (obj.GetType() != typeof(TaskResponse)) return false;

            TaskResponse task = (TaskResponse)obj;
            return task.Id == Id && task.status == status && task.Title == Title && task.Description == Description;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class TaskExtensions
    {
        /// <summary>
        /// An extension method to convert an object of UserTask class into a TaskResponse class
        /// </summary>
        /// <param name="task">The UserTask object</param>
        /// <returns>Returns the converted TaskResponse object</returns>
        public static TaskResponse ToTaskResponse(this UserTask task)
        {
            return new TaskResponse()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                status = task.status
            };
        }
    }
}
