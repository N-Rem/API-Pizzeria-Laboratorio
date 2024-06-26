using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class ProductDto
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string ImageUrl { get; set; }


        public static ProductDto Create(Product product)
        {
            var dto = new ProductDto();
            dto.Id = product.Id;
            dto.Name = product.Name;
            dto.Description = product.Description;
            dto.Price = product.Price;
            dto.Stock = product.Stock;
            dto.ImageUrl = product.ImageUrl;

            return dto;
        }

        public static List<ProductDto> CreateList(ICollection<Product> products)
        {
            List<ProductDto> listDto = [];
            foreach (var p in products)
            {
                listDto.Add(Create(p));
            }
            return listDto;
        }

    }
}
