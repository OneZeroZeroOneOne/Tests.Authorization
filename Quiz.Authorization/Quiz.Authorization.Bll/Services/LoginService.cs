﻿using Microsoft.EntityFrameworkCore;
using Quiz.Authorization.Dal.Contexts;
using Quiz.Authorization.Dal.Models;
using Quiz.Authorization.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Authorization.Bll.Services
{
    public class LoginService
    {
        private MainContext _context;
        public LoginService(MainContext maincontext)
        {
            _context = maincontext;
        }

        public async Task<User> Authorization(string login, string password)
        {
            UserSecurity userSecurity = await _context.UserSecurity.Include(x => x.User).ThenInclude(x => x.Role).FirstOrDefaultAsync(x => x.Login == login);
            if (userSecurity == null || userSecurity.Login != login || userSecurity.Password != password)
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.InvalidCredentials, "invalid email or password");
            }
            return userSecurity.User;
        }
    }
}
