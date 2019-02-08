using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinWithPostgres.Models
{
    public class Restaurant
    {
        public int restaurantid { get; set; }
        public string namarestaurant { get; set; }
        public int categoryid { get; set; }
    }
}
