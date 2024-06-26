﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserRepository: IBaseRepository<User>
    {
        ICollection<UserProduct>? GetAllProductUser(int idUser);
        User GetByName(string name);
        User GetByNamePass(string name, string pass);
    }
}
