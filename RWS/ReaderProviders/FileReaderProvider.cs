using RWS.Contracts;
using System;
using System.IO;


namespace RWS.ReaderProviders
{
    class FileReaderProvider : ReaderProvider
    {
        public Result<string> Read(string sourcePath)
        {
            try
            {
                using FileStream sourceStream = File.Open(sourcePath, FileMode.Open);
                using var reader = new StreamReader(sourceStream);
                string result = reader.ReadToEnd();
                return Result<string>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure(ex.Message);
            }
        }
    }
}
