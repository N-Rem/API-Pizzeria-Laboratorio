using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class UserProductDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    public static UserProductDto Create(UserProduct up)
    {
            var dto = new UserProductDto();

        dto.Id = up.Id;
        dto.UserId = up.UserId;
        dto.ProductId = up.ProductId;
        dto.Product = up.Product;
        dto.Quantity = up.Quantity;

        return dto;
    }


    
    public static List<UserProductDto> CreateList(IEnumerable<UserProduct> up)
    {
        var listDto = new List<UserProductDto>();
        foreach (var u in up)
        {
            listDto.Add(Create(u));
        }
            return listDto;
    }

    }

}
