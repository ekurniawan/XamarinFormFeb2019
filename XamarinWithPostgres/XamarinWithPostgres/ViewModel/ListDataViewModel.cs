using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinWithPostgres.ViewModel
{
    public class ListDataViewModel : BindableObject
    {
        public ListDataViewModel()
        {
            listItems = new List<ListItem> {
                new ListItem
                {
                    Title = "Sate Klathak Pak Jeje",
                    Description = "Sate Klathak Pak Jeje Pasar Jejeran",
                    Picture = "satu.jpg",
                    Price = 20000
                },
                new ListItem {
                    Title = "Soto Kadipiro",
                    Description="Soto Kadipiro jalan Wates",
                    Picture = "dua.jpg",
                    Price = 15000
                },
                new ListItem{
                    Title="Bakmi Jawa Mbah Hadi",
                    Description="Bakmi Jawa Mbah Hadi terban",
                    Picture = "tiga.jpg",
                    Price = 22000
                }
            };
        }

        private List<ListItem> listItems;
        public List<ListItem> ListItems
        {
            get { return listItems; }
            set { listItems = value; OnPropertyChanged("ListItems"); }
        }

    }
}
