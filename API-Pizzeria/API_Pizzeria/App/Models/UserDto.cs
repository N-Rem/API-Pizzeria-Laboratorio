using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.User;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace App.Models
{
    public class UserDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRol Rol { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();

        public static UserDto Create(User user)
        {
            var dto = new UserDto();

            dto.Id = user.Id;
            dto.UserName = user.UserName;
            dto.Password = user.Password;
            dto.Rol = user.Rol;
            

            return dto;
        }

        public static List<UserDto> CreateList(IEnumerable<User> user)
        {
            var listDto = new List<UserDto>();
            foreach (var u in user)
            {
                listDto.Add(Create(u));
            }
            return listDto;
        }
    }
}
