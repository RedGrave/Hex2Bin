using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEX2BIN
{
    class Program
    {

        static bool checkLine(string s)
        {
            if (s[0] != '"')
            {
                Console.WriteLine("Missing ':' character in line...");
                return false;
            }
            
            if (s.Length < 11)
            {
                Console.WriteLine("Data too small");
                return false;
            }

            return true;

        }

        static void Main(string[] args)
        {
            if (args.Count() > 0)
            {
                if (System.IO.File.Exists(args[0]))
                {
                    try
                    {
                        Console.WriteLine("Reading file...");
                        string[] data = System.IO.File.ReadAllLines(args[0]);
                        Console.WriteLine("OK !");
                        bool isValid = true;

                        int count = 0;

                        Console.WriteLine("Checking File...");
                        foreach (string s in data)
                        {
                            count++;
                            if (isValid)
                            {
                                isValid = checkLine(s);
                                if (!isValid) Console.WriteLine("Error found on line " + count);
                            }

                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else Console.WriteLine("Invalid file");
            }

            else Console.WriteLine("Please specify a file");


            /*
             *  Read data line-by-line
             *  Foreach line
             *      remove the :
             *      read 2 byte: number of octets
             *      read 4 byte: destination adress
             *      read 2 byte: data type
             *      read x byte: data
             *      read 2 byte: parity
             */
        }
    }
}
