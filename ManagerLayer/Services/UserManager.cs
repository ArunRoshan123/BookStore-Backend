using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository repository;
        /*public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }*/
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public UserEntity UserRegisteration(RegisterModel model)
        {
            return repository.UserRegisteration(model);
        }
        public string UserLogin(LoginModel model)
        {
            return repository.UserLogin(model);
        }
        public string GenerateToken(string Email, int UserId)
        {
            return repository.GenerateToken(Email, UserId);
        }
        public ForgotPasswordModel ForgotPassword(string email)
        {
            return repository.ForgotPassword(email);
        }
        public bool CheckEmail(string userEmail)
        {
            return repository.CheckEmail(userEmail);
        }
        public bool ResetPassword(string Email, ResetPasswordModel model)
        {
            return repository.ResetPassword(Email, model);
        }
    }
}
