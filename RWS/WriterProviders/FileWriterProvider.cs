using RWS.Contracts;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RWS.WriterProviders
{
    class FileWriterProvider : IWriterProvider
    {
        public async Task<Result> Write(string targetPath, string content)
        {
            try
            {
                using FileStream targetStream = File.Open(targetPath, FileMode.Create, FileAccess.Write);
                using var writer = new StreamWriter(targetStream);
                await writer.WriteAsync(content);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }

        }
    }
}
