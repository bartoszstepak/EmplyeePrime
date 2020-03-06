using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_2.Models;

namespace crud_2.Services
{
    public interface ILoginBLL
    {
        bool isValidUser(Login user);
        Task<bool> createUserCredentialsAsyns(Login login);
        Task<bool> updateUserCredentialsAsyns(Login newLogin, string login);
        Task<bool> removeUserCredentials(string login);
        //Login getUserCredetialsByEmail(string login);




    }
}
