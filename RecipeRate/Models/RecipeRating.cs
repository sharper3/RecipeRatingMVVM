using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRate.Models
{
    public class RecipeRating
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime DateUpdated { get; set; }
        public string BadgeSource { get; set; }
    }
}
