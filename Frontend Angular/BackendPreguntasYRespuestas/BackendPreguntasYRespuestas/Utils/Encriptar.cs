using System.Security.Cryptography;
using System.Text;

namespace BackendPreguntasYRespuestas.Utils
{
    public static class Encriptar
    {
        public static string EncriptarPassword(string password) {
            MD5 md5Hash =MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i=0; i<data.Length;i++) {
            stringBuilder.Append(data[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
