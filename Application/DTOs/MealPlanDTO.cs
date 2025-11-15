using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MealPlanDTO
    {
        public MealPlanDTO() { }
        public MealPlanDTO(MealPlan mp)
        {
            Id = mp.Id;
            Title = mp.Title;
            Description = mp.Description;
            FullDescription = mp.FullDescription;
            BenefitsJson = mp.BenefitsJson;
            WarningsJson = mp.WarningsJson;
            Calories = mp.Calories;
            Protein = mp.Protein;
            Fat = mp.Fat;
            Carbs = mp.Carbs;
            MealPlanDay = mp.MealPlanDay.Select(d => new MealPlanDayDTO(d)).ToList();
            User = mp.User;
        }

        public MealPlanDTO(MealPlanDTO mp)
        {
            Id = mp.Id;
            Title = mp.Title;
            Description = mp.Description;
            FullDescription = mp.FullDescription;
            BenefitsJson = mp.BenefitsJson;
            WarningsJson = mp.WarningsJson;
            Calories = mp.Calories;
            Protein = mp.Protein;
            Fat = mp.Fat;
            Carbs = mp.Carbs;
            MealPlanDay = mp.MealPlanDay;
            User = mp.User;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string BenefitsJson { get; set; }
        public string? WarningsJson { get; set; }
        public string Calories { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Carbs { get; set; }
        public ICollection<MealPlanDayDTO>? MealPlanDay { get; set; }
        public ICollection<User>? User { get; set; }
    }
}
