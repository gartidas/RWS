using System.Threading.Tasks;

namespace RWS.Contracts
{
    public interface IWriterProvider
    {
        public Task<Result> Write(string targetPath, string content);
    }
}
