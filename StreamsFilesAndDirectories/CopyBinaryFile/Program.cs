namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            byte[] buffer;
            using (var reader = new FileStream(inputFilePath, FileMode.Open))
            {
                buffer = new byte[reader.Length];
                reader.Read(buffer, 0, buffer.Length);
            }
            using (var writer = new FileStream(outputFilePath, FileMode.Create))
            {
                writer.Write(buffer);
            }
        }
    }
}