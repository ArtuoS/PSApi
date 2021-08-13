using PremierAPI.Models.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

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
    }
}
