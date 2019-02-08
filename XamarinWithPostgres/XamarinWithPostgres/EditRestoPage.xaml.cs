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
	public partial class EditRestoPage : ContentPage
	{
        private RestaurantServices myService;
		public EditRestoPage ()
		{
			InitializeComponent ();
            myService = new RestaurantServices();
		}

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var editData = new Restaurant
                {
                    categoryid = Convert.ToInt32(txtCategoryID.Text),
                    restaurantid = Convert.ToInt32(txtRestaurantID.Text),
                    namarestaurant = txtNamaRestaurant.Text
                };
                await myService.UpdateData(editData);
                await DisplayAlert("Keterangan", $"Data dengan id {txtRestaurantID.Text} berhasil diupdate",
                    "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"Kesalahan: {ex.Message}", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var konfirmasi = await DisplayAlert("Konfirmasi", "Apakah anda yakin delete data?", 
                "OK", "Cancel");
            try
            {
                if (konfirmasi)
                {
                    await myService.DeleteData(Convert.ToInt32(txtRestaurantID.Text));
                    await DisplayAlert("Keterangan", "Data berhasil didelete", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"Error:{ex.Message}", "OK");
            }
        }
    }
}