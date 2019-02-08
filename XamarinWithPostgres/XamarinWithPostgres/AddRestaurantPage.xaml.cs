using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWithPostgres.Models;
using XamarinWithPostgres.Services;

namespace XamarinWithPostgres
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRestaurantPage : ContentPage
    {
        private RestaurantServices myService;
        public AddRestaurantPage()
        {
            InitializeComponent();
            myService = new RestaurantServices();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newData = new Restaurant
                {
                    categoryid = Convert.ToInt32(txtKategoriID.Text),
                    namarestaurant = txtNamaRestaurant.Text
                };
                await myService.InsertData(newData);
                await DisplayAlert("Keterangan",
                    $"Data Restaurant {txtNamaRestaurant.Text} berhasil ditambahkan", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"Ditemukan kesalahan {ex.Message}", "OK");
            }
        }
    }
}