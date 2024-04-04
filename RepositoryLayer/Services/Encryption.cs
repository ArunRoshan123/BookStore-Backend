using System;
using System.Collections.Generic;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace RepositoryLayer.Services
{
    public class Encryption
    {
        public string GenerateHashedPassword(string input)
        {
            if (input == null)
            {
                throw new Exception("Give some input");
            }
            int saltLength = new Random().Next(10, 13);
            string generatedSalt = BC.GenerateSalt(saltLength);
            string hashedPassword = BC.HashPassword(input, generatedSalt);
            return hashedPassword;
        }
        public bool CheckPassword(string userPassword, string hashedPassword)
        {
            try
            {
                return BC.Verify(userPassword, hashedPassword);
            }
            catch
            {
                return false;
            }
        }
    }
}
