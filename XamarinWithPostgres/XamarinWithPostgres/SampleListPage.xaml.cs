using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWithPostgres.ViewModel;

namespace XamarinWithPostgres
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleListPage : ContentPage
    {
        public SampleListPage()
        {
            InitializeComponent();
            BindingContext = new ListDataViewModel();
        }

        private void LstData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListItem myItem = (ListItem)e.Item;
            //DisplayAlert("Keterangan", $"Anda memilih item dengan judul {myItem.Title}", "OK");
            DetailPage detailPage = new DetailPage();
            detailPage.BindingContext = myItem;
            Navigation.PushAsync(detailPage);
        }

        private void MenuResto_Clicked(object sender, EventArgs e)
        {
            var restaurantPage = new DaftarRestaurant();
            Navigation.PushAsync(restaurantPage);
        }

        private void MenuAdd_Clicked(object sender, EventArgs e)
        {
            AddRestaurantPage addRestoPage = new AddRestaurantPage();
            Navigation.PushAsync(addRestoPage);
        }
    }
}