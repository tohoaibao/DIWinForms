using DIWinForms.Dto;
using DIWinForms.Entity;
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
            var users = _usersRepository.GetAll().ToList();
            return users.ToDto().ToList();
        }

        public void CreateOrUpdate(UserDto user)
        {
            if (user.Id == 0)
            {
                AddUser(user);
            }
            else
            {
                UpdateUser(user);
            }
        }

        private void UpdateUser(UserDto user)
        {
            var entity = _usersRepository.FindByCondition(x => x.Id == user.Id).FirstOrDefault();
            entity.Name = user.Name;
            entity.Phone = user.Phone;
            _usersRepository.Update(entity);
            _usersRepository.Save();
        }

        private void AddUser(UserDto user)
        {
            var entity = new User
            {
                Name = user.Name,
                Phone = user.Phone
            };
            _usersRepository.Add(entity);
            _usersRepository.Save();
        }

        public void Delete(int Id)
        {
            var user = _usersRepository.FindByCondition(x => x.Id == Id).FirstOrDefault();
            _usersRepository.Delete(user);
            _usersRepository.Save();
        }
    }
}
