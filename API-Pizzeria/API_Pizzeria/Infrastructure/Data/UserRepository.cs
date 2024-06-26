using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Product>? GetAllProductUser(int idUser)
        {
            var products = _context.Users
                .Include(u => u.UserProducts)
                .ThenInclude(up => up.Product)
                .Where(u => u.Id == idUser)
                .SelectMany(u => u.UserProducts.Select(up => up.Product))
                .ToList();
            //SelectMany toma la colección de colecciones de productos y las mete en una colección de productos.
            if (products == null || products.Count == 0)
            {
                 throw new Exception("No se encontro reservas del usuario");
            }
            return products;
        }

        public User GetByName(string name, string pass)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == name && u.Password == pass)
                ?? throw new Exception("No Se encontro el usuario");
            return user;
        }

    }
}
