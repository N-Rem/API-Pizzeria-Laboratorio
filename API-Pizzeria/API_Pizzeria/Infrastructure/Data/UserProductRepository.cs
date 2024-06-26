using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UserProductRepository: BaseRepository<UserProduct>
    {

        private readonly AppDbContext _context;
        public UserProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
