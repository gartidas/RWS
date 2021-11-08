using System.Threading.Tasks;

namespace RWS.Contracts
{
    public interface IReaderProvider
    {
        public Task<Result<string>> Read(string sourcePath);
    }
}
