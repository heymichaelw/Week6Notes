using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Day1Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            string myInput = Console.ReadLine();

            byte[] byteData = Encoding.UTF8.GetBytes(myInput);
            Stream inputStream = new MemoryStream(byteData);

            using (SHA256 shaM = new SHA256Managed())
            {
                var result = shaM.ComputeHash(inputStream);
                string output = BitConverter.ToString(result);

                Console.WriteLine(output.Replace("-", "").Substring(0, 5));
            }

          
            //Step 1: Take User input
            //Step 2: Encrypt input
        }
    }
}
