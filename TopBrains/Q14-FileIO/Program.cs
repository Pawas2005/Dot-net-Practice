using System;

namespace FileInpOP
{
    public class Program
    {
        public static void Main()
        {
            string inputFile = "log.txt";
            string outputFile = "error.txt";

            try
            {
                string[] lines = File.ReadAllLines(inputFile);

                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    foreach(string line in lines)
                    {
                        if (line.Contains("ERROR"))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                Console.WriteLine("ERROR logs extracted successfully to error.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("log.txt file not found.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}