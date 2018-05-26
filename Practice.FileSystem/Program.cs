using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;

namespace Practice.FileSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			FileSystemInformation fileSystem = new FileSystemInformation();
			//fileSystem.CopyDeleteMove();
			fileSystem.GetFiles();

			//FileSysInfo filesysinfo = new FileSysInfo();
			////filesysinfo.DriveInformation();
			////filesysinfo.CreateFile();
			//filesysinfo.CopyDeleteMove();


		}
	}
	public class FileSysInfo
	{
		public void DriveInformation()
		{
			DriveInfo drive = new DriveInfo("c:");
			var res=drive.AvailableFreeSpace;

			DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\NewMyFile1\Test");
			directoryInfo.Create();
			DirectorySecurity directorySecurity = new DirectorySecurity();
			directoryInfo.Create();
			//directoryInfo.CreateSubdirectory("MyTest");

			//List<FileInfo> fileInfo = directoryInfo.GetFiles("*.*").ToList();

			//foreach (var filelist in fileInfo)
			//{
			//	Console.WriteLine("{0},{1},{2}", filelist.Name, filelist.Length, filelist.LastAccessTime);
			//	Console.ReadLine();

			//}
			 List<DirectoryInfo> directoryInfos=directoryInfo.GetDirectories(@"*.*").ToList();
			foreach (var dirinfo in directoryInfos)
			{
				Console.WriteLine(dirinfo.Name);
				Console.ReadLine();

			}
		}
		public void CreateFile()
		{
			string drive = @"D:\NewMyFile1\";
			string foldername = "Test";
			string path = Path.Combine(drive, foldername);
			//DirectoryInfo directoryInfo = new DirectoryInfo(path);
			//directoryInfo.Create();
			string filename = "Sravani_file.txt";
			path = Path.Combine(path, filename);

			if (File.Exists(path))
			{
				Console.WriteLine("file already exist");
			}
			else
			{
				FileStream fs = File.Create(path);
				for (byte i = 0; i < 100; i++)
				{
					fs.WriteByte(i);
				}

			}
			string text = "new text";
		File.WriteAllText(path, text);

			using (System.IO.StreamWriter file =
		   new System.IO.StreamWriter(path, true))
			{
				file.WriteLine("\n Fourth line");
			}
		}

		public void CopyDeleteMove()
		{
			string filename = "sravani.txt";
			string sourcepath = @"D:\NewMyFile1\Test";
			string targetpath = @"D:\NewMyFile2\Test2";
			if (Directory.Exists(targetpath))
			{

				Directory.CreateDirectory(targetpath);
			}
			else
			{
				Console.WriteLine("directory exists");
			}
			File.Copy(sourcepath, targetpath);

			if (Directory.Exists(sourcepath))
			{
				string[] files= Directory.GetFiles(sourcepath);
				foreach (var str in files)
				{
					filename = Path.GetFileName(str);
					var destfile = Path.Combine(targetpath, filename);
					File.Copy(str, destfile, true);

				}
			}
		}


	}
}
