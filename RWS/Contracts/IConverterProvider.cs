namespace RWS.Contracts
{
    public interface IConverterProvider
    {
        public Result<string> Convert(string input);
    }
}
