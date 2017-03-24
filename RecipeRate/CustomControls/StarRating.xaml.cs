using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace RecipeRate.CustomControls
{
    public sealed partial class StarRating : UserControl, INotifyPropertyChanged
    {
        private int _visibleStars;
        private List<Image> stars = new List<Image>();
        public StarRating()
        {
            this.InitializeComponent();
            DrawStars();
        }

        public int VisibleStars
        {
            get
            {
                return _visibleStars;
            }

            set
            {
                _visibleStars = value;
                OnPropertyChanged("VisibleStars");
            }
        }

        private void DrawStars()
        {
            for (int i = 0; i < 5; i++)
            {
                Image star = new Image();
                star.Source = new BitmapImage(new Uri("ms-appx://RecipeRate/Assets/star_gold_256.png", UriKind.RelativeOrAbsolute));
                star.SetValue(Grid.ColumnProperty, i);
                starGrid.Children.Add(star);
                
                stars.Add(star);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            for (int i = 0; i < VisibleStars; i++)
            {
                stars[i].Visibility = Visibility.Visible;

            }
            for (int i = VisibleStars; i < 5; i++)
            {
                stars[i].Visibility = Visibility.Collapsed;
            }
        }
    }
}
