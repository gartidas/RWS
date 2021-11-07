using RWS.Contracts;
using System.IO;


namespace RWS.ReaderProviders
{
    class FileReaderProvider : ReaderProvider
    {
        public string Read(string sourcePath)
        {
            FileStream sourceStream = File.Open(sourcePath, FileMode.Open);
            var reader = new StreamReader(sourceStream);
            string result = reader.ReadToEnd();

            return result;
        }
    }
}
