using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserRol rol {  get; set; }

        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();

        public enum UserRol
        {
            Client,
            Admin,
            SuperAdmin,
        }


    }
}
