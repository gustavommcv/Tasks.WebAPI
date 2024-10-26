using Entities.Models;
using ServiceContracts.DTO.Enums;
using ServiceContracts.DTO.Validations;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Acts as a DTO for inserting a new Task
    /// </summary>
    public class TaskPostRequest
    {
        public TaskPostRequest(string title, string description = "", Status status = Status.Pending)
        {
            Title = title;
            Description = description;
            this.status = status;
        }

        [StringLength(100)]
        [Required(ErrorMessage = "Task title cannot be blank")]
        public string? Title { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }

        [ValidEnum(typeof(Status))]
        public Status status { get; set; }

        /// <summary>
        /// Converts the current object of TaskAddRequest into a new object of Task Type
        /// </summary>
        /// <returns>A new object of task type</returns>
        public UserTask ToTask()
        {
            return new UserTask { Title = Title, Description = Description, status = status.ToString() };
        }
    }
}
