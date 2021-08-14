using PremierAPI.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierAPI.Models
{
    public class User : IUser
    {
        public User() { }

        public User(string nome, DateTime criadoEm)
        {
            Nome = nome;
            CriadoEm = criadoEm;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CriadoEm { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }
    }
}
