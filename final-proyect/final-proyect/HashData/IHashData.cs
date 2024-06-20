namespace final_proyect.HashData
{
    public interface IHashData
    {
        public string DataHasher(string password);
        public bool Verify(string dataHash, string dataInput);
    }
}
