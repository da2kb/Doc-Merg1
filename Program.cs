using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Merger
{
    class Program
    {
        static void Run()
        {
            var filenames = new List<string> { "yay", "why", "1file" };

            Console.WriteLine("Document Merger\n");
            Console.WriteLine("The name of the first file:");
            string name1 = Console.ReadLine();
            while (true)
            {
                var exist = filenames.IndexOf(name1);
                if (exist != -1)
                {
                    Console.WriteLine("");
                    break;
                }
                else
                {
                    Console.WriteLine("The filename does not exist. Please enter another filename:");
                    name1 = Console.ReadLine();
                }

            }
            Console.WriteLine("The name of the second file:");
            string name2 = Console.ReadLine();
            while (true)
            {
                var exist = filenames.IndexOf(name2);
                if (exist != -1)
                {
                    Console.WriteLine("");
                    break;
                }
                else
                    Console.WriteLine("The filename does not exist. Please enter another filename:");
                name2 = Console.ReadLine();
            }

            string filename = name1 + name2 + ".txt";
            StreamWriter sw = new StreamWriter(filename);

            string line, line1;
            int count = 0;
            bool success = false;

            StreamReader sr1 = null;
            StreamReader sr2 = null;

            try
            {
                sr1 = new StreamReader(name1 + ".txt");
                sr2 = new StreamReader(name2 + ".txt");

                line = sr1.ReadToEnd();
                line1 = sr2.ReadToEnd();

                sw.Write(line + line1);
                count = line.Length + line1.Length;

                success = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (sr1 != null)
                    sr1.Close();
                if (sr2 != null)
                    sr2.Close();
                if (success)
                    Console.WriteLine(filename + " was successfully saved. The document contains " + count + " characters.");

            }

        }
        static void Main(string[] args)
        {
            do
            {
                Run();
                Console.WriteLine("Would you like to merge two more files? (y/n)");
                string c = Console.ReadLine();
                if (c == "n")
                    break;
            } while (true);
        }


    }
}
