using DIWinForms.Dto;
using DIWinForms.Mappings;
using DIWinForms.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIWinForms.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<UserDto> GetAll()
        {
            var users = _usersRepository.GetAll();
            return users.ToDto().ToList();
        }
    }
}
