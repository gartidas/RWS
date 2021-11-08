using System.Threading.Tasks;

namespace RWS.Contracts
{
    interface IWriterProvider
    {
        public Task<Result> Write(string targetPath, string content);
    }
}
