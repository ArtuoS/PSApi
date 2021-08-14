using System.Net;
using System.Net.Http;

namespace PremierAPI.Models.Interfaces
{
    public interface IHelper
    {
        HttpClient Initial();
        string ReponseReaderAsString(HttpClient client, string uri);
        string ReponseDeleteAsString(HttpClient client, string uri);
        string ReponseCreateAsString(HttpClient client, string uri, string content);
        string ReponseUpdateAsString(HttpClient client, string uri, string content);
        StringContent JsonObjectManager(string json);
    }
}
