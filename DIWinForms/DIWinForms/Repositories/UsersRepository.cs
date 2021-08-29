using DIWinForms.Context;
using DIWinForms.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIWinForms.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _db;

        public UsersRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<User> GetAll()
        {
            return _db.Users
                .AsNoTracking()
                .ToList();
        }
    }
}
