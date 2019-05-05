using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MOBRJ_XamarinForms.Services
{
    public class ApiService
    {
        public async Task<T> Get<T>(string urlBase, string servicePrefix)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}", servicePrefix);
                var response = await client.GetAsync(url);


                if (!response.IsSuccessStatusCode)
                {
                }
                var result = await response.Content.ReadAsStringAsync();


                var Records = JsonConvert.DeserializeObject<T>(result);

                return Records;
            }

            catch (Exception ex)
            {
                var Records = JsonConvert.DeserializeObject<T>("");
                return Records;
            }
        }
    }
}
