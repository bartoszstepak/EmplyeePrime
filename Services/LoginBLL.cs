using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using crud_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace crud_2.Services
{
    public class LoginBLL : ILoginBLL
    {

        private EmployeeContext _context;
        private IMapper _mapper;

        public LoginBLL(EmployeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool isValidUser(Login user)
        {
            try
            {
                var DbUser = _context.Logins.First(e => e.login == user.login);
                if (DbUser == null)
                {
                    return false;
                }
                return DbUser.password == user.password;
            }
            catch
            {
                return false;
            }
                      
        }

        public async Task<bool> createUserCredentialsAsyns(Login login)
        {
                _context.Logins.Add(login);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
                return true;
        }

        public async Task<bool> updateUserCredentialsAsyns(Login newLogin, string login)
        {
            var userCred = _context.Logins.First(e => e.login == login);

            if(userCred != null)
            {
                if (newLogin.password != null)
                {
                    userCred.password = newLogin.password;

                }

                if (newLogin.login != null)
                {
                    userCred.login = newLogin.login;

                }

            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> removeUserCredentials(string login)
        {
            var user = _context.Logins.First(e => e.login == login);
            if (user == null)
            {
                return false;
            }
            _context.Logins.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool Ok(object p)
        {
            throw new NotImplementedException();
        }
    }
}
