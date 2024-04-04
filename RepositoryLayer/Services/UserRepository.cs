using CommonLayer.RequestModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext context;
        Encryption encryption = new Encryption();
        private readonly IConfiguration config;

        public UserRepository(BookStoreContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public UserEntity UserRegisteration(RegisterModel model)
        {
            UserEntity entity = new UserEntity();
            entity.Fname = model.Fname;
            entity.Lname = model.Lname;
            entity.Email = model.Email;
            entity.Password = encryption.GenerateHashedPassword(model.Password);
            entity.PhNumber = model.PhNumber;

            UserEntity user = context.UserTables.FirstOrDefault(x => x.Email == model.Email);
            if (user != null)
            {
                throw new Exception("User already exist");
            }
            else
            {/*
                context.UserTables.Add(entity);*/
                context.UserTables.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        /*User login*/
        public string UserLogin(LoginModel model)
        {

            UserEntity user = context.UserTables.FirstOrDefault(x => x.Email == model.Email);

            if (user != null)
            {
                if (encryption.CheckPassword(model.Password, user.Password))
                {
                    string token = GenerateToken(user.Email, user.UserId);
                    return token;
                }
                else
                {
                    throw new Exception("Incorrect password");
                }
            }
            else
            {
                throw new Exception("Incorrect email");
            }
        }

        public string GenerateToken(string Email, int UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",Email),
                new Claim("UserId",UserId.ToString())
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ForgotPasswordModel ForgotPassword(string email)
        {
            var entity = context.UserTables.SingleOrDefault(user => user.Email == email);
            ForgotPasswordModel model = new ForgotPasswordModel();
            model.UserId = entity.UserId.ToString();
            model.Email = entity.Email;
            model.Token = GenerateToken(email, entity.UserId);
            return model;
        }

        public bool CheckEmail(string userEmail)
        {
            return context.UserTables.Any(x => x.Email == userEmail);
        }
        public bool ResetPassword(string Email, ResetPasswordModel model)
        {
            UserEntity User = context.UserTables.ToList().Find(User => User.Email == Email);

            if (User != null)
            {
                User.Password = encryption.GenerateHashedPassword(model.newPassword);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
