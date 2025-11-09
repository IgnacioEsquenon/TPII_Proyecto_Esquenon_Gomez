using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedoraAppLibrary
{
    public static class ContrasenaHelper
    {
        public static string HashPassword(string password)
        {
            //  Algoritmo SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2")); 
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string passwordToCheck, string savedHash)
        {
            //Calcula el hash de la contraseña que el usuario ingresó
            string hashOfPasswordToCheck = HashPassword(passwordToCheck);

            // Compara el nuevo hash con el hash guardado
            // Usa StringComparer.OrdinalIgnoreCase para una comparación segura
            return StringComparer.OrdinalIgnoreCase.Equals(hashOfPasswordToCheck, savedHash);
        }

    }
}
