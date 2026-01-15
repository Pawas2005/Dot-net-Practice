using System.IO;
namespace FileIDemo;

public class Program{
    public static void Main()
    {
        DirectoryDemo dObj = new FileIDemo.DirectoryDemo();

        // dObj.DirectoryDemoFunc("LPU");
        // Console.WriteLine();

        // dObj.DriveInfoFunc("D:\\");
        // Console.WriteLine();

        // dObj.DriveInfoFunc("C:\\");
        // Console.WriteLine();

        // dObj.PathDemoFunc();
        // Console.WriteLine();

        FileStreamDemo fsDemoObj = new FileStreamDemo();
        // fsDemoObj.CreateFile(@"C:\Users\pawas\dot-net\FileIDemo\LPU\SampleData.txt");

        fsDemoObj.ReadFile(@"C:\Users\pawas\dot-net\FileIDemo\Program.cs");
    }
}
