namespace PremierAPI.Models.Interfaces
{
    interface IUser
    {
        void UpdatePropertiesByNewUser(User userWithNewProperties);
        void SetId(string id);
    }
}
