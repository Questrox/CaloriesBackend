using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlansController : ControllerBase
    {
        private readonly MealPlanService _mealPlanService;
        private readonly UserService _userService;

        public PlansController(MealPlanService mealPlanService, UserService userService)
        {
            _mealPlanService = mealPlanService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealPlanDTO>>> GetMealPlans()
        {
            var plans = await _mealPlanService.GetMealPlansAsync();
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealPlanDTO>> GetMealPlan(int id)
        {
            var plan = await _mealPlanService.GetMealPlanAsync(id);
            return Ok(plan);
        }

        [HttpPut("select/{mealPlanId}")]
        public async Task<ActionResult<UserDTO>> SelectMealPlan(int mealPlanId)
        {
            var userId = User.FindFirst("sub")?.Value;
            var user = await _userService.GetUserByIdAsync(userId);

            user.MealPlanId = mealPlanId;
            user.MealPlanStart = DateTime.UtcNow;

            var updated = await _userService.UpdateUserAsync(user);

            return Ok(updated);
        }
    }
}
