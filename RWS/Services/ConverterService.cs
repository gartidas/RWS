using RWS.Contracts;

namespace RWS.Services
{
    class ConverterService
    {
        private readonly ConverterProvider _converterProvider;
        private readonly WriterProvider _writerProvider;
        private readonly ReaderProvider _readerProvider;

        public ConverterService(ConverterProvider converterProvider, WriterProvider writerProvider, ReaderProvider readerProvider)
        {
            _converterProvider = converterProvider;
            _writerProvider = writerProvider;
            _readerProvider = readerProvider;
        }

        public void ConvertSourceToTarget(string sourcePath, string targetPath)
        {
            string content = _readerProvider.Read(sourcePath);
            var convertedContent = _converterProvider.Convert(content);
            _writerProvider.Write(targetPath, convertedContent);
        }
    }
}
