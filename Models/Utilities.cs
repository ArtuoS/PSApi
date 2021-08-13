using PremierAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierAPI.Models
{
    public class Utilities : IUtilities
    {
        public string GetDefaultUri()
            => @"https://60d27cb2858b410017b2dd51.mockapi.io/ps/";

        public bool IsIdValid(int? id)
            => id > 0 && id != null;
    }
}
