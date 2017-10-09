using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace App1.Services
{
    class AnnonceService
    {
        public static Annonce annonce;
        public List<Annonce> annonces_list;
        public async Task<List<Annonce>> AnnoncesList()
        {
            annonces_list = new List<Annonce>();
            string mid = UserService.user.mid;
            var url = "https://socialapps.000webhostapp.com/api/annonces/"+mid;

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var message = await response.Content.ReadAsStringAsync();
            dynamic  jsondata = JsonConvert.DeserializeObject(message);
            for (var i = 0; ; i++) {
                try
                {
                    var ann = new Annonce( jsondata[i]);
                    annonces_list.Add(ann);

                }
                catch (Exception e) { break; }
            }
            return annonces_list;
        }
    }
}
