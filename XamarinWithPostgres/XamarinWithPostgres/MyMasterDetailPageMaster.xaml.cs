using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinWithPostgres
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MyMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MyMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyMasterDetailPageMenuItem> MenuItems { get; set; }
            
            public MyMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyMasterDetailPageMenuItem>(new[]
                {
                    new MyMasterDetailPageMenuItem { Id = 0, Title = "Daftar Restaurant",TargetType=typeof(DaftarRestaurant) },
                    new MyMasterDetailPageMenuItem { Id = 1, Title = "Contoh Tabbed",TargetType=typeof(MyTabbedPage) },
                    new MyMasterDetailPageMenuItem { Id = 2, Title = "Tambah Restaurant",TargetType=typeof(AddRestaurantPage) },
                    new MyMasterDetailPageMenuItem { Id = 3, Title = "Tambah Kategori" },
                    new MyMasterDetailPageMenuItem { Id = 4, Title = "Sample SQLite",TargetType=typeof(ListSqLitePage) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}