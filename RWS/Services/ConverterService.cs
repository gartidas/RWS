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

        public Result ConvertSourceToTarget(string sourcePath, string targetPath)
        {
            var readResult = _readerProvider.Read(sourcePath);
            if (readResult.Failed)
                return Result.Failure(readResult.Errors);

            var convertResult = _converterProvider.Convert(readResult.Data);
            if (convertResult.Failed)
                return Result.Failure(convertResult.Errors);

            var writeResult = _writerProvider.Write(targetPath, convertResult.Data);
            if (writeResult.Failed)
                return Result.Failure(writeResult.Errors);
            else
                return Result.Success();
        }
    }
}
