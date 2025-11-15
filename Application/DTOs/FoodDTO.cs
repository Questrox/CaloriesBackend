using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class FoodDTO
    {
        public FoodDTO() { }
        public FoodDTO(Food f)
        {
            Id = f.Id;
            Name = f.Name;
            EngName = f.EngName;
            Calories = f.Calories;
            Protein = f.Protein;
            Fat = f.Fat;
            Carbs = f.Carbs;
            UserId = f.UserId;
            User = f.User;
            FoodEntry = f.FoodEntry.Select(fe => new FoodEntryDTO(fe)).ToList();
        }

        public FoodDTO(FoodDTO f)
        {
            Id = f.Id;
            Name = f.Name;
            EngName = f.EngName;
            Calories = f.Calories;
            Protein = f.Protein;
            Fat = f.Fat;
            Carbs = f.Carbs;
            UserId = f.UserId;
            User = f.User;
            FoodEntry = f.FoodEntry;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? EngName { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbs { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<FoodEntryDTO>? FoodEntry { get; set; }
    }

}
