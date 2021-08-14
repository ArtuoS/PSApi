using PremierAPI.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace PremierAPI.Models
{
    public class User : IUser
    {
        [Key]
        public string id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime criadoEm { get; set; }

        [Required]
        [MaxLength(150)]
        public string nome { get; set; }

        public void SetId(string id)
            => this.id = id;

        public void UpdatePropertiesByNewUser(User userWithNewProperties)
        {
            if (!string.IsNullOrEmpty(userWithNewProperties.nome) && userWithNewProperties.nome != nome)
                nome = userWithNewProperties.nome;
        }
    }
}
