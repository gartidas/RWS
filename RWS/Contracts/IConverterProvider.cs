namespace RWS.Contracts
{
    interface IConverterProvider
    {
        public Result<string> Convert(string input);
    }
}
