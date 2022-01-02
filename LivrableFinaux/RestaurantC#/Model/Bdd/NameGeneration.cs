using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace ProjectResto.Models.Bdd
{

    class NameGeneration
    {
        public static List<string> names = new List<string>();

        public static string GenerateWord()
        {
            int length = 6;
            using (var crypto = new RNGCryptoServiceProvider())
            {
                String name = "";
                do
                {
                    var bits = (length * 6);
                    var byte_size = ((bits + 7) / 8);
                    var bytesarray = new byte[byte_size];
                    crypto.GetBytes(bytesarray);
                    name = Convert.ToBase64String(bytesarray);
                } while (names.Contains(name));

                names.Add(name);
                return name;
            }
        }
    }
}
