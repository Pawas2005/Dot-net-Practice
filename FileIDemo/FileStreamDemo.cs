using System;
using System.IO;

namespace FileIDemo;

public class FileStreamDemo
{
    FileStream fs = null;

    public void CreateFile(string fileName)
    {
        StreamWriter sw = null;
        try
        {
            fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine("This is Just a Sample File for File IO Demo");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FileLoadException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (sw != null) sw.Close();
            if (fs != null) fs.Close();
        }
    }

    public void ReadFile(string fileName)
    {
        fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);

        Console.WriteLine(sr.ReadToEnd());

        sr.Close();
        fs.Close();
    }
}
