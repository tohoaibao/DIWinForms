﻿using DIWinForms.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIWinForms.Services
{
    public interface IUserService
    {
        public List<UserDto> GetAll();

    }
}
