namespace RWS.Contracts
{
    interface ConverterProvider
    {
        public Result<string> Convert(string input);
    }
}
