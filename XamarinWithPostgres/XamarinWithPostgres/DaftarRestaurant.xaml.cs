using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWithPostgres.Services;

namespace XamarinWithPostgres
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DaftarRestaurant : ContentPage
    {
        private RestaurantServices restoService;
        public DaftarRestaurant()
        {
            InitializeComponent();
            restoService = new RestaurantServices();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            myIndicator.IsRunning = true;

            listRestaurant.ItemsSource = await restoService.GetAllData();

            myIndicator.IsRunning = false;
            myIndicator.IsVisible = false;
        }
    }
}