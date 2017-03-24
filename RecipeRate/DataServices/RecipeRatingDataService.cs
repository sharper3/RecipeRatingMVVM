using RecipeRate.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRate.DataServices
{
    public class RecipeRatingDataService
    {
        private static ConcurrentDictionary<string, RecipeRating> _repository = new ConcurrentDictionary<string, RecipeRating>();

        private static void initializeDatabase()
        {
            Add(new RecipeRating() { Name = "Boneless Buffalo Wings", Id = Guid.NewGuid().ToString(), DateUpdated = DateTime.Now.AddDays(-41), Rating = 4, BadgeSource = "ms-appx://RecipeRate/Assets/bonelesswings.png" });
            Add(new RecipeRating() { Name = "Bowtie Pasta", Id = Guid.NewGuid().ToString(), DateUpdated = DateTime.Now.AddDays(-31), Rating = 1, BadgeSource = "ms-appx://RecipeRate/Assets/bowtiepasta.png" });
            Add(new RecipeRating() { Name = "Hamburger", Id = Guid.NewGuid().ToString(), DateUpdated = DateTime.Now.AddDays(-2), Rating = 5, BadgeSource = "ms-appx://RecipeRate/Assets/hamburger.png" });
            Add(new RecipeRating() { Name = "Complete Breakfast", Id = Guid.NewGuid().ToString(), DateUpdated = DateTime.Now.AddDays(-22), Rating = 2, BadgeSource = "ms-appx://RecipeRate/Assets/breakfast.png" });
            Add(new RecipeRating() { Name = "Meatloaf", Id = Guid.NewGuid().ToString(), DateUpdated = DateTime.Now.AddDays(-2), Rating = 3, BadgeSource = "ms-appx://RecipeRate/Assets/meatloaf.png" });
            Add(new RecipeRating() { Name = "Salmon with Asparagus", Id = Guid.NewGuid().ToString(), DateUpdated = DateTime.Now.AddDays(-123), Rating = 1, BadgeSource = "ms-appx://RecipeRate/Assets/salmon.png" });
        }
        public static IEnumerable<RecipeRating> GetAll()
        {
            if (_repository.Count == 0)
            {
                initializeDatabase();
            }
            return _repository.Values;
        }

        public static void Add(RecipeRating item)
        {
            item.Id = Guid.NewGuid().ToString();
            _repository[item.Id] = item;
        }

        public static RecipeRating Find(string Id)
        {
            RecipeRating item;
            _repository.TryGetValue(Id, out item);
            return item;
        }

        public static RecipeRating Remove(string Id)
        {
            RecipeRating item;
            _repository.TryGetValue(Id, out item);
            _repository.TryRemove(Id, out item);
            return item;
        }

        public static void Update(RecipeRating item)
        {
            _repository[item.Id] = item;
        }
    }
}
