using PremierAPI.Models.Interfaces;
using System;

namespace PremierAPI.Models
{
    public class Utilities : IUtilities
    {
        public string GetDefaultUri()
            => @"https://60d27cb2858b410017b2dd51.mockapi.io/ps/";

        public bool IsValidId(int? id)
            => id > 0 && id != null;

        public bool IsValidDate(DateTime date)
            => date != null;
    }
}
