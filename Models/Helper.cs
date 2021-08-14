using PremierAPI.Models.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PremierAPI.Models
{
    public class Helper : IHelper
    {
        private readonly IUtilities _utilities;
        public Helper(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public HttpClient Initial()
        {
            HttpClient client = new();
            client.BaseAddress = new Uri(_utilities.GetDefaultUri());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public string ReponseReaderAsString(HttpClient client, string uri)
        {
            var response = client.GetAsync(uri).Result;
            var myContent = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
                return myContent;
            return string.Empty;
        }

        public string ReponseDeleteAsString(HttpClient client, string uri)
        {
            var response = client.DeleteAsync(uri).Result;
            var myContent = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
                return myContent;
            return string.Empty;
        }

        public string ReponseCreateAsString(HttpClient client, string uri, string content)
        {
            var response = client.PostAsync(uri, JsonObjectManager(content)).Result;
            var myContent = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
                return myContent;
            return string.Empty;
        }

        public string ReponseUpdateAsString(HttpClient client, string uri, string content)
        {
            var response = client.PutAsync(uri, JsonObjectManager(content)).Result;
            var myContent = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
                return myContent;
            return string.Empty;
        }

        public StringContent JsonObjectManager(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
