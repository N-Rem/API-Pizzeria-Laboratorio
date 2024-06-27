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

        public ICollection<UserProduct>? GetAllProductUser(int idUser)
        {
            //se cambia la manerea de traer la lista de todas las reservaciones del usuario. 
            var productos = _context.UserProducts.Include(up => up.Product).Where(up => up.UserId == idUser).ToList()
                 ?? throw new Exception("No se encontro productos del usuario");
            return productos;
        }

        public User GetByNamePass(string name, string pass)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == name && u.Password == pass)
                ?? throw new Exception("No Se encontro el usuario");
            return user;
        }
        public User GetByName(string name)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == name);
            return user;
        }

    }
}
