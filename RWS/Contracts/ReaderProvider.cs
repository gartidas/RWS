namespace RWS.Contracts
{
    interface ReaderProvider
    {
        public Result<string> Read(string sourcePath);
    }
}
