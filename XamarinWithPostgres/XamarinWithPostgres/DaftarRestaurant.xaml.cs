﻿using System;
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
            //myIndicator.IsRunning = true;

            listRestaurant.ItemsSource = await restoService.GetAllData();

            //myIndicator.IsRunning = false;
            //myIndicator.IsVisible = false;
        }

        private async void ListRestaurant_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var editData = (Restaurant)e.Item;
            var editPage = new EditRestoPage();
            editPage.BindingContext = editData;
            await Navigation.PushAsync(editPage);
        }

        private void ListRestaurant_Refreshing(object sender, EventArgs e)
        {
            OnAppearing();
            listRestaurant.IsRefreshing = false;
        }

        private async void MenuTambahResto_Clicked(object sender, EventArgs e)
        {
            var pageTambah = new AddRestaurantPage();
            await Navigation.PushAsync(pageTambah);
        }
    }
}