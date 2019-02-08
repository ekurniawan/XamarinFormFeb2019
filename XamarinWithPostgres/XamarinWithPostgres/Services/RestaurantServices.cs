using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinWithPostgres.Models;

namespace XamarinWithPostgres.Services
{
    public class RestaurantServices
    {
        private HttpClient _client;
        public RestaurantServices()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<Restaurant>> GetAllData()
        {
            List<Restaurant> listResto;
            var myUri = new Uri($"{Constants.RestURL}/api/Restaurant");
            try
            {
                var response = await _client.GetAsync(myUri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    listResto = 
                        JsonConvert.DeserializeObject<List<Restaurant>>(content);
                    return listResto;
                }
                else
                {
                    throw new Exception("Request Error !!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> InsertData(Restaurant resto)
        {
            var uri = new Uri($"{Constants.RestURL}/api/Restaurant");
            try
            {
                var json = JsonConvert.SerializeObject(resto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    return "Berhasil menambahkan data";
                }
                else
                {
                    throw new Exception("Gagal request ke server");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ditemukan kesalahan {ex.Message}");
            }
        }
    }
}
