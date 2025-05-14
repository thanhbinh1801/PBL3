using System;
using System.Security.Cryptography;

namespace PBL3.BLL
{
    class HashPassword
    {
        public static string HashPW(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        public static bool VerifyPW(string password, string hashPW)
        {
            string hashOfInput = HashPW(password);
            return hashOfInput == hashPW;
        }
    }
}
