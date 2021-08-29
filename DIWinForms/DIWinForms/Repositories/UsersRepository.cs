using DIWinForms.Context;
using DIWinForms.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIWinForms.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {

        public UsersRepository(AppDbContext db) : base(db)
        {
        }
    }
}
