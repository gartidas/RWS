using RWS.Contracts;
using System;
using System.IO;

namespace RWS.WriterProviders
{
    class FileWriterProvider : WriterProvider
    {
        public Result Write(string targetPath, string content)
        {
            try
            {
                using FileStream targetStream = File.Open(targetPath, FileMode.Create, FileAccess.Write);
                using var writer = new StreamWriter(targetStream);
                writer.Write(content);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }

        }
    }
}
