namespace RWS.Contracts
{
    interface WriterProvider
    {
        public void Write(string targetPath, string content);
    }
}
