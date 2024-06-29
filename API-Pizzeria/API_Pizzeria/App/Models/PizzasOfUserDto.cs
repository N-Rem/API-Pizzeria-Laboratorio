using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class PizzasOfUserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public static PizzasOfUserDto CreatePizzaOfUserDto(UserProduct reserva)
        {
            var newPizzaOfUser = new PizzasOfUserDto();
            newPizzaOfUser.Id = reserva.Product.Id;
            newPizzaOfUser.Name = reserva.Product.Name;
            newPizzaOfUser.Description = reserva.Product.Description;
            newPizzaOfUser.Price = reserva.Product.Price;
            newPizzaOfUser.Stock = reserva.Product.Stock;
            newPizzaOfUser.ImageUrl = reserva.Product.ImageUrl;
            newPizzaOfUser.Quantity = reserva.Quantity;
            return newPizzaOfUser;
        }

    }
}
