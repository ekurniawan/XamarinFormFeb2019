using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWithPostgres.DAL;
using XamarinWithPostgres.Models;
using XamarinWithPostgres.Services;

namespace XamarinWithPostgres
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListSqLitePage : ContentPage
    {
        private DataAccess myDataAccess;
        private RestaurantServices myRestoService;
        public ListSqLitePage()
        {
            InitializeComponent();
            myDataAccess = new DataAccess();
            myRestoService = new RestaurantServices();
        }

        private async void BtnIsiData_Clicked(object sender, EventArgs e)
        {
            try
            {
                var dataMaster = await myRestoService.GetAllData(); 
                foreach(var data in dataMaster)
                {
                    var newData = new RestaurantSqlite()
                    {
                        categoryid = data.categoryid,
                        namarestaurant = data.namarestaurant,
                        restaurantid = data.restaurantid
                    };
                    myDataAccess.InsertData(newData);
                }
                await DisplayAlert("Keterangan", "Berhasil menambah data pada Sqlite","OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", $"Kesalahan {ex.Message}", "OK");
            }
        }

        protected override void OnAppearing()
        {
            //ambil dari lokal
            base.OnAppearing();
            listData.ItemsSource = myDataAccess.GetAll();
        }

        private void ListData_Refreshing(object sender, EventArgs e)
        {
            OnAppearing();
            listData.IsRefreshing = false;
        }

        private async void BtnDeleteAll_Clicked(object sender, EventArgs e)
        {
            try
            {
                myDataAccess.DeleteAll();
                await DisplayAlert("Keterangan", "Semua data berhasil didelete", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            }
        }
    }
}