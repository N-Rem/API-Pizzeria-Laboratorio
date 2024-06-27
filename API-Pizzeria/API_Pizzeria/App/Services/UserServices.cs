﻿using App.Models;
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
            //var listUserDto = UserDto.CreateList(listUser);
            var listUserDto = new List<UserDto>();
            foreach (var u in listUser) 
            {
                var listUserProduct = _userProductRepository.GetPizzasUser(u.Id);
                var listaUPDto = UserProductDto.CreateList(listUserProduct);
                var newUserDto = UserDto.Create(u);
                newUserDto.UserProducts = listaUPDto;
                listUserDto.Add(newUserDto);

            }
            
            return listUserDto;
        }
        public UserDto? GetById(int id)
        {
            var obj = _userRepository.GetById(id);
            var listUserProducts = _userProductRepository.GetPizzasUser(id)
                ?? throw new Exception("No se encontro el producto");
            var lita = UserProductDto.CreateList(listUserProducts);
            //var listProductDto = new List<ProductDto>();
            
            var objDto = UserDto.Create(obj);
            objDto.UserProducts = lita;
            return objDto;
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
            var existingUser = _userRepository.GetByName(userDto.UserName);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
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
            var existingUser = _userRepository.GetByName(userDto.UserName);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
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

        /*public ICollection<UserProductDto> GetAllReservationPizzaOfUser(int idUser)
        {
            var listPizzaUser = _userProductRepository.GetPizzasUser(idUser);
            var listapizza= new List<Product>();
            foreach (var lp in listPizzaUser)
            {
                var pizza = _productRepository.GetById(lp.ProductId);
                listapizza.Add(pizza);
            }

            return UserProductDto.CreateList(listPizzaUser);

            //Devolver todas las reservaciones de pizza de un usuario
        }*/
        public ICollection<UserProductDto> GetAllReservationPizzaOfUser(int idUser)
        {
            // Obtener todas las reservas de pizza de un usuario
            var listPizzaUser = _userProductRepository.GetPizzasUser(idUser);

            // Crear una lista de UserProductDto
            var listUserProductDto = new List<UserProductDto>();

            foreach (var userProduct in listPizzaUser)
            {
                // Buscar el producto por su id
                var product = _productRepository.GetById(userProduct.ProductId);

                // Crear el dto y asignar el producto completo
                var userProductDto = new UserProductDto
                {
                    Id = userProduct.Id,
                    UserId = userProduct.UserId,
                    ProductId = userProduct.ProductId,
                    Product = product,
                    Quantity = userProduct.Quantity
                };

                // Añadir el dto a la lista
                listUserProductDto.Add(userProductDto);
            }

            return listUserProductDto;
        }


        public void DeleteUnaPizza(int idReservacion)
        {
            var pizzaToDelete = _userProductRepository.GetById(idReservacion)
            ?? throw new Exception("no se enconro la reservacion de esa pizza");
            _userProductRepository.Delete(pizzaToDelete);
        }
        public UserDto? Login(UserRequestUpdate userRequest)
        {
            var username = userRequest.UserName;
            var pass = userRequest.Password;
            var user = UserDto.Create(_userRepository.GetByNamePass(username, pass));

            return user;
        }

    }
}
