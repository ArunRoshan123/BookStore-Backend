using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {/*
        public UserEntity UserRegisteration(RegisterModel model);*/
        public UserEntity UserRegisteration(RegisterModel model);
        public string UserLogin(LoginModel model);
        public string GenerateToken(string Email, int UserId);
        public ForgotPasswordModel ForgotPassword(string email);
        public bool CheckEmail(string userEmail);
        public bool ResetPassword(string Email, ResetPasswordModel model);
    }
}
