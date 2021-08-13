using PremierAPI.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace PremierAPI.Models
{
    public class User : IUser
    {
        [Key]
        public string Id { get; set; }

        public DateTime CriadoEm { get; set; }

        public string Nome { get; set; }
    }
}
