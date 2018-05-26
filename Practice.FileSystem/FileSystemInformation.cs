using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Practice.FileSystem
{
	public class FileSystemInformation
	{
		public void CopyDeleteMove()
		{

			string filename = "sravani_text.txt";
			string sourchepath = @"d:\FirstFile\MyTest";
			string taretpath = @"D:\SecondFile\MyTest\TestFile";

			string sourcefile = Path.Combine(sourchepath, filename);
			string destfile = Path.Combine(taretpath, filename);

			if (!File.Exists(sourchepath))
			{
				DirectoryInfo directory = new DirectoryInfo(sourchepath);
				directory.Create();

			}
			else
			{
				Console.WriteLine("path exists");
			}
			if (!File.Exists(taretpath))
			{
				DirectoryInfo directory = new DirectoryInfo(taretpath);
				directory.Create();
			}
			File.Copy(sourcefile, destfile,true);
		}
		public void GetFiles()
		{
			string sourcepath = @"d:\FirstFile\MyTest";
			DirectoryInfo directory = new DirectoryInfo(sourcepath);
			List<FileInfo> fileslist = directory.GetFiles("*.txt*").ToList(); ; 
		}
	}
}
