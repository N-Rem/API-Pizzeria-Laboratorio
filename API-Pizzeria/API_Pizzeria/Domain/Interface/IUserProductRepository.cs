using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserProductRepository : IBaseRepository<UserProduct>
    {
        ICollection<UserProduct> GetPizzasUser(int id);
    }
}
