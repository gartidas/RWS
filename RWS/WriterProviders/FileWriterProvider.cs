using RWS.Contracts;
using System.IO;

namespace RWS.WriterProviders
{
    class FileWriterProvider : WriterProvider
    {
        public void Write(string targetPath, string content)
        {
            var targetStream = File.Open(targetPath, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream);
            sw.Write(content);
        }
    }
}
