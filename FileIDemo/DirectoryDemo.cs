using System.IO;

namespace FileIDemo;

public class DirectoryDemo
{
    public void DirectoryDemoFunc(string DirectoryName)
    {
        if (Directory.Exists(DirectoryName))
        {
            System.Console.WriteLine("Folder Already Exist...");
        }
        else
        {
            Directory.CreateDirectory(DirectoryName);
            Console.WriteLine("Folder Created.");
        }
    }

    public void DriveInfoFunc(string driveName)
    {
        DriveInfo dInfo = new DriveInfo(driveName);

        Console.WriteLine($"Drive Name : {dInfo.Name}");
        Console.WriteLine($"Drive Type : {dInfo.DriveType}");
        Console.WriteLine($"Is Ready   : {dInfo.IsReady}");

        if (dInfo.IsReady)
        {
            Console.WriteLine($"Total Size : {dInfo.TotalSize}");
            Console.WriteLine($"Free Space : {dInfo.AvailableFreeSpace}");
        }
    }

    public void PathDemoFunc()
    {
        string s = @"C:\temp\MyData.text\machine.config";
        System.Console.WriteLine("File Name : " + Path.GetFileName(s));
        System.Console.WriteLine("Full Path : " + Path.GetFullPath(s));
        System.Console.WriteLine("Directory : " + Path.GetDirectoryName(s));
        System.Console.WriteLine("Extension : " + Path.GetExtension(s));
    }
}