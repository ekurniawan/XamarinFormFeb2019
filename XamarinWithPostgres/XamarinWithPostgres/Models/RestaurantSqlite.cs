using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinWithPostgres.Models
{
    public class RestaurantSqlite
    {
        [PrimaryKey]
        public int restaurantid { get; set; }
        public string namarestaurant { get; set; }
        [NotNull]
        public int categoryid { get; set; }
    }
}
