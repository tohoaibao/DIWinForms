using DIWinForms.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIWinForms.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetAll();
    }
}
