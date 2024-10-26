using Entities.Models;
using ServiceContracts.DTO.Enums;
using ServiceContracts.DTO.Validations;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents the DTO class that contains the task details to update
    /// </summary>
    public class TaskPutRequest
    {
        [Required(ErrorMessage = "Id can't be blank")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title can't be blank")]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Status can't be blank")]
        [ValidEnum(typeof(Status))]
        public Status? status { get; set; }

        /// <summary>
        /// Converts the current object of TaskUpdateRequest into a new object of UserTask type
        /// </summary>
        /// <returns>Returns UserTask object</returns>
        public UserTask ToTask()
        {
            return new UserTask { Id = Id, Title = Title, Description = Description, status = status?.ToString() };
        }
    }
}
