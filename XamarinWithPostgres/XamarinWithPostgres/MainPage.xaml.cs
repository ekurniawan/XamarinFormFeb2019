using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWithPostgres
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnAmbilGlobal_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("username")) {
                txtGlobal.Text = (string)Application.Current.Properties["username"];
            }
            else
            {
                DisplayAlert("Keterangan", "Data tidak ada", "OK");
            }
        }
    }
}
