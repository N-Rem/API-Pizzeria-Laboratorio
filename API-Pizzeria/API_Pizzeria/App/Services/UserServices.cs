using App.Models;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<UserDto> GetAll()
        {
            return UserDto.CreateList(_userRepository.GetAll());
        }
        public UserDto? GetById(int id)
        {
            var obj = UserDto.Create(_userRepository.GetById(id))
                ?? throw new Exception("No se encontro el producto");
            return obj;
        }

        public void UpdateProduct(int idUser, UserDto userDto)
        {
            var obj = _userRepository.GetById(idUser)
                ?? throw new Exception("no se encontro el producto");
            
            _userRepository.Update(obj);
        }
        public void DeleteProduct(int idUser)
        {
            var obj = _userRepository.GetById(idUser)
                ?? throw new Exception("no se encontro el producto");
            _userRepository.Delete(obj);
        }

        public void CreateProduct(ProductDto productDto)
        {
            var product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                ImageUrl = productDto.ImageUrl,

            };
            _productRepository.Add(product);
        }

    }
}
