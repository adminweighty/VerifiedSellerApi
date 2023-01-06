using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace VerifiedSeller.Server.AuthenticationManager
{
    public sealed class PasswordHash
    {
        private const int SaltSize = 10;

        private const int HashSize = 40;

        private const int Iterations = 10000;

        private PasswordHash(byte[] hashBytes, byte[] saltBytes)
        {
            HashBytes = hashBytes;
            SaltBytes = saltBytes;
        }

        public byte[] HashBytes { get; private set; }

        public byte[] SaltBytes { get; private set; }

        public string HashBase64
        {
            get { return Convert.ToBase64String(HashBytes); }
        }

        public string SaltBase64
        {
            get { return Convert.ToBase64String(SaltBytes); }
        }

        public static PasswordHash Generate(string password, int hashSize = HashSize, int saltSize = SaltSize)
        {
            using (var hasher = new Rfc2898DeriveBytes(password, saltSize, Iterations))
            {
                return new PasswordHash(hasher.GetBytes(hashSize), hasher.Salt);
            }
        }

        public static PasswordHash From(string hashBase64, string saltBase64)
        {
            var hashBytes = Convert.FromBase64String(hashBase64);
            var saltBytes = Convert.FromBase64String(saltBase64);

            return From(hashBytes, saltBytes);
        }

        public static PasswordHash From(byte[] hashBytes, byte[] saltBytes)
        {
            return new PasswordHash(hashBytes, saltBytes);
        }

        public bool Verify(string password)
        {
            using (var hasher = new Rfc2898DeriveBytes(password, SaltBytes, Iterations))
            {
                return SlowEquals(hasher.GetBytes(HashBytes.Length), HashBytes);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static bool SlowEquals(IList<byte> a, IList<byte> b)
        {
            var diff = a.Count ^ b.Count;

            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                diff |= a[i] ^ b[i];
            }

            return diff == 0;
        }
    }
}
