namespace RWS.Contracts
{
    interface WriterProvider
    {
        public Result Write(string targetPath, string content);
    }
}
