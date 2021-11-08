using System.Threading.Tasks;

namespace RWS.Contracts
{
    interface IReaderProvider
    {
        public Task<Result<string>> Read(string sourcePath);
    }
}
