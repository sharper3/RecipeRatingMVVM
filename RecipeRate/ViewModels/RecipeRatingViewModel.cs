using RecipeRate.DataServices;
using RecipeRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRate.ViewModels
{
    public class RecipeRatingViewModel : ViewModelBase
    {
        private RecipeRating This;

        public RecipeRatingViewModel(RecipeRating recipeRating)
        {
            This = recipeRating;

        }
        public DateTime DateUpdated
        {
            get
            {
                return This.DateUpdated;
            }

            set
            {
                //this.SetProperty(ref this.This.DateUpdated, value);
                SetProperty(This.DateUpdated, value, () => This.DateUpdated = value);
            }
        }

        public int Rating
        {
            get
            {
                return This.Rating;
            }

            set
            {

                //this.SetProperty(ref this._ratingString, value);
                SetProperty(This.Rating, value, () => This.Rating = value);
            }
        }

        public string RecipeName
        {
            get
            {
                return This.Name;
            }

            set
            {
                //this.SetProperty(ref this._recipeName, value);
                SetProperty(This.Name, value, () => This.Name = value);

            }
        }

        public string BadgeSource
        {
            get
            {
                return This.BadgeSource;
            }

            set
            {
                //this.SetProperty(ref this._badgeSource, value);
                SetProperty(This.BadgeSource, value, () => This.BadgeSource = value);
            }
        }

        internal void Delete()
        {
            RecipeRatingDataService.Remove(This.Id);
        }

        public string ItemId
        {
            get
            {
                return This.Id;
            }

            private set
            {
                
            }
        }

        protected override void UpdateModel()
        {
            RecipeRatingDataService.Update(This);
        }
    }
}
