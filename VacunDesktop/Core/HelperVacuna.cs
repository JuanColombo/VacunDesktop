using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace VacunDesktop.Core
{
    public static class HelperVacuna
    {
        public static string ObtenerSha256Hash(string textoAEncriptar)
        {
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textoAEncriptar));
            // Convert byte array to a string   
            StringBuilder hashObtenido = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                hashObtenido.Append(bytes[i].ToString("x2"));
            }
            return hashObtenido.ToString();
        }
        public static string ObtenerCadenaDeConexion()
        {
            string servidor = Properties.Settings.Default.servidor;
            string bbdd = Properties.Settings.Default.bbdd;
            string usuario = Properties.Settings.Default.usuario;
            string contrasenia = Properties.Settings.Default.contraseña;

            string cadenaConexion = "Server= " + servidor;
            cadenaConexion += " ;Database = " + bbdd;
            cadenaConexion += " ;User Id = " + usuario;
            cadenaConexion += " ;Password = " + contrasenia;
            cadenaConexion += " ;MultipleActiveResultSets = true";
            return cadenaConexion;
        }


    }
}
