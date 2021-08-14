namespace PremierAPI.Models.Interfaces
{
    public interface IUtilities
    {
        string GetDefaultUri();
        bool IsValidId(int? id);
    }
}
