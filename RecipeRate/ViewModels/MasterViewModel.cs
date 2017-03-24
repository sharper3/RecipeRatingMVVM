using RecipeRate.DataServices;
using RecipeRate.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRate.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        public ObservableCollection<RecipeRatingViewModel> Recipes { get; set; }

        public RecipeRatingViewModel SelectedItem { get; set; }

        public MasterViewModel()
        {           
            Recipes = new ObservableCollection<RecipeRatingViewModel>();
            foreach (RecipeRating item in RecipeRatingDataService.GetAll())
            {
                Recipes.Add(new RecipeRatingViewModel(item));  
            }
            foreach (RecipeRatingViewModel vm in Recipes)
            {
                vm.PropertyChanged += Vm_PropertyChanged;
            }
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Recipes");
        }

        public void ChangeSelectedItem(string itemId)
        {
            SelectedItem = Recipes.Where(i => i.ItemId == itemId).SingleOrDefault();
        }

        public void ChangeRating(int rating)
        {
            if (rating < 0 || rating > 5 || SelectedItem == null)
            {
                return;
            }
            SelectedItem.Rating = rating;
            OnPropertyChanged("Recipes");
        }

        protected override void UpdateModel()
        {
            throw new NotImplementedException();
        }

        internal void DeleteCurrentItem()
        {
            Recipes.Remove(SelectedItem);
            SelectedItem.Delete();
        }
    }
}
