using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiaryController : ControllerBase
    {
        private readonly FoodService _foodService;
        private readonly FoodEntryService _foodEntryService;
        private readonly WaterEntryService _waterEntryService;

        public DiaryController(FoodService foodService, FoodEntryService foodEntryService, WaterEntryService waterEntryService)
        {
            _foodService = foodService;
            _foodEntryService = foodEntryService;
            _waterEntryService = waterEntryService;
        }

        [HttpGet("foods")]
        public async Task<ActionResult<IEnumerable<FoodDTO>>> GetFoods()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var foods = await _foodService.GetAllFoodsForUserAsync(userId);
            return Ok(foods);
        }

        [HttpPost("foods")]
        public async Task<ActionResult<FoodDTO>> AddFood(CreateFoodDTO dto)
        {
            dto.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var food = await _foodService.AddFoodAsync(dto);
            return Ok(food);
        }

        [HttpGet("food-entries")]
        public async Task<ActionResult<IEnumerable<FoodEntryDTO>>> GetFoodEntries(DateTime date)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var entries = await _foodEntryService.GetUserFoodEntriesByDateAsync(userId, date.Date);
            return Ok(entries);
        }

        [HttpPost("food-entries")]
        public async Task<ActionResult<FoodEntryDTO>> AddFoodEntry(CreateFoodEntryDTO dto)
        {
            dto.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var entry = await _foodEntryService.AddFoodEntryAsync(dto);
            return Ok(entry);
        }

        [HttpDelete("food-entries/{id}")]
        public async Task<IActionResult> DeleteFoodEntry(int id)
        {
            await _foodEntryService.DeleteFoodEntryAsync(id);
            return NoContent();
        }

        [HttpGet("water")]
        public async Task<ActionResult<IEnumerable<WaterEntryDTO>>> GetWaterEntries(DateTime date)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var entries = await _waterEntryService.GetUserWaterEntriesByDateAsync(userId, date.Date);
            return Ok(entries);
        }

        [HttpPost("water")]
        public async Task<ActionResult<WaterEntryDTO>> AddWaterEntry(CreateWaterEntryDTO dto)
        {
            dto.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var entry = await _waterEntryService.AddWaterEntryAsync(dto);
            return Ok(entry);
        }

        [HttpDelete("water/{id}")]
        public async Task<IActionResult> DeleteWaterEntry(int id)
        {
            await _waterEntryService.DeleteFoodEntryAsync(id);
            return NoContent();
        }
    }
}
