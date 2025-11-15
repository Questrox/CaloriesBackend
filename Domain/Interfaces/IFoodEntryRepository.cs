using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFoodEntryRepository
    {
        Task<IEnumerable<FoodEntry>> GetUserFoodEntriesByDateAsync(string userId, DateTime date);
        Task AddFoodEntryAsync(FoodEntry entry);
        Task DeleteFoodEntryAsync(int id);
    }
}
