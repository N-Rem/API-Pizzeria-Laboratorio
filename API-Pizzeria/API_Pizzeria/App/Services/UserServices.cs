using App.Models;
using App.Models.Rrequest;
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
        private readonly IUserProductRepository _userProductRepository;
        private readonly IProductRepository _productRepository;
        public UserServices(IUserRepository userRepository, IUserProductRepository userProductRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _userProductRepository = userProductRepository;
            _productRepository = productRepository;
        }

        public ICollection<UserDto> GetAll()
        {
            var listUser = _userRepository.GetAll()
                ?? throw new Exception("no existen usuarios");
            var listUserDto = UserDto.CreateList(listUser);

            foreach (var u in listUserDto) 
            {
                var listUserProduct = _userRepository.GetAllProductUser(u.Id);
                var listProductDto = new List<ProductDto>();
                foreach(var up in listUserProduct)
                {
                    for(int i = 0;i < up.Quantity; i++)
                    {
                        listProductDto.Add(ProductDto.Create(up.Product));
                    }
                }
            }
            return listUserDto;
        }
        public UserDto? GetById(int id)
        {
            var obj = UserDto.Create(_userRepository.GetById(id))
                ?? throw new Exception("No se encontro el producto");

            var listaUserProduct = _userRepository.GetAllProductUser(id);
            var listProductDto = new List<ProductDto>();
            foreach (var up in listaUserProduct)
            {
                for (int i = 0; i < up.Quantity; i++)
                {
                    listProductDto.Add(ProductDto.Create(up.Product));
                }
            }
            obj.Products = listProductDto;
             
            return obj;
        }

        public void UpdateUser(int idUser, UserRequestUpdate userDto)
        {
            var obj = _userRepository.GetById(idUser)
                ?? throw new Exception("no se encontro el producto");
            
            _userRepository.Update(obj);
        }
        public void DeleteUser(int idUser)
        {
            var obj = _userRepository.GetById(idUser)
                ?? throw new Exception("no se encontro el producto");
            _userRepository.Delete(obj);
        }

        public void CreateUserAdmin(UserDto userDto)
        {
            var user = new User()
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                Rol=User.UserRol.Admin,
                
            };
            _userRepository.Add(user);
        }
        public void CreateUserClient(UserDto userDto)
        {
            var user = new User()
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                Rol = User.UserRol.Client,

            };
            _userRepository.Add(user);
        }

        public void AddToBuy(UserProductCreateRequest dto)
        {
            var user = _userRepository.GetById(dto.UserId)
                ?? throw new Exception("No se encontro el useuario");
            var product = _productRepository.GetById(dto.ProductId)
                ?? throw new Exception("No se encontro el producto");
            var newUserProduct = new UserProduct()
            {
                Product = product,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                User = user,
                UserId = dto.UserId,
            };
            _userProductRepository.Add(newUserProduct);

        }

        //---------------------
        public void BuyReservation(int id)
        {
            var obj = UserDto.Create(_userRepository.GetById(id))
              ?? throw new Exception("No se encontro el producto");

            var listaUserProduct = _userRepository.GetAllProductUser(id);
            
            foreach (var up in listaUserProduct)
            {
                up.Product.Stock -= up.Quantity;
                _userProductRepository.Update(up);
                _userProductRepository.Delete(up);
            }
        }
    }
}
