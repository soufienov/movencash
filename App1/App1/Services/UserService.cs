using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Services
{
    class UserService
    {
        public static User user;

        public async Task<string> Register(string name,string lname,string email,string password) {
          var  url = "https://socialapps.000webhostapp.com/api/register";

            var client = new HttpClient();
            var user = new User {name=name,lname=lname,mid=email,email=email,password=password };
            var json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("applicatio/json");
            var response = await client.PostAsync(url, content);
            return response.ToString();
        }
        public async Task<string> Login(string email, string password)
        {
            var url = "https://socialapps.000webhostapp.com/api/login";

            var client = new HttpClient();
            var user = new User { email = email, password = password };
            var json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("applicatio/json");
            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                dynamic jsonuser = JsonConvert.DeserializeObject(message);

                try
                {
                    dynamic tmpuser = jsonuser.data;
                    Application.Current.Properties["user"] = tmpuser;
                    UserService.user = new User
                    {
                        name = (string)tmpuser.name,
                        lname = (string)tmpuser.lname,
                        email = (string)tmpuser.email,
                        mid = (string)tmpuser.mid
                    };
                }
                catch (Exception e) {//bad cred
                }
            }
            
             
           
            return "tt";
        }
    }
}
