using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    class ItemService
    {
        public static Item item;
        public List<Item> items_list;
        public async Task<List<Item>> ItemsList()
        {
            items_list = new List<Item>();
            string annid =  AnnonceService.annonce.id.ToString();
            var url = "https://socialapps.000webhostapp.com/api/items/" + annid;

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var message = await response.Content.ReadAsStringAsync();
            dynamic jsondata = JsonConvert.DeserializeObject(message);
            for (var i = 0; ; i++)
            {
                try
                {
                    var ann = new Item(jsondata[i]);
                    items_list.Add(ann);

                }
                catch (Exception e) { break; }
            }
            return items_list;
        }
    }
}
