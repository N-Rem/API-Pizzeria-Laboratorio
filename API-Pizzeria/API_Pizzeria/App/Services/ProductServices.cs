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
    public class ProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<ProductDto> GetAll()
        {
            return ProductDto.CreateList(_productRepository.GetAll());
        }
        public ProductDto? GetById(int id)
        {
            var objEntity = _productRepository.GetById(id)
                ?? throw new Exception("No se encontro el producto");
            var obj = ProductDto.Create(objEntity);
            return obj;
        }

        public void UpdateProduct (int idProduct, ProductDto productDto)
        {
            var obj = _productRepository.GetById(idProduct)
                ?? throw new Exception("no se encontro el producto");
            obj.Name = productDto.Name;
            obj.Description = productDto.Description;
            obj.Price = productDto.Price;
            obj.Stock = productDto.Stock;
            obj.Price = productDto.Price;
            obj.ImageUrl = productDto.ImageUrl;
            _productRepository.Update(obj);
        }
        public void DeleteProduct (int idProduct)
        {
            var obj = _productRepository.GetById(idProduct)
                ?? throw new Exception("no se encontro el producto");
            _productRepository.Delete(obj);
        }

        public void CreateProduct (ProductDto productDto)
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
