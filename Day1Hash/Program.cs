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
            string output = Encryptor.MakeSha256(myInput);
            Console.WriteLine(output);
        }
    }
}
