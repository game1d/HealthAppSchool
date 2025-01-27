using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Data
{
    public static class HashMaker
    {
        public static string ToSHA512(string _string)//Vond deze op youtube. Ik neem aan dat deze oud en dus lek is, maar voor deze site gaat dat niet uitmaken.
        {
            using var sha512 = SHA512.Create();
            byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(_string));

            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
