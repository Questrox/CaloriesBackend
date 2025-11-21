using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlansController(MealPlanService _mealPlanService, UserService _userService) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<MealPlanDTO>>> GetMealPlans()
        {
            var plans = await _mealPlanService.GetMealPlansAsync();
            return Ok(plans);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<MealPlanDTO>> GetMealPlan(int id)
        {
            var plan = await _mealPlanService.GetMealPlanAsync(id);
            return Ok(plan);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<UserDTO>> SelectMealPlan(int mealPlanId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userService.GetUserByIdAsync(userId);

            user.MealPlanId = mealPlanId;
            user.MealPlanStart = DateTime.UtcNow;

            var updated = await _userService.UpdateUserAsync(user);

            return Ok(updated);
        }
    }
}
