using System.IO;
using System.Linq;

namespace FolderSize 
{
    public class FolderSize 
    {
        static void Main() 
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";
            
            GetFolderSize(folderPath, outputPath); 
        }
        public static void GetFolderSize(string folderPath, string outputFilePath) 
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{GetSize(folderPath)/1024/1024/1024} KB");
            }
        }

        public static long GetSize(string folderPath)
        {
            long size = 0;
            string[] files = Directory.GetFiles(folderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            string[] dirs = Directory.GetDirectories(folderPath);

            foreach (var dir in dirs)
                size += GetSize(folderPath);

            return size;
            
        }
    }
}