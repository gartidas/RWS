using RWS.Contracts;
using System.Threading.Tasks;

namespace RWS.Services
{
    class ConverterService
    {
        private readonly IConverterProvider _converterProvider;
        private readonly IWriterProvider _writerProvider;
        private readonly IReaderProvider _readerProvider;

        public ConverterService(IConverterProvider converterProvider, IWriterProvider writerProvider, IReaderProvider readerProvider)
        {
            _converterProvider = converterProvider;
            _writerProvider = writerProvider;
            _readerProvider = readerProvider;
        }

        public async Task<Result> ConvertSourceToTarget(string sourcePath, string targetPath)
        {
            var readResult = await _readerProvider.Read(sourcePath);
            if (readResult.Failed)
                return Result.Failure(readResult.Errors);

            var convertResult = _converterProvider.Convert(readResult.Data);
            if (convertResult.Failed)
                return Result.Failure(convertResult.Errors);

            var writeResult = await _writerProvider.Write(targetPath, convertResult.Data);
            if (writeResult.Failed)
                return Result.Failure(writeResult.Errors);

            return Result.Success();
        }
    }
}
