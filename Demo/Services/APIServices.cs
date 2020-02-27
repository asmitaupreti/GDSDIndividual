using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Demo.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using Demo.Views;

namespace Demo.Services
{
    public class APIServices
    {
        public static async Task<Profile> GetProfileData(string uri, int Id)
        {
            var client = new HttpClient();

            var responseModel = new Profile();

            var model = new ClassId
            {
                id = Id

            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<Profile>(content);
                

                /* Console.WriteLine(Application.Current.Properties["id"]);*/

               
            }

            return responseModel;

        }

        public static async Task<ObservableCollection<Items>> GetProductData(string uri)
        {

            HttpClient _httpClient = null;
            ObservableCollection<Items> productData = null;

            try
            {
                _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync(uri);
                Console.WriteLine("\tERROR {0}");

                HttpResponseMessage res = await _httpClient.GetAsync(uri);


                if (res.IsSuccessStatusCode)

                {
                    string content = await res.Content.ReadAsStringAsync();

                    //wikiData = JsonConvert.DeserializeObject<WikiData>(content);

                    productData = JsonConvert.DeserializeObject<ObservableCollection<Items>>(content);
                }

            }

            catch (Exception ex)

            {
                Console.WriteLine("\tERROR {0}", ex.Message);

            }

            return productData;


        }

        public static async Task<ObservableCollection<Items>> GetProductNumber(string uri)
        {

            HttpClient _httpClient = null;
            ObservableCollection<Items> productData = null;

            try
            {
                _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync(uri);
                Console.WriteLine("\tERROR {0}");

                HttpResponseMessage res = await _httpClient.GetAsync(uri);



                if (res.IsSuccessStatusCode)

                {
                    string content = await res.Content.ReadAsStringAsync();

                    //wikiData = JsonConvert.DeserializeObject<WikiData>(content);

                    productData = JsonConvert.DeserializeObject<ObservableCollection<Items>>(content);
                }

            }

            catch (Exception ex)

            {
                Console.WriteLine("\tERROR {0}", ex.Message);

            }

            return productData;


        }



        public static async Task<ObservableCollection<UserModel>> GetUserData(string uri)
        {

            HttpClient _httpClient = null;
            ObservableCollection<UserModel> productData = null;

            try
            {
                _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync(uri);
                Console.WriteLine("\tERROR {0}");

                HttpResponseMessage res = await _httpClient.GetAsync(uri);


                if (res.IsSuccessStatusCode)

                {
                    string content = await res.Content.ReadAsStringAsync();

                    //wikiData = JsonConvert.DeserializeObject<WikiData>(content);

                    productData = JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(content);

                }

            }

            catch (Exception ex)

            {
                Console.WriteLine("\tERROR {0}", ex.Message);

            }

            return productData;


        }


        public static async Task<bool> LoginUser(
                string email, string password, string uri)
        {
            var client = new HttpClient();

            var responseModel = new loginModel();

            var model = new loginModel
            {
                Email = email,
                Password = password,

            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                if (content == "[]\n")
                { 
                   var res = await Application.Current.MainPage.DisplayAlert("Error", "Incorect username or password", "Ok","Cancel");
                    if (res)
                    {
                        return false;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    Console.WriteLine(content);
                    responseModel = JsonConvert.DeserializeObject<loginModel>(content);
                    Preferences.Set("id", responseModel.Id);
                    Application.Current.Properties["id"] = responseModel.Id;
                    Application.Current.Properties["name"] = responseModel.Email;
                    Application.Current.Properties["password"] = responseModel.Password;
                }
                /* Console.WriteLine(Application.Current.Properties["id"]);*/

                return true;
            }

            return false;
        }

        public static async Task<ObservableCollection<BarChartModel>> GetBarChartData(string uri)
        {

            HttpClient _httpClient = null;
            ObservableCollection<BarChartModel> productData = null;

            try
            {
                _httpClient = new HttpClient();
                var response = await _httpClient.GetAsync(uri);
                Console.WriteLine("\tERROR {0}");

                HttpResponseMessage res = await _httpClient.GetAsync(uri);


                if (res.IsSuccessStatusCode)

                {
                    string content = await res.Content.ReadAsStringAsync();

                    Console.WriteLine(content);

                    //wikiData = JsonConvert.DeserializeObject<WikiData>(content);

                    productData = JsonConvert.DeserializeObject<ObservableCollection<BarChartModel>>(content);
                }

            }

            catch (Exception ex)

            {
                Console.WriteLine("\tERROR {0}", ex.Message);
                Debug.WriteLine("\tERROR {0}", ex.Message);

            }

            return productData;


        }


        public static async Task<bool> UpdateStatus(
                StatusUpdateModel s, string uri)
        {
            var client = new HttpClient();

            var responseModel = new loginModel();

            /*var model = new StatusUpdateModel
            {
                Id = id,
                Status = status

            };*/

            var json = JsonConvert.SerializeObject(s);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                /*string content = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<loginModel>(content);
                Application.Current.Properties["id"] = responseModel.Id;
                Application.Current.Properties["name"] = responseModel.Email;
                Application.Current.Properties["password"] = responseModel.Password;*/

                /* Console.WriteLine(Application.Current.Properties["id"]);*/

                return true;
            }

            return false;
        }


        public static async Task<ObservableCollection<AdminMessage>> GetMessageData(string uri, int Id)
        {
            var client = new HttpClient();

            ObservableCollection<AdminMessage> responseModel = null;
 
            var model = new ClassId
            {
                id = Id

            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                responseModel = JsonConvert.DeserializeObject<ObservableCollection<AdminMessage>>(content);

                Console.WriteLine(responseModel);
                 Console.WriteLine(Application.Current.Properties["id"]);


            }

            return responseModel;

        }

        public static async Task<ObservableCollection<Message>> GetSpecificMessageData(string uri, int senderId, int receiverId,int productId)
        {
            var client = new HttpClient();

            ObservableCollection<Message> responseModel = null;

            var model = new ReceiveMessage
            {
                senderId = senderId,
                productId = productId,
                receiverId = receiverId
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<ObservableCollection<Message>>(content);


                /* Console.WriteLine(Application.Current.Properties["id"]);*/


            }

            return responseModel;

        }

        public static async Task<bool> UpdateUser(
               int id ,string email, string password, string uri)
        {
            var client = new HttpClient();

            var responseModel = new loginModel();

            var model = new loginModel
            {
                Id = id,
                Email = email,
                Password = password,

            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                if (content == "[]\n")
                {
                    var res = await Application.Current.MainPage.DisplayAlert("Error", "Try again", "Ok", "Cancel");
                    if (res)
                    {
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine(content);
                    
                }
                /* Console.WriteLine(Application.Current.Properties["id"]);*/

                return true;
            }

            return false;
        }



    }
}

