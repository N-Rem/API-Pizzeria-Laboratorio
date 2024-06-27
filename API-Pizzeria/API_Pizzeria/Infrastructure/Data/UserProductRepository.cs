using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserProductRepository: BaseRepository<UserProduct>, IUserProductRepository
    {

        private readonly AppDbContext _context;
        public UserProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<UserProduct> GetPizzasUser(int id)
        {
            var listPizzaUser = _context.UserProducts.Include(up => up.Product).Where(up => up.UserId == id).ToList();
            return listPizzaUser;
        }
    }
}
