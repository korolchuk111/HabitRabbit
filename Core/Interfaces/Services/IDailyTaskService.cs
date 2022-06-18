using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.DailyTaskDTO;

namespace Core.Interfaces.Services
{
    public interface IDailyTaskService
    {
        Task<IList<DailyTaskDTO>> GetAllTasksForTodayByUser(string userId);
    }
}
