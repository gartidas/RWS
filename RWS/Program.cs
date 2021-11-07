using RWS.ConverterProviders;
using RWS.ReaderProviders;
using RWS.Services;
using RWS.WriterProviders;
using System;
using System.IO;

namespace RWS
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\SourceFiles\\Document1.xml");
            var targetPath = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\TargetFiles\\Document1.json");

            var converterProvider = new XmlToJsonConverterProvider();
            var writerProvider = new FileWriterProvider();
            var readerProvider = new FileReaderProvider();
            var converterService = new ConverterService(converterProvider, writerProvider, readerProvider);

            var convertResult = converterService.ConvertSourceToTarget(sourcePath, targetPath);
            if (convertResult.Failed)
                Console.WriteLine(convertResult.Errors);
        }
    }
}