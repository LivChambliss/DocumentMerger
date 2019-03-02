using System;
using System.IO;
using System.Text;

namespace Document_Merger
{
    class Program
    {

        static void runOnce()
        {
            Console.WriteLine("Document Merger"); 
            Console.WriteLine(); 
            String first = "";  
            String second = ""; 
            bool firstPrompt = true; 
            do
            {
                if (firstPrompt) 
                {
                    firstPrompt = false; 
                }
                else
                {
                    Console.WriteLine("Invalid filename."); 
                }
                Console.WriteLine("Please enter the name of the first text file to be merged:"); 
                first = Console.ReadLine(); 
            } while (first.Length > 0 && !File.Exists(first)); 
            firstPrompt = true; 
            do
            {
                if (firstPrompt) 
                {
                    firstPrompt = false; 
                }
                else
                {
                    Console.WriteLine("Invalid filename."); 
                }
                Console.WriteLine("Please enter the name of the second text file to be merged:"); 
                second = Console.ReadLine(); // read second filename
            } while (second.Length > 0 && !File.Exists(second)); 

            String merged = first.Substring(0, first.Length - 4) + second.Substring(0, second.Length - 4) + ".txt"; 
            StreamWriter sw = null; 
            StreamReader sr1 = null; 
            StreamReader sr2 = null; 

            bool success = false; 

            int count = 0; 

            try
            {
                sw = new StreamWriter(merged); 
                sr1 = new StreamReader(first); 
                sr2 = new StreamReader(second); 

                String line = sr1.ReadLine(); 
                while (line != null) 
                {
                    sw.WriteLine(line); 
                    count += line.Length; 
                    line = sr1.ReadLine(); 
                }
                line = sr2.ReadLine(); 
                while (line != null) 
                {
                    sw.WriteLine(line); 
                    count += line.Length; 
                    line = sr2.ReadLine(); 
                }
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
                    Console.WriteLine(merged + " was successfully saved. The document contains " + count + " characters."); 
            }
        }

        static void Main(string[] args)
        {
            do
            {
                runOnce();
                Console.WriteLine("Would you like to merge two more files? (y/n)"); 
                char c = Console.ReadLine()[0]; 
                if (c == 'n') 
                    break; 
            } while (true); 
        }
    }
}
