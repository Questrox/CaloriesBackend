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
    public class WaterEntryService
    {
        private readonly IWaterEntryRepository _WERepository;
        public WaterEntryService(IWaterEntryRepository WERepository)
        {
            _WERepository = WERepository;
        }
        public async Task<IEnumerable<WaterEntryDTO>> GetUserWaterEntriesByDateAsync(string userId, DateTime date)
        {
            var entries = await _WERepository.GetUserWaterEntriesByDateAsync(userId, date);
            return entries.Select(e => new WaterEntryDTO(e));
        }
        public async Task<WaterEntryDTO> AddWaterEntryAsync(CreateWaterEntryDTO entry)
        {
            var NewWE = new WaterEntry
            {
                Date = entry.Date,
                Amount = entry.Amount,
                UserId = entry.UserId,
            };
            await _WERepository.AddWaterEntryAsync(NewWE);
            return new WaterEntryDTO(NewWE);
        }
        public async Task DeleteFoodEntryAsync(int id)
        {
            await _WERepository.DeleteWaterEntryAsync(id);
        }
    }
}
