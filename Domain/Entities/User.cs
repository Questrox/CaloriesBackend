using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Food = new HashSet<Food>();
            FoodEntry = new HashSet<FoodEntry>();
            WaterEntry = new HashSet<WaterEntry>();
        }

        public string FullName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime MealPlanStart { get; set; }

        public int? MealPlanId { get; set; }
        public virtual MealPlan? MealPlan { get; set; }

        [JsonIgnore]
        public virtual ICollection<Food> Food { get; set; }
        [JsonIgnore]
        public virtual ICollection<FoodEntry> FoodEntry { get; set; }
        [JsonIgnore]
        public virtual ICollection<WaterEntry> WaterEntry { get; set; }

    }
}
