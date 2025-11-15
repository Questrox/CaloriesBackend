using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FoodEntryService
    {
        private readonly IFoodEntryRepository _FERepository;
        public FoodEntryService(IFoodEntryRepository fERepository)
        {
            _FERepository = fERepository;
        }
        public async Task<IEnumerable<FoodEntryDTO>> GetUserFoodEntriesByDateAsync(string userId, DateTime date)
        {
            var entries = await _FERepository.GetUserFoodEntriesByDateAsync(userId, date);
            return entries.Select(e => new FoodEntryDTO(e));
        }
        public async Task<FoodEntryDTO> AddFoodEntryAsync(CreateFoodEntryDTO entry)
        {
            var NewFE = new FoodEntry
            {
                Date = entry.Date,
                Weight = entry.Weight,
                FoodId = entry.FoodId,
                MealTypeId = entry.MealTypeId,
                UserId = entry.UserId
            };
            await _FERepository.AddFoodEntryAsync(NewFE);
            return new FoodEntryDTO(NewFE);
        }
        public async Task DeleteFoodEntryAsync(int id)
        {
            await _FERepository.DeleteFoodEntryAsync(id);
        }
    }
}
