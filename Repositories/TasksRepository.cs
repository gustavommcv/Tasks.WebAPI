using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDbContext _context;

        public TasksRepository(ApplicationDbContext context) { _context = context; }

        public async Task<UserTask> AddTask(UserTask task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTaskByTaskId(Guid id)
        {
            _context.Tasks.RemoveRange(_context.Tasks.Where(task => task.Id == id));
            int rowsDeleted = await _context.SaveChangesAsync();

            return rowsDeleted > 0;
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<UserTask?> GetTaskById(Guid id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(task => task.Id == id);
        }

        public Task<UserTask?> GetTaskByName(string taskName)
        {
            throw new NotImplementedException();
        }

        public async Task<UserTask> UpdateTask(UserTask task)
        {
            var matchingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);

            if (matchingTask == null) { throw new Exception("User not found"); }

            matchingTask.status = task.status;
            matchingTask.Title = task.Title;
            matchingTask.Description = task.Description;

            int countUpdated = await _context.SaveChangesAsync();

            return matchingTask;
        }
    }
}
