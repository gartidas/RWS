using RWS.Contracts;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RWS.ReaderProviders
{
    class FileReaderProvider : IReaderProvider
    {
        public async Task<Result<string>> Read(string sourcePath)
        {
            try
            {
                using FileStream sourceStream = File.Open(sourcePath, FileMode.Open);
                using var reader = new StreamReader(sourceStream);
                string result = await reader.ReadToEndAsync();
                return Result<string>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure(ex.Message);
            }
        }
    }
}
