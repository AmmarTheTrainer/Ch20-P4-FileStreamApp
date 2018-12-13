using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch20_P4_FileStreamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with FileStreams *****\n");
            // Obtain a FileStream object.
            using (FileStream fStream = File.Open(@"myMessage.dat", FileMode.Create))
            {
                DisplayDetails(fStream);
                // Encode a string as an array of bytes.
                string msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                // Write byte[] to file.
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                // Reset internal position of stream.
                fStream.Position = 0;
                // Read the types from file and display to console.
                Console.Write("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytesFromFile[i]);
                }
                // Display decoded messages.
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
            Console.ReadLine();
        }

        private static void DisplayDetails(FileStream fStream)
        {
            Console.WriteLine();
            Console.WriteLine(" FileStream CanRead "+fStream.CanRead);
            Console.WriteLine(" FileStream CanSeek " + fStream.CanSeek);
            Console.WriteLine(" FileStream CanTimeOut " + fStream.CanTimeout);
            Console.WriteLine(" FileStream CanWrite " + fStream.CanWrite);
            //Console.WriteLine(fStream.Handle);
            Console.WriteLine(" FileStream Length " + fStream.Length);
            Console.WriteLine(" FileStream Name " + fStream.Name);
            Console.WriteLine(" FileStream Position " + fStream.Position);
            Console.WriteLine();
        }
    }
}
