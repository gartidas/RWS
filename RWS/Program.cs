using RWS.ConverterProviders;
using RWS.ReaderProviders;
using RWS.Services;
using RWS.WriterProviders;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RWS
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\SourceFiles\\Document1.xml");
            var targetPath = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\TargetFiles\\Document1.json");

            var converterProvider = new XmlToJsonConverterProvider();
            var writerProvider = new FileWriterProvider();
            var readerProvider = new FileReaderProvider();
            var converterService = new ConverterService(converterProvider, writerProvider, readerProvider);

            var convertResult = await converterService.ConvertSourceToTarget(sourcePath, targetPath);
            if (convertResult.Failed)
                Console.WriteLine(convertResult.Errors);
        }
    }
}