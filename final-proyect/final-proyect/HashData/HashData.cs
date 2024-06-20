using System.Security.Cryptography;

namespace final_proyect.HashData
{
    public class HashData : IHashData
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const char Delimeter = ';';

        public string DataHasher(string data)
        {
            var salt = RandomNumberGenerator.GetBytes(count: SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(data, salt, Iterations, _hashAlgorithmName, outputLength: KeySize);

            return $"{Convert.ToBase64String(salt)}{Delimeter}{Convert.ToBase64String(hash)}";
        }

        public bool Verify(string dataHash, string dataInput) 
        {
            var elements = dataHash.Split(Delimeter);
            if (elements.Length != 2 ) 
            {
                return false;
            }

            var salt = Convert.FromBase64String(elements[0]);
            var hash = Convert.FromBase64String(elements[1]);
            var hashCompare = Rfc2898DeriveBytes.Pbkdf2(dataInput, salt, Iterations, _hashAlgorithmName, KeySize);

            return hashCompare.SequenceEqual(hash);
        }
  


    }
}
