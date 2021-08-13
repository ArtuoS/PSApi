using System.Net.Http;

namespace PremierAPI.Models.Interfaces
{
    public interface IHelper
    {
        HttpClient Initial();
    }
}
