using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = "copyMe.png";
            string copyPath = "copyMe-copy.png";

            using (FileStream streamReader = new FileStream(picPath,FileMode.Open))
            {
                using (FileStream streamWriter = new FileStream(copyPath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] byteArray = new byte[4096];
                        var size = streamReader.Read(byteArray, 0, byteArray.Length);
                        if (size == 0)
                        {
                            break;
                        }
                        streamWriter.Write(byteArray, 0, size);
                    }                  
                }
            }
        }
    }
}
